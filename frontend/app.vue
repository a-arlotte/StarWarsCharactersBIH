<template>
	<v-app>
		<v-layout class="rounded rounded-md border">
			<v-app-bar title="Star Wars Application"></v-app-bar>

			<v-navigation-drawer>
				<v-list nav>
					<v-list-item link title="Home" to="/"></v-list-item>
					<v-list-item link title="Characters" to="/characters"></v-list-item>
				</v-list>
			</v-navigation-drawer>

			<v-main class="d-flex align-center justify-center" height="300">
				<v-container>
					<v-sheet height="200" rounded="lg" width="100%">
						<NuxtPage />
					</v-sheet>
				</v-container>
			</v-main>
		</v-layout>
	</v-app>
</template>
