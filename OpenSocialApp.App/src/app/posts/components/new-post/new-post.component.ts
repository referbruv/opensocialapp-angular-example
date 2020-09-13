import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
  }

  createPost(newPostForm: NgForm) {
    if (newPostForm.invalid) {
      return;
    }
    console.log(newPostForm);
    this.postsService.createPost(newPostForm.value.status).subscribe(post => {
      newPostForm.reset();
    });
  }

}
