<template>
	<v-container>
		<v-text-field
			v-model="search"
			label="Search"
			prepend-icon="mdi-magnify"
			class="mb-4"
		></v-text-field>

		<v-table class="elevation-1 overflow-y-auto">
			<DataRow
				v-for="item in items"
				:key="item.id"
				:item="item"
				@view="viewItem"
			/>
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

const search = ref("");

function viewItem(item: Character) {
	alert(`Viewing ${item.name}`);
}

onMounted(() => {
	console.log("Character list mounted");
});
</script>