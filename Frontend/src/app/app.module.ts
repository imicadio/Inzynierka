import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthorizationModule } from './components/authorization/authorization.module';
import { BsDropdownModule, BsDatepickerModule } from 'ngx-bootstrap';
import { appRoutes } from './route.module';

import { AppComponent } from './app.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AlertifyService } from './services/alertify/alertify.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AuthService } from './services/auth/auth.service';
import { AuthGuard } from './_guards/auth.guard';
import { TrainingService } from './services/training/training.service';
import { JwtModule } from '@auth0/angular-jwt';
import { HasRoleDirective } from './directives/has-role.directive';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule, MatProgressSpinnerModule } from '@angular/material';
import { TrainingListComponent } from './components/training/training-list/training-list.component';
import { TrainingDetailComponent } from './components/training/training-detail/training-detail.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DashboardComponent,
    NotFoundComponent,
    HasRoleDirective,
    TrainingListComponent, 
    TrainingDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthorizationModule,
    FormsModule,
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
    BsDropdownModule.forRoot(),      
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:57247'],
        blacklistedRoutes: ['localhost:57247/api/auth/']
      }
    })
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider, 
    AlertifyService,
    AuthGuard,
    TrainingService
  ],
  bootstrap: [AppComponent],
  exports:[HasRoleDirective]
})
export class AppModule { }
