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
import { MatInputModule, MatTabsModule, MatTableModule, MatSortModule, MatPaginatorModule, MatProgressSpinnerModule, MatCardModule, MatDialogModule, MatButtonModule, MatIconModule, MatSelectModule, MatDatepickerModule, MatNativeDateModule, MatAutocompleteModule, MatBadgeModule, MatBottomSheetModule, MatButtonToggleModule, MatCheckboxModule, MatChipsModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatListModule, MatMenuModule, MatProgressBarModule, MatRadioModule, MatRippleModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatStepperModule, MatToolbarModule, MatTooltipModule, MatTreeModule, MAT_DATE_LOCALE } from '@angular/material';
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
import { DragDropModule } from '@angular/cdk/drag-drop';
import { TrainingEditComponent } from './components/training/training-edit/training-edit.component';
import { TrainingAddComponent } from './components/training/training-add/training-add.component';
import { DietEditComponent } from './components/diet/diet-edit/diet-edit.component';
import { DietAddComponent } from './components/diet/diet-add/diet-add.component';
import { ThighListComponent } from './components/dashboard/survey/thigh/thigh-list/thigh-list.component';
import { ThighAddComponent } from './components/dashboard/survey/thigh/thigh-add/thigh-add.component';
import { HipListComponent } from './components/dashboard/survey/hip/hip-list/hip-list.component';
import { HipAddComponent } from './components/dashboard/survey/hip/hip-add/hip-add.component';
import { HipUpdateComponent } from './components/dashboard/survey/hip/hip-update/hip-update.component';
import { ThighUpdateComponent } from './components/dashboard/survey/thigh/thigh-update/thigh-update.component';
import { ChestUpdateComponent } from './components/dashboard/survey/chest/chest-update/chest-update.component';
import { ChestAddComponent } from './components/dashboard/survey/chest/chest-add/chest-add.component';
import { ChestListComponent } from './components/dashboard/survey/chest/chest-list/chest-list.component';
import { CalfAddComponent } from './components/dashboard/survey/calf/calf-add/calf-add.component';
import { CalfListComponent } from './components/dashboard/survey/calf/calf-list/calf-list.component';
import { CalfUpdateComponent } from './components/dashboard/survey/calf/calf-update/calf-update.component';
import { BodyWeightUpdateComponent } from './components/dashboard/survey/body-weight/body-weight-update/body-weight-update.component';
import { BodyWeightAddComponent } from './components/dashboard/survey/body-weight/body-weight-add/body-weight-add.component';
import { BodyWeightListComponent } from './components/dashboard/survey/body-weight/body-weight-list/body-weight-list.component';
import { BodyFatListComponent } from './components/dashboard/survey/body-fat/body-fat-list/body-fat-list.component';
import { BodyFatAddComponent } from './components/dashboard/survey/body-fat/body-fat-add/body-fat-add.component';
import { BodyFatUpdateComponent } from './components/dashboard/survey/body-fat/body-fat-update/body-fat-update.component';
import { BicepsListComponent } from './components/dashboard/survey/biceps/biceps-list/biceps-list.component';
import { BicepsAddComponent } from './components/dashboard/survey/biceps/biceps-add/biceps-add.component';
import { BicepsUpdateComponent } from './components/dashboard/survey/biceps/biceps-update/biceps-update.component';
import { DashboardService } from './services/dashboard/dashboard.service';
import { ModalBicepsComponent } from './components/dashboard/survey/biceps/modal-biceps/modal-biceps.component';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { PupilListComponent } from './components/trainer/pupil-list/pupil-list.component';
import {TimeAgoPipe} from 'time-ago-pipe';
import { TrainingDashboardComponent } from './components/training/training-dashboard/training-dashboard.component';
import { DietDashboardComponent } from './components/diet/diet-dashboard/diet-dashboard.component';
import { TrainingUserComponent } from './components/user/training-user/training-user.component';
import { DietUserComponent } from './components/user/diet-user/diet-user.component';
import { SurveyUserComponent } from './components/user/survey-user/survey-user.component';
import { ThighListComponent1 } from './components/user/survey/thigh/thigh-list/thigh-list.component1';
import { HipListComponent1 } from './components/user/survey/hip/hip-list/hip-list.component1';
import { ChestListComponent1 } from './components/user/survey/chest/chest-list/chest-list.component1';
import { CalfListComponent1 } from './components/user/survey/calf/calf-list/calf-list.component1';
import { BodyWeightListComponent1 } from './components/user/survey/body-weight/body-weight-list/body-weight-list.component1';
import { BodyFatListComponent1 } from './components/user/survey/body-fat/body-fat-list/body-fat-list.component1';
import { BicepsListComponent1 } from './components/user/survey/biceps/biceps-list/biceps-list.component1';

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
    PhotoEditorComponent, 
    TrainingEditComponent, 
    TrainingAddComponent, 
    DietEditComponent, 
    DietAddComponent, 
    ThighListComponent,
    ThighListComponent1, 
    ThighAddComponent, 
    HipListComponent,
    HipListComponent1,
    HipAddComponent, 
    HipUpdateComponent, 
    ThighUpdateComponent, 
    ChestUpdateComponent, 
    ChestAddComponent, 
    ChestListComponent,
    ChestListComponent1, 
    CalfAddComponent, 
    CalfListComponent,
    CalfListComponent1, 
    CalfUpdateComponent, 
    BodyWeightUpdateComponent, 
    BodyWeightAddComponent, 
    BodyWeightListComponent,
    BodyWeightListComponent1, 
    BodyFatListComponent,
    BodyFatListComponent1, 
    BodyFatAddComponent, 
    BodyFatUpdateComponent, 
    BicepsListComponent,
    BicepsListComponent1,
    BicepsAddComponent, 
    BicepsUpdateComponent, 
    ModalBicepsComponent, 
    PupilListComponent,
    TimeAgoPipe,
    TrainingDashboardComponent,
    DietDashboardComponent,
    TrainingUserComponent,
    DietUserComponent,
    SurveyUserComponent
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
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    MatMomentDateModule,
    DragDropModule,
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
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    AuthService,
    ErrorInterceptorProvider, 
    AlertifyService,
    AuthGuard,
    TrainingService,
    TrainingDetailResolver,
    DietService,
    TrainerService,
    DietDetailResolver,
    UserService,
    DashboardService
  ],
  entryComponents: [
    ModalBicepsComponent,
    BicepsAddComponent,
    BodyFatAddComponent,
    BodyFatUpdateComponent,
    BodyWeightAddComponent,
    BodyWeightUpdateComponent,
    CalfAddComponent,
    CalfUpdateComponent,
    ChestAddComponent,
    ChestUpdateComponent,
    HipAddComponent,
    HipUpdateComponent,
    ThighAddComponent,
    ThighUpdateComponent
  ],
  bootstrap: [AppComponent],
  exports:[HasRoleDirective]
})
export class AppModule { }
