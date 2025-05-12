<template>
  <div class="flex flex-col w-full max-w-3xl items-end py-2">
    <div class="flex justify-between items-center py-2 rounded-lg w-full">
      <flapo-switch
        label="Bier unter 2€ pro Liter"
        :enabled="filterProducts"
        @update:enabled="setFilter"
      ></flapo-switch>
      <ToggleButton :toggle="setView" :showList="showList" />
    </div>
    <div class="flex justify-start items-center py-2 rounded-lg w-full">
      <button
        class="py-2 text-gray-700 rounded-lg flex items-center gap-2"
        @click="setSort(!sortAscending)"
        :class="{}"
      >
        <svg
          v-if="sortAscending"
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
        <svg
          v-else
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
            d="m4.5 15.75 7.5-7.5 7.5 7.5"
          />
        </svg>

        Preis {{ sortAscending ? "aufsteigend" : "absteigend" }}
      </button>
    </div>
  </div>
</template>

<script lang="ts">
import FlapoSwitch from "./FlapoSwitch.vue";
import { defineComponent } from "vue";
import ToggleButton from "./ToggleButton.vue";
export default defineComponent({
  name: "TopControlls",
  components: {
    FlapoSwitch,
    ToggleButton,
  },
  methods: {
    setView(state: boolean) {
      console.log("setView", state);
      this.showList = state;
      this.$emit("change:view", state);
    },
    setSort(state: boolean) {
      this.sortAscending = state;
      this.$emit("change:sort", state);
    },
    setFilter(state: boolean) {
      this.filterProducts = state;
      this.$emit("change:filter", state);
    },
  },
  emits: ["change:view", "change:sort", "change:filter"],
  data() {
    return {
      showList: true,
      filterProducts: false,
      sortAscending: false,
    };
  },
});
</script>