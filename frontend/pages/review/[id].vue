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
				<v-btn @click="reviewStore.clearError">Dismiss</v-btn>
			</div>
			<v-form @submit.prevent ref="formRef">
				<v-app-bar-title class="ma-1 mb-3">
					{{ character.name }} Review!
				</v-app-bar-title>
				<v-text-field
					label="Your Name"
					v-model="review.name"
					:rules="rules"
				></v-text-field>
				<v-date-picker v-model="review.dateWatched"></v-date-picker>

				<v-textarea
					label="Review Details"
					v-model="review.details"
					rows="3"
					:rules="rules"
				></v-textarea>

				<v-select
					label="Rating"
					v-model="review.rating"
					:items="ratings"
					:rules="rules"
				></v-select>

				<v-btn type="submit" color="primary" @click="submit"
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

const rules = [
	(value) => {
		if (value) return true;
		return "You must enter a value.";
	},
];

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

const formRef = ref();

onMounted(async () => {
	const route = useRoute();
	await characterStore.ensureCharactersLoaded();
	character.value = characterStore.getCharacterById(Number(route.params.id));
});

// form submission
const submit = async () => {
	const { valid } = await formRef.value.validate();
	if (valid) {
		reviewStore.submitReview(review.value);
	}
};
</script>