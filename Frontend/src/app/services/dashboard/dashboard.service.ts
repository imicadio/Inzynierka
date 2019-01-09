import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedListDto } from 'src/app/models/PagedListDto';
import { queryStringify } from '../rest.service';
import { ListSurveyQuery } from 'src/app/models/query/ListSurveyQuery';
import { Biceps } from 'src/app/models/dashboard/biceps';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  bicepsList(userId:number, query: ListSurveyQuery): Observable<PagedListDto<Biceps>> {
    return this.http.get<PagedListDto<Biceps>>(this.baseUrl + 'Survey/Biceps?userId=' + userId + '&' + queryStringify(query)); 
   }
}
