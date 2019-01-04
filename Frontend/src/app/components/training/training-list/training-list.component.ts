import { Component, OnInit } from '@angular/core';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training/training.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-training-list',
  templateUrl: './training-list.component.html',
  styleUrls: ['./training-list.component.css']
})
export class TrainingListComponent implements OnInit {
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

  deleteTraining(id: number) {
    this.trainingService.deleteTraining(id, this.authService.decodedToken.nameid).subscribe(()=>{
      this.alertify.success('Pomyślnie usunięto trening');
      this.loadTrainings();
    }, error => {
      this.alertify.error(error);      
    });
  }

  btnClick() {
    this.router.navigateByUrl('/training/add');
  }

}
