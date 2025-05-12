<template>
  <button class="py-2 flex items-center gap-2">
    <svg
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      stroke-width="1.5"
      stroke="currentColor"
      class="size-6"
    >
      <path
        stroke-linecap="round"
        stroke-linejoin="round"
        d="m19.5 8.25-7.5 7.5-7.5-7.5"
      />
    </svg>

    Preis absteigend
  </button>
</template>
<script>
import { defineComponent } from "vue";

export default defineComponent({
  name: "SortingToggle",
});
</script>