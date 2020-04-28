import { Component } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'register',
  templateUrl: 'register.component.html'
})
export class RegisterComponent {
  pageTitle: string = "Register";
  constructor(public activeModal: NgbActiveModal) { }

  registerNewUser(): void {
    console.log("registering new user");
    this.activeModal.close("User registered");
  }
}
