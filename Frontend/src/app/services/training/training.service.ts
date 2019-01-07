import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Training } from 'src/app/models/training';
import { User } from 'src/app/models/user';
import { PagedListDto } from 'src/app/models/PagedListDto';
import { queryStringify } from '../rest.service';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';

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

  trainingList(query: ListTrainingQuery): Observable<PagedListDto<Training>> {
   return this.http.get<PagedListDto<Training>>(this.baseUrl + 'Training/Paginated?' + queryStringify(query)); 
  }

  deleteTraining(trainingId: number, trainerId: number) {
    return this.http.delete(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId);
  }

  // addTraining(trainerId: number, training: Training) {
  //   return this.http.post(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId, training);
  // }

  editTraining(trainingId: number, trainerId: number) {
    return this.http.put(this.baseUrl + 'Training?trainingId=' + trainingId + '&trainerId=' + trainerId, {});
  }

  // addUser(trainerId: number, user: User) {
  //   return this.http.post(this.baseUrl + 'Training/AddUser?id=' + trainerId, user);
  // }
}
