import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrainerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addUser(trainerId: number, user: User) {
    return this.http.post(this.baseUrl + 'Trainer/AddUser?id=' + trainerId, user);
  }
}
