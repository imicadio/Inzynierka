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
            { path: 'diets', component: DietListComponent },
            { path: 'diets/add', component: DietAddComponent, data: { roles: ['Trainer'] } },
            { path: 'diets/:id', component: DietDetailComponent },
            { path: 'diets/edit/:id', component: DietEditComponent, data: { roles: ['Trainer'] } },
            { path: 'user/edit', component: UserEditComponent },
        ]

    },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
];
