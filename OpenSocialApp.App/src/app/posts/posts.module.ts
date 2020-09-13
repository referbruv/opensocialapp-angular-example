import { NgModule } from '@angular/core';
import { PostsRoutingModule } from './posts-routing.module';
import { PostListComponent } from './pages/post-list/post-list.component';
import { PostItemComponent } from './components/post-item/post-item.component';
import { NewPostComponent } from './components/new-post/new-post.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SinglePostComponent } from './pages/single-post/single-post.component';
import { PostTextDirective } from './directives/post-text/post-text.directive';
import { ShouldShowTextDirective } from './directives/should-show-text/should-show-text.directive';

@NgModule({
    declarations: [
        PostItemComponent,
        PostListComponent,
        NewPostComponent,
        SinglePostComponent,
        PostTextDirective,
        ShouldShowTextDirective
    ],
    imports: [
        CommonModule,
        PostsRoutingModule,
        FormsModule
    ],
    providers: []
})
export class PostsModule { }