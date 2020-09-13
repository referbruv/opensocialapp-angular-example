import { Component, OnInit, OnDestroy, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { OidcAuthService } from '../auth/oidc-auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {

  isLoggedInUser: boolean;
  authSubs: Subscription;

  constructor(private auth: OidcAuthService, private router: Router) { }

  ngOnDestroy(): void {
    this.authSubs.unsubscribe();
  }

  ngOnInit(): void {
    this.isLoggedInUser = this.auth.isLoggedIn();
    this.authSubs = this.auth.getUserLoggedInEvents().subscribe((loggedInStatus: boolean) => {
      this.isLoggedInUser = loggedInStatus;
    });
  }

  logout() {
    this.auth.signOut();
  }

  login() {
    this.auth.signIn();
  }
  
}
