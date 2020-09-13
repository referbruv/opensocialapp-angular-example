import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthCallbackComponent } from './pages/auth-callback/auth-callback.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { AuthRoutingModule } from './auth-routing.module';


@NgModule({
    declarations: [
        AuthCallbackComponent,
        ProfileComponent
    ],
    imports: [
        AuthRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        CommonModule
    ]
})
export class AuthModule { }