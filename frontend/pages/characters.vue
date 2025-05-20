<template>
	<div>
		<h2>Star Wars Character List</h2>
		<label> Search: <input maxlength="20" /> </label>
		<div v-if="error" style="color: red">{{ error }}</div>
		<CharacterList :items="items" />
	</div>
</template>

<script setup lang="ts">
import type { Character } from "~/models/character";

const config = useRuntimeConfig();

let items = ref<Character[]>([]);
const error = ref("");

async function fetchData() {
	try {
		let url = `${config.public.apiUrl}/people`;
		console.log(url);
		const res = await fetch(url);
		if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
		let apiResult = await res.json();
		items = apiResult.data;
	} catch (e) {
		error.value = (e as Error).message;
	}
}

onMounted(() => {
	fetchData();
});
</script>
