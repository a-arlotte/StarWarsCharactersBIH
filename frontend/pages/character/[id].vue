<template>
	<div>
		<v-progress-circular
			v-if="characterStore.loading"
			indeterminate
			color="primary"
			size="40"
		></v-progress-circular>
		<v-card v-else class="mx-auto" max-width="400" outlined>
			<div v-if="characterStore.error" style="color: red">
				{{ characterStore.error }}
			</div>
			<v-card-title>{{ character.name }}</v-card-title>
			<v-card-subtitle>Gender: {{ character.gender }}</v-card-subtitle>

			<v-card-text>
				<v-list dense>
					<v-list-item>
						<v-list-item-title>Height</v-list-item-title>
						<v-list-item-subtitle
							>{{ character.height }} cm
						</v-list-item-subtitle>
					</v-list-item>

					<v-list-item>
						<v-list-item-title>Mass</v-list-item-title>
						<v-list-item-subtitle>
							{{ character.mass }} kg
						</v-list-item-subtitle>
					</v-list-item>

					<v-list-item>
						<v-list-item-title>Skin Color</v-list-item-title>
						<v-list-item-subtitle>
							{{ character.skin_color }}
						</v-list-item-subtitle>
					</v-list-item>

					<v-list-item>
						<v-list-item-title>Birth Year</v-list-item-title>
						<v-list-item-subtitle>
							{{ character.birth_year }}
						</v-list-item-subtitle>
					</v-list-item>
				</v-list>
			</v-card-text>
		</v-card>
	</div>
</template>
  
<script setup lang="ts">
import type { Character } from "~/models/character";
import { useCharacterStore } from "~/stores/characterStore";

const characterStore = useCharacterStore();

const route = useRoute();
let character = ref<Character>({
	id: 0,
	name: "",
	height: "",
	mass: "",
	skin_color: "",
	birth_year: "",
	gender: "",
	likes: 0,
});

onMounted(async () => {
	const route = useRoute();
	await characterStore.ensureCharactersLoaded();
	character.value = characterStore.getCharacterById(Number(route.params.id));
});
</script>