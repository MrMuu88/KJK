import { Component } from "@angular/core";

@Component({
  selector: 'About',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class AboutComponent {
  pageTitle: string = "About";
}

