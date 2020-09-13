import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Post } from '../../post';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  post: Post;

  constructor(private route: ActivatedRoute, private postService: PostsService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      var postId = params.get("id");
      console.log(postId);
      if (postId) {
        this.postService.getPost(postId).subscribe((post) => {
          this.post = post;
        });
      }
    });
    this.route.queryParamMap.subscribe((params: ParamMap) => {
      var postId = params.get("timestamp");
      console.log(postId);
    });
  }

  back() {
    this.router.navigate(['/posts'], {
      queryParams: { timestamp: 'abcdefg' }
    });
  }

  highlight() {
    alert("Hovered");
  }

}
