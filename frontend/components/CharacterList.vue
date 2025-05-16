<template>
	<v-container>
		<v-text-field
			v-model="search"
			label="Search"
			prepend-icon="mdi-magnify"
			class="mb-4"
		></v-text-field>

		<v-table class="elevation-1">
			<DataRow
				v-for="item in filteredItems"
				:key="item.email"
				:item="item"
				@view="viewItem"
				@edit="editItem"
			/>
		</v-table>
	</v-container>
</template>
  
<script setup>
import { ref } from "vue";

const search = ref("");
const headers = [
	{ text: "Name", value: "name" },
	{ text: "Email", value: "email" },
	{ text: "Actions", value: "actions", sortable: false },
];

const items = ref([
	{ name: "Alice Smith", email: "alice@example.com" },
	{ name: "Bob Johnson", email: "bob@example.com" },
	{ name: "Charlie Rose", email: "charlie@example.com" },
	{ name: "Diana Prince", email: "diana@example.com" },
]);

const filteredItems = computed(() => {
	if (!search.value) return items.value;
	return items.value.filter(
		(item) =>
			item.name.toLowerCase().includes(search.value.toLowerCase()) ||
			item.email.toLowerCase().includes(search.value.toLowerCase())
	);
});

function viewItem(item) {
	alert(`Viewing ${item.name}`);
}

function editItem(item) {
	alert(`Editing ${item.name}`);
}
</script>