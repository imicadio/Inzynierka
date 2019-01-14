import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { LoginComponent } from './components/authorization/login/login.component';
import { TrainingListComponent } from './components/training/training-list/training-list.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { TrainingDetailComponent } from './components/training/training-detail/training-detail.component';
import { TrainingDetailResolver } from './resolvers/training-detail.resolver';
import { TrainerDashboardComponent } from './components/trainer/trainer-dashboard/trainer-dashboard.component';
import { UserEditComponent } from './components/user/user-edit/user-edit.component';
import { TrainingEditComponent } from './components/training/training-edit/training-edit.component';
import { TrainingAddComponent } from './components/training/training-add/training-add.component';
import { DietListComponent } from './components/diet/diet-list/diet-list.component';
import { DietAddComponent } from './components/diet/diet-add/diet-add.component';
import { DietDetailComponent } from './components/diet/diet-detail/diet-detail.component';
import { DietEditComponent } from './components/diet/diet-edit/diet-edit.component';
import { BicepsAddComponent } from './components/dashboard/survey/biceps/biceps-add/biceps-add.component';
import { BodyFatAddComponent } from './components/dashboard/survey/body-fat/body-fat-add/body-fat-add.component';
import { BodyWeightAddComponent } from './components/dashboard/survey/body-weight/body-weight-add/body-weight-add.component';
import { CalfAddComponent } from './components/dashboard/survey/calf/calf-add/calf-add.component';
import { ChestAddComponent } from './components/dashboard/survey/chest/chest-add/chest-add.component';
import { HipAddComponent } from './components/dashboard/survey/hip/hip-add/hip-add.component';
import { ThighAddComponent } from './components/dashboard/survey/thigh/thigh-add/thigh-add.component';
import { UserDetailComponent } from './components/user/user-detail/user-detail.component';
import { PreventUnsevedChanges } from './_guards/preved-unsaved-changes.guard';

export const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    {
        path: '',   // path: 'dummy' - localhost:4200/dummymembers
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'training', component: TrainingListComponent },
            { path: 'training/add', component: TrainingAddComponent, data: { roles: ['Trainer'] } },
            { path: 'training/:id', component: TrainingDetailComponent, resolve: {training: TrainingDetailResolver} },
            { path: 'training/edit/:id', component: TrainingEditComponent, data: { roles: ['Trainer'] } },            
            { path: 'trainer', component: TrainerDashboardComponent, data: { roles: ['Trainer'] } },            
            { path: 'diet', component: DietListComponent },
            { path: 'diet/add', component: DietAddComponent, data: { roles: ['Trainer'] } },
            { path: 'diet/:id', component: DietDetailComponent },
            { path: 'diet/edit/:id', component: DietEditComponent, data: { roles: ['Trainer'] } },
            { path: 'user/edit', component: UserEditComponent, canDeactivate: [PreventUnsevedChanges] }, 
            { path: 'user/:id', component: UserDetailComponent },                       
        ]
    },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
];
