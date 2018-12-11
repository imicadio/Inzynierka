import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Training } from 'src/app/models/training';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTrainings(): Observable<Training[]>{
    return this.http.get<Training[]>(this.baseUrl + 'Training');
  }

  getTraining(id): Observable<Training> {
    return this.http.get<Training>(this.baseUrl + 'Training/' + id);
  }

  deleteTraining(trainingId: number, trainerId: number) {
    return this.http.delete(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId);
  }

  addTraining(trainingId: number, trainerId: number, training: Training) {
    return this.http.post(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId, training);
  }

  editTraining(trainingId: number, trainerId: number) {
    return this.http.put(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId, {});
  }

  // addUser(trainerId: number, user: User) {
  //   return this.http.post(this.baseUrl + 'Training/AddUser?id=' + trainerId, user);
  // }
}
