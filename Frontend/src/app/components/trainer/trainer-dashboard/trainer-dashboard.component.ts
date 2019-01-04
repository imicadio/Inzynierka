import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trainer-dashboard',
  templateUrl: './trainer-dashboard.component.html',
  styleUrls: ['./trainer-dashboard.component.css']
})
export class TrainerDashboardComponent implements OnInit {
  registerMode = false;
  trainingMode = false;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
  }

  trainingToggle() { 
    this.trainingMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

  cancelTrainingMode(trainingMode: boolean) {
    this.trainingMode = trainingMode;
  }

  btnClick() {
    this.router.navigateByUrl('/training/add');
  }
}
