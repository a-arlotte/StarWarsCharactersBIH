<template>
	<tr>
		<td>{{ item.name }}</td>
		<td>{{ item.email }}</td>
		<td>
			<v-btn icon @click="$emit('view', item)">
				<v-icon>mdi-eye</v-icon>
			</v-btn>
			<v-btn icon @click="$emit('edit', item)">
				<v-icon>mdi-pencil</v-icon>
			</v-btn>
		</td>
	</tr>
</template>
  
<script setup>
defineProps({
	item: Object,
});
defineEmits(["view", "edit"]);
</script>