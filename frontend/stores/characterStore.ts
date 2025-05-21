import { defineStore } from 'pinia';
import { useRuntimeConfig } from 'nuxt/app';
import type { Character } from "~/models/character";

interface State {
    characters: Character[],
    loading: boolean,
    error: string | null
}

export const useCharacterStore = defineStore('character', {
    state: (): State => ({
        characters: [],
        loading: false,
        error: null
    }),
    getters: {
        getCharacterById: (state) => (id: number) => {
            console.log(state.characters);
            console.log(id);
            return state.characters.find(x => x.id === id) || null;
        }
    },
    actions: {
        async fetchData() {
            try {
                let config = useRuntimeConfig();
                let url = `${config.public.apiUrl}/people`;
                console.log(url);
                const res = await fetch(url);
                if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
                let apiResult = await res.json();
                this.characters = apiResult.data;
            } catch (e) {
                this.error = (e as Error).message;
            }
        },
        async ensureCharactersLoaded() {
            if (this.characters.length === 0) {
                console.log("fetching characters");
                await this.fetchData();
            }
        },
        likeCharacter(id: number) {
            console.log("Like Character clicked");
            const index = this.characters.findIndex(x => x.id === id);
            if (index !== -1) {
                this.characters[index].likes++;
            }
        },
        dislikeCharacter(id: number) {
            console.log("Dislike Character clicked");
            const index = this.characters.findIndex(x => x.id === id);
            if (index !== -1) {
                this.characters[index].likes--;
            }
        },

    }
})