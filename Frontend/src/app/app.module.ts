import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthorizationModule } from './components/authorization/authorization.module';
import { BsDropdownModule, BsDatepickerModule } from 'ngx-bootstrap';
import { appRoutes } from './route.module';
import { TrainingModule } from './components/training/training.module';

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

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DashboardComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthorizationModule,
    TrainingModule,
    FormsModule,
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
  bootstrap: [AppComponent]
})
export class AppModule { }
