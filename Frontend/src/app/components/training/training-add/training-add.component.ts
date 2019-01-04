import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Training } from 'src/app/models/training';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { TrainerService } from 'src/app/services/trainer/trainer.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models/user';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-training-add',
  templateUrl: './training-add.component.html',
  styleUrls: ['./training-add.component.css']
})
export class TrainingAddComponent implements OnInit {
  @Output() cancelTraining = new EventEmitter();
  myForm: FormGroup;    // inicjalizacja formularza
  pupils: User[];
  selection: number;
  selectionControl = new FormControl('', [Validators.required]);
 
  constructor(
    private trainerService: TrainerService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.initForm();
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getPupils(this.authService.decodedToken.nameid).subscribe((pupils: User[]) => {
      this.pupils = pupils;
      console.log(pupils);
    }, error => {
      this.alertify.error(error);
    })
  }

  initForm() {
    this.myForm = this.fb.group({
      'name': [],
      'dateStart': [],
      'dateEnd': [],
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
      'unit': ['powt.']
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

  deleteY(ix, iy) {
    const control = (<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray;
    control.removeAt(iy);
  }

  deleteZ(ix, iy, iz) {
    const control = ((<FormArray>this.myForm.controls['trainingDayBindingModels']).at(ix).get('exerciseTrainingBindingModels') as FormArray).at(iy).get('serieBindingModels') as FormArray;
    control.removeAt(iz);
  }

  drop1(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('trainingDayBindingModels')['controls'], event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('trainingDayBindingModels').value, event.previousIndex, event.currentIndex);
  }  

  drop2(ix, event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels').controls, event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels').value, event.previousIndex, event.currentIndex);
  }  

  drop3(ix, iy, event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('serieBindingModels').controls, event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('serieBindingModels').value, event.previousIndex, event.currentIndex);
    console.log(ix);
  }  

  activeNote: string;
  enter1(ix) {
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('day').value;
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('typeOfTraining').value;    
  }

  enter2(ix, iy) {
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('name').value;
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('description').value;
  }

  enter3(ix, iy, iz) {
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('serieBindingModels')['controls'][iz].get('number').value;
    this.activeNote = this.myForm.get('trainingDayBindingModels')['controls'][ix].get('exerciseTrainingBindingModels')['controls'][iy].get('serieBindingModels')['controls'][iz].get('unit').value;
  }

  onSubmit() {
    this.trainerService.addTraining(this.selection.valueOf(), this.authService.decodedToken.nameid, this.myForm.value).subscribe(() => {
      this.alertify.success('Pomyślnie dodano nowy trening!');
      // console.log('zaznaczono użytkownika o id' + this.selection.valueOf());
    }, error => {
      this.alertify.error(error);      
    });
    console.log(this.myForm.value);
  }

  cancel() {
    this.cancelTraining.emit(false);
  }
}
