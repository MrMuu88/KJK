import { Component } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { RegisterComponent } from "./register.component";
import { ForgotPasswordComponent } from "./forgotPassword.component";


@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  pageTitle: string = "Login";

  constructor(private modalService: NgbModal) { }

  openModal(request: string) {
    var modalRef: any;

    if (request == 'forgot') {
      modalRef = this.modalService.open(ForgotPasswordComponent);
    }
    else if (request == 'register') {
      modalRef = this.modalService.open(RegisterComponent);
    }

    modalRef.result.then(
      (result) => {
        console.log(result);
      }
    ).catch(
      (error) => {
        console.log(error)
      }
    );
  }
}
