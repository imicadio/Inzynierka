import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { User } from 'src/app/models/user';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TrainerService } from 'src/app/services/trainer/trainer.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  userForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private authService: AuthService, 
    private trainerService: TrainerService, 
    private alertify: AlertifyService, 
    private fb: FormBuilder, 
    private router: Router
    ) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
    this.createUserForm();
  }

  createUserForm() {
    this.userForm = this.fb.group({
      gender: ['male'],
      username: ['', Validators.required],      
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  register() {
    if (this.userForm.valid) {
      this.user = Object.assign({}, this.userForm.value);
      this.trainerService.addUser(this.authService.decodedToken.nameid, this.user).subscribe(() => {
        this.alertify.success('Registration succesfull');
      }, error => {
        this.alertify.error(error);      
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
