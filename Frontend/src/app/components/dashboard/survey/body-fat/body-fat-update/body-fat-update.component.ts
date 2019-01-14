import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import * as moment from 'moment'


@Component({
  selector: 'app-body-fat-update',
  templateUrl: './body-fat-update.component.html',
  styleUrls: ['./body-fat-update.component.css']
})
export class BodyFatUpdateComponent implements OnInit {
  UpdateSurvey: FormGroup;
  minDateEnd = moment().format('YYYY-MM-DD');

  constructor(
    public dialogRef: MatDialogRef<BodyFatUpdateComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private dashboardService: DashboardService,
    public authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    ) { }

  ngOnInit() {
    console.log(this.data);
    this.UpdateSurvey = this.fb.group({
      'Size': [],
      'dateAdded': []
    });
  }

  updateData() {
    this.dashboardService.updateBodyFat(this.authService.decodedToken.nameid, this.data.id, this.data).subscribe(next => {
      this.alertify.success('Pomyślnie zaktualizowano');
      this.dialogRef.close();
      console.log(this.data);
    }, error => {
      this.alertify.error(error);
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
