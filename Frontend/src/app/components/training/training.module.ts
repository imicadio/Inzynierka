import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { TrainingListComponent } from './training-list/training-list.component';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule, MatPaginatorModule, MatProgressSpinnerModule, 
    MatSortModule, MatTableModule } from "@angular/material";
import { TrainingDetailComponent } from './training-detail/training-detail.component';
    

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,    
    ReactiveFormsModule,    
    RouterModule,    
    FormsModule,
    HttpClientModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    BsDatepickerModule.forRoot(),
  ],
  declarations: [TrainingListComponent, TrainingDetailComponent]
})
export class TrainingModule { }
