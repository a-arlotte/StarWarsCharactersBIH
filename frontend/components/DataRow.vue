<template>
	<tr>
		<td>{{ props.item.name }}</td>
		<td>{{ props.item.mass }}</td>
		<td>
			<v-btn variant="text" :to="`/character/${props.item.id}`">View</v-btn>
		</td>
	</tr>
</template>
  
<script setup lang="ts">
import type { PropType } from "vue";
import type { Character } from "~/models/character";

const props = defineProps({
	item: Object as PropType<Character>,
});
</script>