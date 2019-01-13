import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models/user';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';
import * as moment from 'moment'
import { CurrentSurvey } from 'src/app/models/currentSurvey';
import { DietService } from 'src/app/services/diet/diet.service';

@Component({
  selector: 'app-diet-add',
  templateUrl: './diet-add.component.html',
  styleUrls: ['./diet-add.component.css']
})
export class DietAddComponent implements OnInit {
  myForm: FormGroup;    // inicjalizacja formularza
  pupils: User[];
  user: User;
  currentSurveys: CurrentSurvey[];
  selection: number;
  minDateStart = moment().format('YYYY-MM-DD');
  minDateEnd = moment().add(3, 'days').format("YYYY-MM-DD");
  selectionControl = new FormControl('', [Validators.required]);
  dayControl = new FormControl('', [Validators.required]);

  daysWeek = [
    {value: 'Poniedziałek', viewValue: 'Poniedziałek'},
    {value: 'Wtorek', viewValue: 'Wtorek'},
    {value: 'Środa', viewValue: 'Środa'},
    {value: 'Czwartek', viewValue: 'Czwartek'},
    {value: 'Piątek', viewValue: 'Piątek'},
    {value: 'Sobota', viewValue: 'Sobota'},
    {value: 'Niedziela', viewValue: 'Niedziela'}
  ];

  constructor(
    private dietService: DietService,
    private authService: AuthService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.initForm();
    this.loadUsers();
  }

  changePupil(event) {
    this.userService.getUser(event.value).subscribe((user: User) => {
      this.user = user;
      console.log(user);
    }, error => {
      this.alertify.error(error);
    });

    this.userService.getCurrentSurveys(event.value).subscribe((currentSurvey: CurrentSurvey[]) => {
      this.currentSurveys = currentSurvey;
      // console.log(this.currentSurveys);
    }, error => {
      this.alertify.error(error);
    });
  }

  loadUsers() {
    this.userService.getPupils(this.authService.decodedToken.nameid).subscribe((pupils: User[]) => {
      this.pupils = pupils;
      // console.log(pupils);
    }, error => {
      this.alertify.error(error);
    })
  }

  initForm() {
    this.myForm = this.fb.group({
      'name': [],
      'dateStart': [],
      'dateEnd': [],
      'dietDayBindingModels': this.fb.array([
        this.addDietDay()
      ])
    });
  }
  
  // initX() 
  // inicjalizacja pierwszej tabeli 'Dni Treningowe'
  addDietDay() {
    return this.fb.group({
      'name': [],
      'dietDetailBindingModels': this.fb.array([
        this.addDietDetail()
      ])
    });
  }  

  // initY()
  // inicjalizacja drugiej tabeli 'Exercise training'
  addDietDetail() {
    return this.fb.group({
      'meal': [],
      'hour': [],
      'dish': [],
      'recipe': [],
      'comments': [],
      'dietProductBindingModels': this.fb.array([
        this.addDietProduct()
      ])
    });
  }

  // addZ()
  // inicjalizacja trzeciej tabeli 'Series'
  addDietProduct() {
    return this.fb.group({
      'quantity': [],
      'name': [],
      'homeMeasure': []
    });
  }

  addX() {
    const control = <FormArray>this.myForm.controls['dietDayBindingModels'];
    control.push(this.addDietDay());
  }

  addY(ix) {
    const control = (<FormArray>this.myForm.controls['dietDayBindingModels']).at(ix).get('dietDetailBindingModels') as FormArray;
    control.push(this.addDietDetail());
  }

  addZ(ix ,iy) {
    const control = ((<FormArray>this.myForm.controls['dietDayBindingModels']).at(ix).get('dietDetailBindingModels') as FormArray).at(iy).get('dietProductBindingModels') as FormArray;
    control.push(this.addDietProduct());
  }

  deleteX(ix) {
    const control = (<FormArray>this.myForm.controls['dietDayBindingModels']);
    control.removeAt(ix);
  }

  deleteY(ix, iy) {
    const control = (<FormArray>this.myForm.controls['dietDayBindingModels']).at(ix).get('dietDetailBindingModels') as FormArray;
    control.removeAt(iy);
  }

  deleteZ(ix, iy, iz) {
    const control = ((<FormArray>this.myForm.controls['dietDayBindingModels']).at(ix).get('dietDetailBindingModels') as FormArray).at(iy).get('dietProductBindingModels') as FormArray;
    control.removeAt(iz);
  }

  drop1(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('dietDayBindingModels')['controls'], event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('dietDayBindingModels').value, event.previousIndex, event.currentIndex);
  }  

  drop2(ix, event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels').controls, event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels').value, event.previousIndex, event.currentIndex);
  }  

  drop3(ix, iy, event: CdkDragDrop<string[]>) {
    moveItemInArray(this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dietProductBindingModels').controls, event.previousIndex, event.currentIndex);
    moveItemInArray(this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dietProductBindingModels').value, event.previousIndex, event.currentIndex);
    console.log(ix);
  }  

  activeNote: string;
  enter1(ix) {
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('name').value;  
  }

  enter2(ix, iy) {
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('meal').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('hour').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dish').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('recipe').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('comments').value;
  }

  enter3(ix, iy, iz) {
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dietProductBindingModels')['controls'][iz].get('quantity').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dietProductBindingModels')['controls'][iz].get('name').value;
    this.activeNote = this.myForm.get('dietDayBindingModels')['controls'][ix].get('dietDetailBindingModels')['controls'][iy].get('dietProductBindingModels')['controls'][iz].get('homeMeasure').value;
  }

  onSubmit() {
    this.dietService.addDiet(this.selection.valueOf(), this.authService.decodedToken.nameid, this.myForm.value).subscribe(() => {
      this.alertify.success('Pomyślnie dodano nowy plan dietetyczny!');
      // console.log('zaznaczono użytkownika o id' + this.selection.valueOf());
    }, error => {
      this.alertify.error(error);      
    });
    console.log(this.myForm.value);
  }
}
