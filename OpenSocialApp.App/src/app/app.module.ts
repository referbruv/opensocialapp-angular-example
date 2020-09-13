import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ErrorInterceptor } from './error.interceptor';
import { NotfoundComponent } from './notfound/notfound.component';
import { PostsInterceptor } from './posts/posts.interceptor';

const routes: Routes = [
  { path: "posts", loadChildren: () => import("./posts/posts.module").then(m => m.PostsModule) },
  { path: "auth", loadChildren: () => import("./auth/auth.module").then(m => m.AuthModule) },
  { path: "", loadChildren: () => import("./posts/posts.module").then(m => m.PostsModule) },
  { path: "**", component: NotfoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    multi: true,
    useClass: ErrorInterceptor
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: PostsInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
