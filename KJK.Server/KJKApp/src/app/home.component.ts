import { Component } from "@angular/core";

@Component({
  selector: 'home',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class HomeComponent {
  pageTitle: string = "home";
}
