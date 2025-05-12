
<script lang="ts">
import type { ProductDto } from "../models/ProductDto";
import { defineComponent, type PropType } from "vue";
import ProductCard from "./ProductCard.vue";
import ProductImage from "./ProductImage.vue";

export default defineComponent({
  name: "ProductList",
  components: {
    ProductCard,
	ProductImage
  },
  props: {
    products: {
      type: Array as PropType<ProductDto[]>,
      required: true,
    },
    showDetails: {
      type: Boolean,
      default: true,
    },
  },
});
</script>

<template>
  <div class="flex flex-col gap-4 w-full max-w-3xl" v-if="showDetails">
    <ProductCard
      v-for="product in products"
      :product="product"
      :key="product.id"
    />
  </div>
  <div class="grid grid-cols-2 w-full gap-4 max-w-3xl" v-else>
    <ProductImage
      v-for="product in products"
      :product="product"
      :key="product.id"
    />
  </div>
  <div class="h-4"></div>
</template>
