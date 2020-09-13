import { Component, OnInit } from '@angular/core';
import { OidcAuthService } from '../../oidc-auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.css']
})
export class AuthCallbackComponent implements OnInit {

  constructor(private authService: OidcAuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.authService.completeSignIn().then((value) => {
      this.route.params.subscribe(params => {
        console.log(params);
      });
      this.router.navigate(["/"]);
    });
  }

}
