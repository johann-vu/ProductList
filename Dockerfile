FROM node AS frontend-builder

WORKDIR /app/frontend
COPY client/ ./

RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS backend-builder

WORKDIR /app

COPY ProductList/ ./backend/

COPY --from=frontend-builder /app/frontend/dist ./backend/wwwroot

WORKDIR /app/backend
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=backend-builder /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "ProductList.dll"]