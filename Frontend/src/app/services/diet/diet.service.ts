import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Diet } from 'src/app/models/diet';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';
import { PagedListDto } from 'src/app/models/PagedListDto';
import { queryStringify } from '../rest.service';

@Injectable({
  providedIn: 'root'
})
export class DietService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDiets(): Observable<Diet[]>{
    return this.http.get<Diet[]>(this.baseUrl + 'Diet');
  }

  getDiet(id): Observable<Diet> {
    return this.http.get<Diet>(this.baseUrl + 'Diet/' + id);
  }

  dietList(userId:number, query: ListTrainingQuery): Observable<PagedListDto<Diet>> {
    return this.http.get<PagedListDto<Diet>>(this.baseUrl + 'Diet/Paginated?userId=' + userId + '&' + queryStringify(query)); 
   }

  addDiet(dietId: number, trainerId: number, diet: Diet) {
    return this.http.post(this.baseUrl + 'Diet?idUser=' + dietId + '&idTrainer=' + trainerId, diet);
  }

  getDietArray(id): Observable<Diet[]> {
    return this.http.get<Diet[]>(this.baseUrl + 'Diet/' + id);
  }

  deleteDiet(dietId: number, trainerId: number) {
    return this.http.delete(this.baseUrl + 'Diet/' + dietId + '?trainerId=' + trainerId);
  }
}
