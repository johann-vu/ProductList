export interface ProductDto {
	id: number
	brandName: string
	name: string
	articles: ArticleDto[]
}

export interface ArticleDto {
	id: number
	shortDescription: string
	price: number
	unit: string
	pricePerUnitText: string
	image: string
}
