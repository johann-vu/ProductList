<template>
  <div
    class="hover:bg-gray-100 p-4 rounded-lg bg-white items-center"
    v-for="(article, index) in product.articles"
    :key="index"
  >
    <ImageSquare :src="article.image" :alt="product.name" />
  </div>
</template>
	  
	<script lang="ts">
import type { ProductDto } from "../models/ProductDto";
import { defineComponent, type PropType } from "vue";
import ImageSquare from "./ImageSquare.vue";

export default defineComponent({
  name: "product-image",
  components: {
    ImageSquare,
  },
  props: {
    product: {
      type: Object as PropType<ProductDto>,
      required: true,
    },
  },
});
</script>