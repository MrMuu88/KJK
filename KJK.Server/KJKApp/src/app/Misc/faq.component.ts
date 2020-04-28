import { Component } from "@angular/core";

@Component({
  selector: 'FAQ',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class FaqComponent {
  pageTitle: string = "FAQ";
}
