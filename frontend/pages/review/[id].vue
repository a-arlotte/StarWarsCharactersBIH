<template>
	<div>
		<v-progress-circular
			v-if="reviewStore.loading"
			indeterminate
			color="primary"
			size="40"
		></v-progress-circular>
		<v-container v-else>
			<div v-if="reviewStore.error" style="color: red">
				{{ reviewStore.error }}
			</div>
			<v-form ref="reviewForm">
				<v-app-bar-title class="ma-1 mb-3">
					{{ character.name }} Review!
				</v-app-bar-title>
				<v-text-field
					label="Your Name"
					v-model="review.name"
					required
				></v-text-field>
				<v-date-picker v-model="review.dateWatched"></v-date-picker>

				<v-textarea
					label="Review Details"
					v-model="review.details"
					rows="3"
				></v-textarea>

				<v-select
					label="Rating"
					v-model="review.rating"
					:items="ratings"
				></v-select>

				<v-btn color="primary" @click="reviewStore.submitReview"
					>Submit Review</v-btn
				>
			</v-form>
		</v-container>
	</div>
</template>

  
<script setup lang="ts">
import type { Review } from "~/models/review";
import { useReviewStore } from "~/stores/reviewStore";

import type { Character } from "~/models/character";
import { useCharacterStore } from "~/stores/characterStore";

const characterStore = useCharacterStore();
const reviewStore = useReviewStore();

const ratings = Array.from({ length: 10 }, (_, i) => i + 1);

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

let review = ref<Review>({
	name: "",
	dateWatched: "",
	details: "",
	rating: null,
});

onMounted(async () => {
	const route = useRoute();
	await characterStore.ensureCharactersLoaded();
	character.value = characterStore.getCharacterById(Number(route.params.id));
});
</script>