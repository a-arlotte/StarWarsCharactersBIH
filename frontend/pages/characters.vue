<template>
	<div>
		<h2>Star Wars Character List</h2>
		<div v-if="characterStore.error" style="color: red">
			{{ characterStore.error }}
		</div>
		<CharacterList :items="characterStore.characters" />
	</div>
</template>

<script setup lang="ts">
import { useCharacterStore } from "~/stores/characterStore";

const characterStore = useCharacterStore();

onMounted(() => {
	characterStore.fetchData();
});
</script>
