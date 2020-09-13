import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { AuthCallbackComponent } from './pages/auth-callback/auth-callback.component';
import { AuthGuard } from './auth.guard';
import { ProfileComponent } from './pages/profile/profile.component';

const routes: Routes = [
    { path: 'auth-callback', component: AuthCallbackComponent },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutingModule { }