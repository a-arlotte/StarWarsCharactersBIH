<template>
	<v-container>
		<v-text-field
			v-model="searchTerm"
			label="Search"
			prepend-icon="mdi-magnify"
			class="mb-4"
		></v-text-field>

		<v-table class="elevation-1 overflow-y-auto">
			<DataRow v-for="item in filteredItems" :key="item.id" :item="item" />
		</v-table>
	</v-container>
</template>
  
<script setup lang="ts">
import { ref } from "vue";
import type { PropType } from "vue";
import type { Character } from "~/models/character";

const props = defineProps({
	items: Object as PropType<Character[]>,
});

const searchTerm = ref("");

const filteredItems = computed(() =>
	props.items.filter((item) =>
		item.name.toLowerCase().includes(searchTerm.value.toLowerCase())
	)
);

onMounted(() => {
	console.log("Character list mounted");
});
</script>