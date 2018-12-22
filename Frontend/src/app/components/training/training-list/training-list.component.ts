import { Component, OnInit } from '@angular/core';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training/training.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-training-list',
  templateUrl: './training-list.component.html',
  styleUrls: ['./training-list.component.css']
})
export class TrainingListComponent implements OnInit {
  trainings: Training[];
  displayedColumns = ["Id", "Name", "Action"];

  constructor(private trainingService: TrainingService, private alertify: AlertifyService, public authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.loadTrainings();
  }

  loadTrainings(){
    this.trainingService.getTrainings().subscribe((trainings: Training[]) => {
      this.trainings = trainings;
      console.log(trainings);
    }, error => {
      this.alertify.error(error);
    });
  }

  deleteTraining(id: number) {
    this.trainingService.deleteTraining(id, this.authService.decodedToken.nameid).subscribe(()=>{
      this.alertify.success('Pomyślnie usunięto trening');
      this.loadTrainings();
    }, error => {
      this.alertify.error(error);      
    });
  }

}
