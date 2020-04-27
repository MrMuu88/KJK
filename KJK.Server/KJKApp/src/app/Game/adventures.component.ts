import { Component } from "@angular/core";

@Component({
  selector: 'Adventures',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class AdventuresComponent {
  pageTitle: string = "Adventures";
}
