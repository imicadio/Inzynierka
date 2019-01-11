import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-body-weight-update',
  templateUrl: './body-weight-update.component.html',
  styleUrls: ['./body-weight-update.component.css']
})
export class BodyWeightUpdateComponent implements OnInit {
  UpdateSurvey: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<BodyWeightUpdateComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private dashboardService: DashboardService,
    public authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder
    ) { }

  ngOnInit() {
    console.log(this.data);
    this.UpdateSurvey = this.fb.group({
      'Size': [],
      'dateAdded': []
    });
  }

  updateData() {
    this.dashboardService.updateBodyWeight(this.authService.decodedToken.nameid, this.data.id, this.data).subscribe(next => {
      this.alertify.success('Pomyślnie zaktualizowano');
      this.dialogRef.close();
    }, error => {
      this.alertify.error(error);
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
