import { Component } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'forgotPassword',
  templateUrl: 'forgotPassword.component.html'
})
export class ForgotPasswordComponent {
  pageTitle: string = "Register";
  constructor(public activeModal: NgbActiveModal) { }

  sendPasswordRequest(): void {
    console.log("sending Password request to email");
    this.activeModal.close("email sent");
  }
}
