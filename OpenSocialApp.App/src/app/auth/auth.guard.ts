import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { OidcAuthService } from './oidc-auth.service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    private isLoggedIn: boolean;
    private observer$: Observable<boolean>;

    constructor(private authService: OidcAuthService) {
        debugger;
        this.isLoggedIn = this.authService.isLoggedIn();
        this.observer$ = this.authService.getUserLoggedInEvents();
        this.observer$.subscribe((flag) => {
            this.isLoggedIn = flag;
        });
    }

    canActivate(): boolean {
        if (this.isLoggedIn) {
            return true;
        }
        else {
            this.authService.signIn();
            return false;
        }
    }
}