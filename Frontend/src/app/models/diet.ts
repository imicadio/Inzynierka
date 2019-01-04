import { DietDays } from "./DietDays";

export interface Diet {
    id: number;
    name: string;
    dietDays: DietDays[];
}