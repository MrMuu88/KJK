import { Component } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { RegisterComponent } from "./register.component";

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  pageTitle: string = "Login";

  constructor(private modalService: NgbModal) { }

  openRegisterModal() {
    const modalRef = this.modalService.open(RegisterComponent);
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
