import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training/training.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { merge, Observable, of as observableOf } from 'rxjs';
import { startWith, switchMap, map, catchError, count } from 'rxjs/operators';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';


@Component({
  selector: 'app-training-user',
  templateUrl: './training-user.component.html',
  styleUrls: ['./training-user.component.css']
})
export class TrainingUserComponent implements OnInit {
  value = '';
  //////////// With Pagination ////////////////
  @ViewChild('paginator') paginator: MatPaginator;
  trainings1 = new MatTableDataSource();
  public resultLengthTraining = 0;
  private pageSize = 5;
  private actionQuery: ListTrainingQuery = new ListTrainingQuery();
  private sortAscending = true;
  private filterValuets: string = "";
  test = 'true';
  private userId: number;
  /////////////////////////////////////////////

  trainings: Training[];    
  public displayedColumns = new Array<string>();

  constructor(
    private trainingService: TrainingService, 
    private alertify: AlertifyService, 
    public authService: AuthService, 
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.userId = id;
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
    console.log('pagination training: ' + this.sortAscending);
    this.paginator.pageIndex = 0;
      merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.actionQuery.PageNumber = this.paginator.pageIndex;
          this.actionQuery.Limit = this.pageSize;
          this.actionQuery.Query = this.filterValuets;   
          this.actionQuery.Ascending = this.sortAscending;
          return this.trainingService.trainingList(this.userId, this.actionQuery);
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

  applyFilter(filterValue: string) {
    console.log('applyfilter: ' + this.sortAscending);
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.filterValuets = filterValue;
    this.paginationTraining();
  }

  changeClient(sort) {       
    this.sortAscending = sort;   
    this.paginationTraining();
  }

  btnClick() {
    this.router.navigateByUrl('/training/add');
  } 
}
