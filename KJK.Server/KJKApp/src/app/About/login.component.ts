import { Component } from "@angular/core";

@Component({
  selector: 'Login',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class LoginComponent {
  pageTitle: string = "Login";
}
