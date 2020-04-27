import { Component } from "@angular/core";

@Component({
  selector: 'Register',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class RegisterComponent {
  pageTitle: string = "Register";
}
