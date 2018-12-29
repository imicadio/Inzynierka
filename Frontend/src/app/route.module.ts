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

export const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    {
        path: '',   // path: 'dummy' - localhost:4200/dummymembers
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'training', component: TrainingListComponent },
            { path: 'training/:id', component: TrainingDetailComponent, resolve: {training: TrainingDetailResolver} },
            { path: 'training/edit/:id', component: TrainingEditComponent },
            { path: 'trainer', component: TrainerDashboardComponent, data: { roles: ['Trainer'] } },
            { path: 'user/edit', component: UserEditComponent },
        ]

    },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
];
