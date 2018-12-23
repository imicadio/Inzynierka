import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FileUploadModule } from 'ng2-file-upload';

import { AuthorizationModule } from './components/authorization/authorization.module';
import { BsDropdownModule, TabsModule, BsDatepickerModule, PaginationModule, ButtonsModule, ModalModule, AlertModule } from 'ngx-bootstrap';
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
import { MatInputModule, MatTabsModule, MatTableModule, MatSortModule, MatPaginatorModule, MatProgressSpinnerModule, MatCardModule, MatDialogModule, MatButtonModule, MatIconModule, MatSelectModule } from '@angular/material';
import { TrainingListComponent } from './components/training/training-list/training-list.component';
import { TrainingDetailComponent } from './components/training/training-detail/training-detail.component';
import { TrainingDetailResolver } from './resolvers/training-detail.resolver';
import { DietListComponent } from './components/diet/diet-list/diet-list.component';
import { DietDetailComponent } from './components/diet/diet-detail/diet-detail.component';
import { DietService } from './services/diet/diet.service';
import { AddUserComponent } from './components/trainer/add-user/add-user.component';
import { TrainerService } from './services/trainer/trainer.service';
import { TrainerDashboardComponent } from './components/trainer/trainer-dashboard/trainer-dashboard.component';
import { DietDetailResolver } from './resolvers/diet-detail.resolver';
import { AddTrainingComponent } from './components/trainer/add-training/add-training.component';
import { UserDetailComponent } from './components/user/user-detail/user-detail.component';
import { UserEditComponent } from './components/user/user-edit/user-edit.component';
import { PhotoEditorComponent } from './components/user/photo-editor/photo-editor.component';
import { UserService } from './services/user/user.service';

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
    TrainingDetailComponent, 
    DietListComponent, 
    DietDetailComponent, 
    AddUserComponent, 
    TrainerDashboardComponent, 
    AddTrainingComponent, 
    UserDetailComponent, 
    UserEditComponent, 
    PhotoEditorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthorizationModule,
    FormsModule,
    CommonModule,
    BrowserModule,
    MatTabsModule,
    MatCardModule,
    MatDialogModule,
    MatButtonModule,
    BrowserAnimationsModule,    
    ReactiveFormsModule,    
    RouterModule,    
    FormsModule,
    HttpClientModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    FileUploadModule,
    AlertModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),    
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
    TrainingService,
    TrainingDetailResolver,
    DietService,
    TrainerService,
    DietDetailResolver,
    UserService
  ],
  bootstrap: [AppComponent],
  exports:[HasRoleDirective]
})
export class AppModule { }
