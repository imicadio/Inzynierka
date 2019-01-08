import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, PageEvent } from '@angular/material';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training/training.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { merge, Observable, of as observableOf } from 'rxjs';
import { startWith, switchMap, map, catchError, count } from 'rxjs/operators';
import { ListTrainingQuery } from 'src/app/models/query/ListTrainingQuery';


@Component({
  selector: 'app-training-list',
  templateUrl: './training-list.component.html',
  styleUrls: ['./training-list.component.css']
})
export class TrainingListComponent implements OnInit {
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
    private alertify: AlertifyService, 
    public authService: AuthService, 
    private userService: UserService,
    private router: Router
    ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    // this.loadTrainings();
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
    this.paginator.pageIndex = 0;
      merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.actionQuery.PageNumber = this.paginator.pageIndex;
          this.actionQuery.Limit = this.pageSize;
          return this.trainingService.trainingList(this.authService.decodedToken.nameid, this.actionQuery);
        }),
        map(data => {         
          this.resultLengthTraining = data.object.count;
         console.log(data.object.count);
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
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.paginator.pageIndex = 0;
     merge(this.paginator.page)
     .pipe(
       startWith({}),
       switchMap(() => {
         this.actionQuery.PageNumber = this.paginator.pageIndex;
         this.actionQuery.Limit = this.pageSize;
         this.actionQuery.Query = filterValue;
         return this.trainingService.trainingList(this.authService.decodedToken.nameid, this.actionQuery);
       }),
       map(data => {         
         this.resultLengthTraining = data.object.count;
        //  console.log(data.object.totalPageCount);
         return data.object;
       }),
       catchError((error) => {
         return observableOf([]);
       })
     ).subscribe((data: Training[]) => {
       this.trainings1.data = data;
       console.log(this.resultLengthTraining);
      }); 
  }

  btnClick() {
    this.router.navigateByUrl('/training/add');
  } 
   
  ///////////////////////// not pagination /////////////////////////
  // loadTrainings(){
  //   this.trainingService.getTrainings().subscribe((trainings: Training[]) => {
  //     this.trainings = trainings;
  //     console.log(trainings);
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }    

  // deleteTraining(id: number) {
  //   this.trainingService.deleteTraining(id, this.authService.decodedToken.nameid).subscribe(()=>{
  //     this.alertify.success('Pomyślnie usunięto trening');
  //     this.loadTrainings();
  //   }, error => {
  //     this.alertify.error(error);      
  //   });
  // } 

  ///////////////////////////////////////////////////////////////////////////
}
