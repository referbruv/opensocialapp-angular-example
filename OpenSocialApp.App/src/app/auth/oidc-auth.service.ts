import { Injectable } from '@angular/core';
import { UserManagerSettings, UserManager, User } from 'oidc-client';
import { Subject, Observable } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class OidcAuthService {

    private config: UserManagerSettings = {
        // the Domain where the STS runs
        authority: 'http://localhost:5002/',
        client_id: 'angular_spa',
        redirect_uri: 'http://localhost:80/auth/auth-callback?id=1234',
        post_logout_redirect_uri: 'http://localhost:80/',
        response_type: "id_token",
        scope: "openid profile email",
        filterProtocolClaims: true,
        loadUserInfo: true
    };

    private manager = new UserManager(this.config);
    private user: User = null;
    private userLoginSubject = new Subject<boolean>();

    constructor() {
        this.manager.getUser().then(user => {
            this.user = user;
            this.userLoginSubject.next(this.isLoggedIn());
        });
    }

    getUserLoggedInEvents(): Observable<boolean> {
        return this.userLoginSubject.asObservable();
    }

    getAuthorizationHeaderValue(): string {
        return `Bearer ${this.user.id_token}`;
    }

    getClaims(): any {
        return this.user.profile;
    }

    isLoggedIn(): boolean {
        return this.user != null && !this.user.expired;
    }

    signIn(): Promise<void> {
        return this.manager.signinRedirect();
    }

    completeSignIn(): Promise<void> {
        return this.manager.signinRedirectCallback().then(user => {
            this.user = user;
            this.userLoginSubject.next(this.isLoggedIn());
        });
    }

    signOut(): Promise<void> {
        return this.manager.signoutRedirect();
    }

    completeSignOut(): Promise<void> {
        return this.manager.signoutRedirectCallback().then(user => {
            this.user = null;
            this.userLoginSubject.next(this.isLoggedIn());
        });
    }
}