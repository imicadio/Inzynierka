import { ExerciseTrainings } from "./ExerciseTrainings";
import { TrainingDays } from "./TrainingDays";

export interface Training {
    id: number;
    name: string;
    trainingDays: TrainingDays[];
}