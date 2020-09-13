import { Component, OnInit } from '@angular/core';
import { OidcAuthService } from '../../oidc-auth.service';
import { Profile } from 'oidc-client';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: Profile;

  constructor(private auth: OidcAuthService) { }

  ngOnInit(): void {
    this.profile = this.auth.getClaims();
  }

}
