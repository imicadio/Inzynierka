import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Biceps } from 'src/app/models/dashboard/biceps';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import * as moment from 'moment'

@Component({
  selector: 'app-modal-biceps',
  templateUrl: './modal-biceps.component.html',
  styleUrls: ['./modal-biceps.component.css']
})
export class ModalBicepsComponent implements OnInit {
  UpdateSurvey: FormGroup;
  minDateEnd = moment().format('YYYY-MM-DD');

  constructor(
    public dialogRef: MatDialogRef<ModalBicepsComponent>,
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
    this.dashboardService.updateBiceps(this.authService.decodedToken.nameid, this.data.id, this.data).subscribe(next => {
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
