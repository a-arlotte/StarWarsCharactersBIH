import { defineStore } from 'pinia';
import type { Review } from "~/models/review";

interface State {
    review: Review[],
    loading: boolean,
    error: string | null
}

export const useReviewStore = defineStore('review', {
    state: (): State => ({
        reviews: [],
        loading: false,
        error: null
    }),
    actions: {
        async submitReview(review: Review) {
            try {
                clearError();
                var config = useRuntimeConfig();

                let url = `${config.public.apiUrl}/review`;
                console.log(url);
                const res = await fetch(url, {
                    method: "Post"
                });
                if (!res.ok) throw new Error("There has been an error sending this review. Please try again")
                let apiResult = await res.json();
                // assume it returns a review type
                this.review.push(apiResult);
            } catch (e) {
                this.error = (e as Error).message;
            }
        },
        clearError() {
            // reset error
            this.error = null;
        }
    }
})