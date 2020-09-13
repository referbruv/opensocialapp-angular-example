import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appPostText]'
})
export class PostTextDirective {

  constructor(private ref: ElementRef) {
    this.ref.nativeElement.style.color = '#555555';
  }

}
