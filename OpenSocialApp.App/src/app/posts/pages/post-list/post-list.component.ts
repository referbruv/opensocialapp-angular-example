import { Component, OnInit, OnDestroy } from '@angular/core';
import { PostsService } from '../../posts.service';
import { Post } from '../../post';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { OidcAuthService } from '../../../auth/oidc-auth.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit, OnDestroy {

  posts: Post[];
  postsUpdatedSubs: Subscription;
  authSubs: Subscription;
  isLoggedIn: boolean;

  constructor(private postsService: PostsService, router: Router, private auth: OidcAuthService) { }

  ngOnDestroy(): void {
    this.postsUpdatedSubs.unsubscribe();
  }

  ngOnInit(): void {
    debugger;
    this.isLoggedIn = this.auth.isLoggedIn();
    this.postsService.getPosts().subscribe(posts => this.posts);

    let postsUpdatedSubs$ = this.postsService.getPostsUpdatedListener();
    this.postsUpdatedSubs = postsUpdatedSubs$.subscribe((posts) => {
      this.posts = [...posts];
    }, (error) => {
      // handle error
      console.log("Error in PostListComponent: " + error.message);
    });

    let authSubs$ = this.auth.getUserLoggedInEvents();
    this.authSubs = authSubs$.subscribe((isLoggedIn) => {
      this.isLoggedIn = isLoggedIn;
    });
  }
}
