import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Training } from '../models/training';
import { TrainingService } from '../services/training/training.service';
import { AlertifyService } from '../services/alertify/alertify.service';

@Injectable()
export class TrainingDetailResolver implements Resolve<Training> {

    constructor(private trainingService: TrainingService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Training> {
        return this.trainingService.getTraining(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Trening, który chcesz zobaczyć nie istnieje');
                this.router.navigate(['/training']);
                return of(null);
            })
        );
    }
}
