import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'Users/' + id);
  }

  getPupils(id): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'Trainer/GetPupils?id=' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUrl + 'Users/' + id, user);
  }

  setMainPhoto(userId: number, id: number) {
    return this.http.post(this.baseUrl + 'users/' + userId + '/photos/' + id + '/setMain', {});
  }

  deletePhoto(userId: number, id: number) {
    return this.http.delete(this.baseUrl + 'users/' + userId + '/photos/' + id);
  }
}
