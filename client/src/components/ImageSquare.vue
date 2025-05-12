<template>
  <div
    :class="color"
    class="product-image-container flex items-center justify-center rounded overflow-hidden w-full aspect-square"
  >
    <img :src="src" :alt="src" class="h-[80%]" />
  </div>
</template>
<script lang="ts">
export default {
  name: "ImageSquare",
  props: {
    src: {
      type: String,
      required: true,
    },
    alt: {
      type: String,
      required: true,
    },
    color: {
      type: String,
      default: "bg-amber-100",
    },
  },
};
</script>
