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

  updateBiceps(userId: number, id: number, query: PutSurveyQuery) {
    return this.http.put(this.baseUrl + 'Survey/Edit/Biceps?userId=' + userId + '&id=' + id + '&' + queryStringify(query) , {})
  }

  deleteBiceps(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Biceps?id=' + id + '&userId=' + userId);
  }

  bodyFatList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/BodyFat?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteBodyFat(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/BodyFat?id=' + id + '&userId=' + userId);
  }

  bodyWeightList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/BodyWeight?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteBodyWeight(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/BodyWeight?id=' + id + '&userId=' + userId);
  }

  calfList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Calf?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteCalf(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Calf?id=' + id + '&userId=' + userId);
  }

  chestList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Chest?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteChest(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Chest?id=' + id + '&userId=' + userId);
  }

  hipList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Hip?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteHip(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Hip?id=' + id + '&userId=' + userId);
  }

  ThighList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Thigh?userId=' + userId + '&' + queryStringify(query) + '&Ascending=false'); 
   }

  deleteThigh(id: number, userId: number) {
    return this.http.delete(this.baseUrl + 'Survey/Delete/Thigh?id=' + id + '&userId=' + userId);
  }
}
