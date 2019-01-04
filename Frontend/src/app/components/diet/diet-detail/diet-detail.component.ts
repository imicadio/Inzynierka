import { Component, OnInit } from '@angular/core';
import { DietService } from 'src/app/services/diet/diet.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Diet } from 'src/app/models/diet';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-diet-detail',
  templateUrl: './diet-detail.component.html',
  styleUrls: ['./diet-detail.component.css']
})
export class DietDetailComponent implements OnInit {
  diet: Diet;
  diets: Diet[];
  displayedColumns = ['Produkt', 'Miara Domowa', 'Waga [g.]'];
  dataSource = new MatTableDataSource<Diet>(this.diets);

  constructor(
    private dietService: DietService, 
    private alertify: AlertifyService, 
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getDiet();
    this.loadDiets();
  }

  loadDiets(){
    const id = +this.route.snapshot.paramMap.get('id');
    this.dietService.getDietArray(id).subscribe((diets: Diet[]) => {
      this.diets = diets;
      console.log(diets);
    }, error => {
      this.alertify.error(error);
    });
  }  

  getDiet() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.dietService.getDiet(id).subscribe((diet: Diet) => {
      this.diet = diet;   
    }, error => {
      this.alertify.error(error);
    });
  }

}
