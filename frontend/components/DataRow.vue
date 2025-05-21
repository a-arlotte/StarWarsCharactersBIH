<template>
	<tr>
		<td>{{ props.item.name }}</td>
		<td>{{ props.item.likes }}</td>
		<td>
			<v-btn variant="text" :to="`/character/${props.item.id}`">View</v-btn>
		</td>
		<td>
			<v-btn variant="text" :to="`/review/${props.item.id}`">Review</v-btn>
		</td>
		<td>
			<v-btn variant="text" :click="likeStore.likeCharacter(props.item.id)"
				>Like</v-btn
			>
		</td>
		<td>
			<v-btn variant="text" :click="likeStore.dislikeCharacter(props.item?.id)"
				>Dislike</v-btn
			>
		</td>
	</tr>
</template>
  
<script setup lang="ts">
import type { PropType } from "vue";
import type { Character } from "~/models/character";
import { useLikeStore } from "~/stores/likeStore";

const likeStore = useLikeStore();

const props = defineProps({
	item: Object as PropType<Character>,
});
</script>