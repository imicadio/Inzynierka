import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { TrainerService } from 'src/app/services/trainer/trainer.service';
import { User } from 'src/app/models/user';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-pupil-list',
  templateUrl: './pupil-list.component.html',
  styleUrls: ['./pupil-list.component.css']
})
export class PupilListComponent implements OnInit {
  public displayedColumns = new Array<string>();
  pupils: User[];

  constructor(
    private trainerService: TrainerService,
    private alertify: AlertifyService, 
    public authService: AuthService, 
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    this.loadPupils(); 
  }

  loadPupils(){
    this.trainerService.getPupils(this.authService.decodedToken.nameid).subscribe((pupils: User[]) => {
      this.pupils = pupils;
      console.log(pupils);
    }, error => {
      this.alertify.error(error);
    });
  }  

  public fillTableColumnNames(): void {
    this.displayedColumns.push('Id');
    this.displayedColumns.push('Nazwa');   
    this.displayedColumns.push('Wiek');
    this.displayedColumns.push('Miasto');  
    this.displayedColumns.push('Dołączył');
    this.displayedColumns.push('Ostatnio Aktywny');
    this.displayedColumns.push('Akcje');
  }

}
