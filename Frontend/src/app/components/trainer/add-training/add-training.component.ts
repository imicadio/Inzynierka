import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Training } from 'src/app/models/training';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { TrainerService } from 'src/app/services/trainer/trainer.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-training',
  templateUrl: './add-training.component.html',
  styleUrls: ['./add-training.component.css']
})
export class AddTrainingComponent implements OnInit {
  @Output() cancelTraining = new EventEmitter();
  myForm: FormGroup;    // inicjalizacja formularza
 
  constructor(
    private trainerService: TrainerService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.myForm = this.fb.group({
      'name': [],
      'trainingDayBindingModels': this.fb.array([
        this.addTrainingDay()
      ])
    });
  }
  
  // initX() 
  // inicjalizacja pierwszej tabeli 'Dni Treningowe'
  addTrainingDay() {
    return this.fb.group({
      'day': [],
      'typeOfTraining': [],
      'exerciseTrainingBindingModels': this.fb.array([
        this.addExercise()
      ])
    });
  }  

  // initY()
  // inicjalizacja drugiej tabeli 'Exercise training'
  addExercise() {
    return this.fb.group({
      'name': [],
      'description': [],
      'serieBindingModels': this.fb.array([
        this.addSerie()
      ])
    });
  }

  // addZ()
  // inicjalizacja trzeciej tabeli 'Series'
  addSerie() {
    return this.fb.group({
      'serialNumber': [],
      'number': [],
      'unit': []
    });
  }

  addX() {
    const control = <FormArray>this.myForm.controls['trainingDayBindingModels'];
    control.push(this.addTrainingDay());
  }

  addY(ix) {
    const control = (<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray;
    control.push(this.addExercise());
  }

  addZ(ix ,iy) {
    const control = ((<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray).at(iy).get('serieBindingModels') as FormArray;
    control.push(this.addSerie());
  }

  deleteX(ix) {
    const control = (<FormArray>this.myForm.controls['trainingDayBindingModels']);
    control.removeAt(ix);
  }

  deleteY(ix) {
    const control = (<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray;
    control.removeAt(ix);
  }

  deleteZ(ix, iy) {
    const control = ((<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray).at(iy).get('serieBindingModels') as FormArray;
    control.removeAt(iy);
  }

  onSubmit() {
    this.trainerService.addTraining(3, this.authService.decodedToken.nameid, this.myForm.value).subscribe(() => {
      this.alertify.success('Pomyślnie dodano nowy trening!');
    }, error => {
      this.alertify.error(error);      
    });
    console.log(this.myForm.value);
  }

  cancel() {
    this.cancelTraining.emit(false);
  }
}
