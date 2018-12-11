import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Training } from '../models/training';
import { AlertifyService } from '../services/alertify/alertify.service';
import { DietService } from '../services/diet/diet.service';

@Injectable()
export class DietDetailResolver implements Resolve<Training> {

    constructor(private dietService: DietService, private router: Router, private alertify: AlertifyService) {}

    resolve() {
        return null;
        // return this.trainingService.getTraining(route.params['id']).pipe(
        //     catchError(error => {
        //         this.alertify.error('Trening, który chcesz zobaczyć nie istnieje');
        //         this.router.navigate(['/training']);
        //         return of(null);
        //     })
        // );
    }
}
