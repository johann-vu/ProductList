<template>
  <div class="hover:bg-gray-100 p-4 rounded-lg bg-white">
    <div class="grid grid-cols-[6rem_auto] gap-4 items-center">
      <ImageSquare :src="product.articles[0].image" :alt="product.name" />

      <div class="flex flex-col justify-between">
        <p class="text-sm text-gray-500 font-medium">{{ product.brandName }}</p>
        <h2 class="text-lg font-semibold text-gray-800">
          {{ product.name }}
        </h2>

        <p class="text-sm text-gray-600">
          {{ product.articles[0].shortDescription }}
        </p>
        <p class="text-md font-bold text-gray-800">
          {{ product.articles[0].price }} €
        </p>
      </div>
    </div>
    <div class="mt-2" v-if="product.articles.length > 1">
      <hr class="border-t border-gray-300 my-4" />
      <div
        v-for="(article, index) in product.articles.slice(1)"
        :key="index"
        class="grid grid-cols-[6rem_auto] gap-4 items-center"
      >
        <div class="pl-6">
          <ImageSquare :src="article.image" :alt="product.name" />
        </div>
        <div class="flex flex-col justify-between">
          <p class="text-sm text-gray-600">
            {{ article.shortDescription }}
          </p>
          <p class="text-md font-bold text-gray-800">{{ article.price }} €</p>
        </div>
      </div>
    </div>
  </div>
</template>
	
  <script lang="ts">
import type { ProductDto } from "../models/ProductDto";
import { defineComponent, type PropType } from "vue";
import ImageSquare from "./ImageSquare.vue";

export default defineComponent({
  name: "ProductCard",
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