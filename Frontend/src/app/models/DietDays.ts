import { DietDetails } from "./DietDetails";

export interface DietDays {
    id: number;
    day: string;
    dietDetails: DietDetails[];
}