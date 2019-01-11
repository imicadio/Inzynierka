import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource, PageEvent, MatDialog } from '@angular/material';
import { ListSurveyQuery } from 'src/app/models/query/ListSurveyQuery';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { merge, of as observableOf } from 'rxjs';
import { startWith, switchMap, map, catchError } from 'rxjs/operators';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { HipUpdateComponent } from '../hip-update/hip-update.component';
import { HipAddComponent } from '../hip-add/hip-add.component';

@Component({
  selector: 'app-hip-list',
  templateUrl: './hip-list.component.html',
  styleUrls: ['./hip-list.component.css']
})
export class HipListComponent implements OnInit {
  @ViewChild('paginator') paginator: MatPaginator;
  surveyData = new MatTableDataSource();
  public resultLength = 0;
  private pageSize = 5;
  private listQuery: ListSurveyQuery = new ListSurveyQuery();
  public displayedColumns = new Array<string>();

  constructor(
    private dashboardService: DashboardService,
    private alertify: AlertifyService,
    public authService: AuthService,
    private router: Router,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    this.loadData();
  }

  public fillTableColumnNames(): void {
    this.displayedColumns.push('Rozmiar');    
    this.displayedColumns.push('Data Dodania');    
    this.displayedColumns.push('Akcje');   
  }

  public loadData() {
    this.paginator.pageIndex = 0;
    merge(this.paginator.page)
    .pipe(
      startWith({}),
      switchMap(() => {
        this.listQuery.PageNumber = this.paginator.pageIndex;
        this.listQuery.Limit = this.pageSize;
        return this.dashboardService.hipList(this.authService.decodedToken.nameid, this.listQuery);
      }),
      map(data => {         
        this.resultLength = data.object.count;
      //  console.log(data.object.count);
        return data.object;
      }),
      catchError((error) => {
        return observableOf([]);
      })
    ).subscribe((data: Biceps[]) => {
      this.surveyData.data = data;
      // console.log(data);
    }); 
  }

  updateState(event: PageEvent) {
    this.pageSize = event.pageSize;
  }  

  deleteSurvey(id: number) {
    this.dashboardService.deleteHip(id, this.authService.decodedToken.nameid).subscribe(()=>{
      this.alertify.success('Pomyślnie usunięto pomiar tkanki tłuszczowej');
      this.loadData();
    }, error => {
      this.alertify.error(error);      
    });
  }

  editSurvey(element) {
    const dialogRef = this.dialog.open(HipUpdateComponent, {
      width: '450px',
      data: element
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadData();
    });
  }

  addSurvey() {
    const dialogRef = this.dialog.open(HipAddComponent, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadData()
    });
  }
}
