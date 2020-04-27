import { Component } from "@angular/core";

@Component({
  selector: 'Characters',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class CharactersComponent {
  pageTitle: string = "Characters";
}
