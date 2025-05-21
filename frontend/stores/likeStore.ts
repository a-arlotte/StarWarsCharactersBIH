import { defineStore } from 'pinia';
import type { Character } from "~/models/character";

export const useLikeStore = defineStore('like', {
    state: (): { characters: Character[] } => ({
        characters: []
    }),
    getters: {
        getCharacterById: (state) => (id: number) => {
            return state.characters.find(x => x.id === id)
        }
    },
    actions: {
        likeCharacter(id: number) {
            const index = this.characters.findIndex(x => x.id === id);
            if (index !== -1) {
                this.characters[index].likes += 1;
            }
        },
        dislikeCharacter(id: number) {
            const index = this.characters.findIndex(x => x.id === id);
            if (index !== -1) {
                this.characters[index].likes -= 1;
            }
        },

    }
})