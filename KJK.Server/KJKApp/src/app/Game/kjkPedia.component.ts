import { Component } from "@angular/core";

@Component({
  selector: 'KJKPedia',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class KJKPediaComponent {
  pageTitle: string = "KJKPedia";
}
