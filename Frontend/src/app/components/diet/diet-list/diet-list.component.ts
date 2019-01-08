import { Component, OnInit } from '@angular/core';
import { Diet } from 'src/app/models/diet';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { DietService } from 'src/app/services/diet/diet.service';

@Component({
  selector: 'app-diet-list',
  templateUrl: './diet-list.component.html',
  styleUrls: ['./diet-list.component.css']
})
export class DietListComponent implements OnInit {
  diets: Diet[];
  public displayedColumns = new Array<string>();

  constructor(
    private dietService: DietService,
    private alertify: AlertifyService, 
    public authService: AuthService, 
    private router: Router
  ) { }

  ngOnInit() {
    this.fillTableColumnNames();
    this.loadDiets();
  }

  loadDiets(){
    this.dietService.getDiets().subscribe((diets: Diet[]) => {
      this.diets = diets;
      console.log(diets);
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

  deleteDiet(id: number) {
    this.dietService.deleteDiet(id, this.authService.decodedToken.nameid).subscribe(()=>{
      this.alertify.success('Pomyślnie usunięto trening');
      this.loadDiets();
    }, error => {
      this.alertify.error(error);      
    });
  }

  btnClick() {
    this.router.navigateByUrl('/diets/add');
  } 
}
