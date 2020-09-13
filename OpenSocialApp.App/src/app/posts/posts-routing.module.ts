import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { PostListComponent } from './pages/post-list/post-list.component';
import { AuthGuard } from '../auth/auth.guard';
import { SinglePostComponent } from './pages/single-post/single-post.component';

const routes: Routes = [
    { path: "posts", component: PostListComponent, canActivate: [AuthGuard] },
    { path: "posts/:id", component: SinglePostComponent },
    { path: "", component: PostListComponent, canActivate: [AuthGuard] }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class PostsRoutingModule { }