import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PutSurveyQuery } from 'src/app/models/query/PutSurveyQuery';

@Component({
  selector: 'app-calf-add',
  templateUrl: './calf-add.component.html',
  styleUrls: ['./calf-add.component.css']
})
export class CalfAddComponent implements OnInit {
  addSurvey: FormGroup;

  constructor(
  public dialogRef: MatDialogRef<CalfAddComponent>,
  private dashboardService: DashboardService,
  public authService: AuthService,
  private alertify: AlertifyService,
  private fb: FormBuilder
  ) { }

ngOnInit() {
  this.addSurvey = this.fb.group({
    'Size': []
  });
}

addData() {
  this.dashboardService.addCalf(this.authService.decodedToken.nameid, this.addSurvey.value.Size).subscribe(next => {
    this.alertify.success('Pomyślnie dodano');
    this.dialogRef.close();
  }, error => {
    this.alertify.error(error);
    console.log(this.addSurvey.value.Size);
  })
}

onNoClick(): void {
  this.dialogRef.close();
}
}
