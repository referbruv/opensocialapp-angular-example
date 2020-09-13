import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { Post } from '../../post';

@Directive({
  selector: '[appShouldShowText]'
})
export class ShouldShowTextDirective {

  private hasView = false;
  @Input() set appShouldShowText(post: Post) {
    if (post) {
      let condition = post.text && post.text.length > 20;
      if (condition && !this.hasView) {
        this.viewContainer.createEmbeddedView(this.templateRef);
        this.hasView = true;
      } else if (!condition && this.hasView) {
        this.viewContainer.clear();
        this.hasView = false;
      }
    }
  }

  constructor(private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef) {
  }

}
