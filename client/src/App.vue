<script lang="ts">
import TopControlls from "./components/TopControlls.vue";
import ProductList from "./components/ProductList.vue";
import { ProductService } from "./services/ProductService";
import type { ProductDto } from "./models/ProductDto";

import { defineComponent } from "vue";

export default defineComponent({
  components: {
    TopControlls,
    ProductList,
  },
  name: "App",
  data() {
    return {
      products: [] as ProductDto[],
      showDetails: true,
      sortProducts: false,
      filterProducts: false,
    };
  },
  methods: {
    async setView(state: boolean): Promise<void> {
      this.showDetails = state;
      await this.fetchProducts();
    },
    async setSort(state: boolean): Promise<void> {
      this.sortProducts = state;
      await this.fetchProducts();
    },
    async setFilter(state: boolean): Promise<void> {
      this.filterProducts = state;
      await this.fetchProducts();
    },
    async fetchProducts() {
      try {
        this.products = await ProductService.fetchProducts(
          "http://localhost:5051/api/products",
          this.sortProducts,
          this.filterProducts
        );
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    },
  },
  mounted() {
    this.fetchProducts()
      .then(() => {
        console.log("Products fetched successfully");
      })
      .catch((error) => {
        console.error("Error fetching products:", error);
      });
  },
});
</script>

<template>
  <div>
    <header
      class="bg-flapo h-16 flex items-center justify-center sticky top-0 z-10"
    >
      <img
        class="h-10"
        src="https://webshop-b2c-image-service-app.flaschenpost.de/corporateIdentity/fp_main_logo.svg"
        alt=""
      />
    </header>

    <main class="bg-gray-200 min-h-screen flex flex-col items-center px-4">
      <TopControlls
        @change:view="setView"
        @change:sort="setSort"
        @change:filter="setFilter"
      ></TopControlls>
      <ProductList :products="products" :show-details="showDetails" />
      <div class="h-4"></div>
    </main>
  </div>
</template>
