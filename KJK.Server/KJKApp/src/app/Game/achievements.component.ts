import { Component } from "@angular/core";

@Component({
  selector: 'Achievements',
  template: '<h1>Hello {{pageTitle}} component<h1>'
})
export class AchievementsComponent {
  pageTitle: string = "Achievements";
}
