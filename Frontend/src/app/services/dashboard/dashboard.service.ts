import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedListDto } from 'src/app/models/PagedListDto';
import { queryStringify } from '../rest.service';
import { ListSurveyQuery } from 'src/app/models/query/ListSurveyQuery';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { PutSurveyQuery } from 'src/app/models/query/PutSurveyQuery';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  bicepsList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Biceps?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false' + '&Ascending=false'); 
   }

  addBiceps(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/Biceps?idUser=' + userId + '&Size=' + size, {});
  }

  updateBiceps(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Biceps?userId=' + userId + '&id=' + id , biceps)
  }

  deleteBiceps(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Biceps?id=' + id + '&userId=' + userId);
  }

  bodyFatList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/BodyFat?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  addBodyFat(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/BodyFat?idUser=' + userId + '&Size=' + size, {});
  }

  updateBodyFat(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/BodyFat?userId=' + userId + '&id=' + id , biceps)
  }

  deleteBodyFat(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/BodyFat?id=' + id + '&userId=' + userId);
  }

  bodyWeightList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/BodyWeight?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
  }
   
  addBodyWeight(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/BodyWeight?idUser=' + userId + '&Size=' + size, {});
  }

  updateBodyWeight(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/BodyWeight?userId=' + userId + '&id=' + id , biceps)
  }

  deleteBodyWeight(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/BodyWeight?id=' + id + '&userId=' + userId);
  }

  calfList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Calf?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

   addCalf(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/Calf?idUser=' + userId + '&Size=' + size, {});
  }

  updateCalf(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Calf?userId=' + userId + '&id=' + id , biceps)
  }

  deleteCalf(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Calf?id=' + id + '&userId=' + userId);
  }

  chestList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Chest?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

   addChest(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/Chest?idUser=' + userId + '&Size=' + size, {});
  }

  updateChest(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Chest?userId=' + userId + '&id=' + id , biceps)
  }

  deleteChest(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Chest?id=' + id + '&userId=' + userId);
  }

  hipList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Hip?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

   addHip(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/Hip?idUser=' + userId + '&Size=' + size, {});
  }

  updateHip(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Hip?userId=' + userId + '&id=' + id , biceps)
  }

  deleteHip(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Hip?id=' + id + '&userId=' + userId);
  }

  ThighList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Thigh?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

   addThigh(userId: number, size: number) {
    return this.http.post(this.baseUrl + 'Survey/Add/Thigh?idUser=' + userId + '&Size=' + size, {});
  }

  updateThigh(userId: number, id: number, biceps: Biceps) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Thigh?userId=' + userId + '&id=' + id , biceps)
  }

  deleteThigh(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Thigh?id=' + id + '&userId=' + userId);
  }
}
