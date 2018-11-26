import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthorizationModule } from './components/authorization/authorization.module';
import { BsDropdownModule, BsDatepickerModule } from 'ngx-bootstrap';
import { appRoutes } from './route.module';

import { AppComponent } from './app.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AlertifyService } from './services/alertify/alertify.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TrainingListComponent } from './components/training/training-list/training-list.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AuthService } from './services/auth/auth.service';
import { AuthGuard } from './_guards/auth.guard';
import { TrainingService } from './services/training/training.service';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DashboardComponent,
    TrainingListComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthorizationModule,
    FormsModule,
    BsDropdownModule.forRoot(),      
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider, 
    AlertifyService,
    AuthGuard,
    TrainingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
