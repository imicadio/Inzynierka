import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { User } from "../models/user";
import { UserService } from "../services/user/user.service";
import { AuthService } from "../services/auth/auth.service";
import { AlertifyService } from "../services/alertify/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class UserEditResolver implements Resolve<User> {

    constructor(private userService: UserService, private router: Router,
        private authService: AuthService, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem retrviewing your data');
                this.router.navigate(['/dashboard']);
                return of(null);
            })
        );
    }
}