<template>
  <div class="flex flex-col w-full max-w-3xl items-end">
    <div class="flex justify-between items-center py-4 rounded-lg w-full">
      <flapo-switch
        label="Bier unter 2€ pro Liter"
        :enabled="filterProducts"
        @update:enabled="setFilter"
      ></flapo-switch>
      <ToggleButton :toggle="setView" :showList="showList" />
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
      this.sortDescending = state;
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
      sortDescending: true,
    };
  },
});
</script>