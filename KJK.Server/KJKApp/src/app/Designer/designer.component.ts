import { Component } from "@angular/core";

@Component({
  selector: 'Designer',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class DesignerComponent {
  pageTitle: string = "Designer";
}
