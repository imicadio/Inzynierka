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

@Component({
  selector: 'app-diet-list',
  templateUrl: './diet-list.component.html',
  styleUrls: ['./diet-list.component.css']
})
export class DietListComponent implements OnInit {
  @ViewChild('paginator') paginator: MatPaginator;
  diets = new MatTableDataSource();
  public resultLength = 0;
  private pageSize = 5;
  private actionQuery: ListTrainingQuery = new ListTrainingQuery();
  public displayedColumns = new Array<string>();

  constructor(
    private dietService: DietService,
    private alertify: AlertifyService, 
    public authService: AuthService, 
    private router: Router
  ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    this.loadDiets();
  }

  loadDiets(){
    this.paginator.pageIndex = 0;
      merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.actionQuery.PageNumber = this.paginator.pageIndex;
          this.actionQuery.Limit = this.pageSize;
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

  deleteDiet(id: number) {
    this.dietService.deleteDiet(id, this.authService.decodedToken.nameid).subscribe(()=>{
      this.alertify.success('Pomyślnie usunięto trening');
      this.loadDiets();
    }, error => {
      this.alertify.error(error);      
    });
  }

  btnClick() {
    this.router.navigateByUrl('/diets/add');
  } 
}
