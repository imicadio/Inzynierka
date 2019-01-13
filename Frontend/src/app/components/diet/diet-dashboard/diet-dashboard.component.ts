import { Component, OnInit, ViewChild } from '@angular/core';
import { Diet } from 'src/app/models/diet';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { DietService } from 'src/app/services/diet/diet.service';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';
import { merge, Observable, of as observableOf } from 'rxjs';
import { startWith, switchMap, map, catchError, count } from 'rxjs/operators';
import * as moment from 'moment';


@Component({
  selector: 'app-diet-dashboard',
  templateUrl: './diet-dashboard.component.html',
  styleUrls: ['./diet-dashboard.component.css']
})
export class DietDashboardComponent implements OnInit {
  @ViewChild('paginator') paginator: MatPaginator;
  diets = new MatTableDataSource();
  public resultLength = 0;
  private pageSize = 5;
  private actionQuery: ListTrainingQuery = new ListTrainingQuery();
  public displayedColumns = new Array<string>();

  constructor(
    private dietService: DietService,
    public authService: AuthService, 
    private router: Router
  ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    this.loadDiets();
  }

  public fillTableColumnNames(): void {
    this.displayedColumns.push('Id');
    this.displayedColumns.push('Name');
    if (this.authService.decodedToken.role == 'Trainer') {
      this.displayedColumns.push('Podopieczny');
    }
    this.displayedColumns.push('Data Rozpoczęcia');
    this.displayedColumns.push('Data Zakończenia');
    this.displayedColumns.push('Akcje');
  }

  loadDiets(){
    this.paginator.pageIndex = 0;
      merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.actionQuery.PageNumber = this.paginator.pageIndex;
          this.actionQuery.Limit = this.pageSize;
          this.actionQuery.PresentDay = moment().format("YYYY-MM-DD");
          this.actionQuery.EndDay = moment().add(7, 'days').format("YYYY-MM-DD");
          return this.dietService.dietList(this.authService.decodedToken.nameid, this.actionQuery);
        }),
        map(data => {         
          this.resultLength = data.object.count;
          return data.object;
        }),
        catchError((error) => {
          return observableOf([]);
        })
      ).subscribe((data: Diet[]) => {
        this.diets.data = data;
      }); 
  }  

  updateState(event: PageEvent) {
    this.pageSize = event.pageSize;
  }

  btnClick() {
    this.router.navigateByUrl('/diets/add');
  } 

}
