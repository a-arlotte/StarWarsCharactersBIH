<template>
	<tr>
		<td>{{ props.item.name }}</td>
		<td>{{ props.item.mass }}</td>
		<td>
			<v-btn icon @click="$emit('view', props.item)">
				<v-icon>mdi-eye</v-icon>
			</v-btn>
		</td>
	</tr>
</template>
  
<script setup lang="ts">
import type { PropType } from "vue";
import type { Character } from "~/models/character";

const props = defineProps({
	item: Object as PropType<Character>,
});

defineEmits(["view"]);
</script>