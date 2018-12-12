import { ExerciseTrainings } from "./ExerciseTrainings";

export interface TrainingDays {
    id: number;
    day: string;
    exerciseTraining: ExerciseTrainings[];
}