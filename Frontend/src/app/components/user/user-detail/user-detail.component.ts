import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { UserService } from 'src/app/services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { User } from 'src/app/models/user';
import { CurrentSurvey } from 'src/app/models/currentSurvey';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  user: User;
  currentSurveys: CurrentSurvey[];
  
  constructor(
    private alertify: AlertifyService,
    private userService: UserService, 
    private authService: AuthService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.userService.getUser(id).subscribe((user: User) => {
      this.user = user;
      console.log(user);
    }, error => {
      this.alertify.error(error);
    });

    this.userService.getCurrentSurveys(id).subscribe((currentSurvey: CurrentSurvey[]) => {
      this.currentSurveys = currentSurvey;
      console.log(this.currentSurveys);
    }, error => {
      this.alertify.error(error);
    });
  }

}
