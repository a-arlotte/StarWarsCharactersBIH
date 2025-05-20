<template>
	<v-card class="mx-auto" max-width="400" outlined>
		<v-card-title>{{ character.name }}</v-card-title>
		<v-card-subtitle>Gender: {{ character.gender }}</v-card-subtitle>

		<v-card-text>
			<v-list dense>
				<v-list-item>
					<v-list-item-content>
						<v-list-item-title>Height</v-list-item-title>
						<v-list-item-subtitle
							>{{ character.height }} cm</v-list-item-subtitle
						>
					</v-list-item-content>
				</v-list-item>

				<v-list-item>
					<v-list-item-content>
						<v-list-item-title>Mass</v-list-item-title>
						<v-list-item-subtitle>{{ character.mass }} kg</v-list-item-subtitle>
					</v-list-item-content>
				</v-list-item>

				<v-list-item>
					<v-list-item-content>
						<v-list-item-title>Skin Color</v-list-item-title>
						<v-list-item-subtitle>{{
							character.skin_color
						}}</v-list-item-subtitle>
					</v-list-item-content>
				</v-list-item>

				<v-list-item>
					<v-list-item-content>
						<v-list-item-title>Birth Year</v-list-item-title>
						<v-list-item-subtitle>{{
							character.birth_year
						}}</v-list-item-subtitle>
					</v-list-item-content>
				</v-list-item>
			</v-list>
		</v-card-text>
	</v-card>
</template>
  
  <script setup lang="ts">
import type { Character } from "~/models/character";

const route = useRoute();

let character = ref<Character>();

const config = useRuntimeConfig();

// having to go get the data again because I don't have an endpoint
// normally would have endpoint to get by id
// but id is being generated
async function fetchData() {
	try {
		let url = `${config.public.apiUrl}/people`;
		console.log(url);
		const res = await fetch(url);
		if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
		let apiResult = await res.json();
		// data is an array
		// get the one with the id
		character = apiResult.data.find((x) => x.id === route.params.id);
	} catch (e) {
		error.value = (e as Error).message;
	}
}

onMounted(() => {
	fetchData();
});
</script>