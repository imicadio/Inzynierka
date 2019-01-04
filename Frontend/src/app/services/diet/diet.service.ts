import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Diet } from 'src/app/models/diet';

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

  getDietArray(id): Observable<Diet[]> {
    return this.http.get<Diet[]>(this.baseUrl + 'Diet/' + id);
  }

  deleteDiet(dietId: number, trainerId: number) {
    return this.http.delete(this.baseUrl + 'Diet/' + dietId + '?trainerId=' + trainerId);
  }
}
