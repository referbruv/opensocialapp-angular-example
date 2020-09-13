import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Post } from '../../post';

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.css']
})
export class PostItemComponent {

  @Input("post") post: Post;
  @Output("hover") hover = new EventEmitter();

  constructor() { }

  onHover() {
    this.hover.emit();
  }
}
