import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Training } from 'src/app/models/training';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTrainings(): Observable<Training[]>{
    return this.http.get<Training[]>(this.baseUrl + 'Training');
  }
}
