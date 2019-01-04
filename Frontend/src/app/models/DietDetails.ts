import { DietProducts } from "./DietProducts";

export interface DietDetails {
    id: number;
    meal: string;
    hour: Date;
    dish: string;
    recipe: string;
    comments: string;
    dietProducts: DietProducts[];
}