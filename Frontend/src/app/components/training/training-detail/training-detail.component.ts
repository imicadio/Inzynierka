import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training/training.service';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-training-detail',
  templateUrl: './training-detail.component.html',
  styleUrls: ['./training-detail.component.css']
})
export class TrainingDetailComponent implements OnInit {

  training: Training;

  constructor(private trainingService: TrainingService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    // this.route.data.subscribe(data => {
    //   this.training = data['training'];
    //   console.log(data['training']);
    // });
    // console.log(this.training);
    this.getTraining();
  }

  getTraining() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.trainingService.getTraining(id).subscribe((training: Training) => {
      this.training = training;
      console.log(training);
    }, error => {
      this.alertify.error(error);
    });
    // console.log(this.training);
  }

}
