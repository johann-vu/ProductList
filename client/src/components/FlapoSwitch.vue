<script lang="ts">
import { Switch, SwitchGroup, SwitchLabel } from "@headlessui/vue";
import { defineComponent } from "vue";

export default defineComponent({
  name: "FlapoSwitch",
  components: {
    SwitchGroup,
    SwitchLabel,
    Switch,
  },
  props: {
    enabled: {
      type: Boolean,
      default: false,
    },
    label: {
      type: String,
      default: "Enable notifications",
    },
  },
  emits: ["update:enabled"],
  computed: {
    modelValue: {
      get() {
        return this.enabled;
      },
      set(value: boolean) {
        this.$emit("update:enabled", value);
      },
    },
  },
});
</script>
        
<template>
  <SwitchGroup>
    <div class="flex items-center">
      <Switch
        v-model="modelValue"
        :class="enabled ? 'bg-flapo' : 'bg-flapo/50'"
        class="relative inline-flex h-[24px] w-[48px] shrink-0 cursor-pointer rounded-full border-2 border-transparent transition-colors duration-200 ease-in-out focus:outline-none"
      >
        <span
          aria-hidden="true"
          :class="enabled ? 'translate-x-[24px]' : 'translate-x-0'"
          class="pointer-events-none inline-block h-[20px] w-[20px] transform rounded-full bg-white shadow-lg ring-0 transition duration-200 ease-in-out"
        />
      </Switch>
      <SwitchLabel class="ml-4">{{ label }}</SwitchLabel>
    </div>
  </SwitchGroup>
</template>
