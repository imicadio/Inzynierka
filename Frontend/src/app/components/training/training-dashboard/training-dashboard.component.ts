import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';
import { merge, Observable, of as observableOf } from 'rxjs';
import { startWith, switchMap, map, catchError, count } from 'rxjs/operators';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';
import * as moment from 'moment';
import { TrainingService } from 'src/app/services/training/training.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { Training } from 'src/app/models/training';

@Component({
  selector: 'app-training-dashboard',
  templateUrl: './training-dashboard.component.html',
  styleUrls: ['./training-dashboard.component.css']
})
export class TrainingDashboardComponent implements OnInit {
  value = '';
  //////////// With Pagination ////////////////
  @ViewChild('paginator') paginator: MatPaginator;
  trainings1 = new MatTableDataSource();
  public resultLengthTraining = 0;
  private pageSize = 5;
  private actionQuery: ListTrainingQuery = new ListTrainingQuery();
  /////////////////////////////////////////////

  trainings: Training[];    
  public displayedColumns = new Array<string>();

  constructor(
    private trainingService: TrainingService, 
    public authService: AuthService, 
    private router: Router
    ) {}

  ngOnInit() {
    this.fillTableColumnNames();
    this.paginationTraining();    
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

  paginationTraining(){
    console.log(moment().add(7, 'days').format("YYYY-MM-DD"));
    console.log();
    this.paginator.pageIndex = 0;
      merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.actionQuery.PageNumber = this.paginator.pageIndex;
          this.actionQuery.Limit = this.pageSize; 
          this.actionQuery.PresentDay = moment().format("YYYY-MM-DD");
          this.actionQuery.EndDay = moment().add(7, 'days').format("YYYY-MM-DD");
          return this.trainingService.trainingList(this.authService.decodedToken.nameid, this.actionQuery);
        }),
        map(data => {         
          this.resultLengthTraining = data.object.count;
        //  console.log(data.object.count);
          return data.object;
        }),
        catchError((error) => {
          return observableOf([]);
        })
      ).subscribe((data: Training[]) => {
        this.trainings1.data = data;
        // console.log(this.resultLengthTraining);
      }); 
  }  

  updateState(event: PageEvent) {
    this.pageSize = event.pageSize;
  }

  btnClick() {
    this.router.navigateByUrl('/training/add');
  } 
}
