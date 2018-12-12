import { Series } from "./Series";

export interface ExerciseTrainings {
    id: number;
    name: string;
    description: string;
    serie: Series[];
}