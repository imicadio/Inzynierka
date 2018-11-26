import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { LoginComponent } from './components/authorization/login/login.component';
import { TrainingListComponent } from './components/training/training-list/training-list.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

export const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    {
        path: '',   // path: 'dummy' - localhost:4200/dummymembers
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'training', component: TrainingListComponent }
        ]

    },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '/404', pathMatch: 'full' }
];
