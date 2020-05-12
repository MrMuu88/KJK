import { Component } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { RegisterComponent } from "./register.component";
import { ForgotPasswordComponent } from "./forgotPassword.component";
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError,retry } from 'rxjs/operators';
import { LoginModel } from "../models/login.model";


@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginName: string;
  password: string;
  baseUrl: string = "https://localhost:44348";

  constructor(private modalService: NgbModal, private httpClient: HttpClient) { }

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

  login() {
    var login: any = {
      loginName: this.loginName,
      password: this.password
    };

    this.httpClient.post(`${this.baseUrl}/api/user/login`, login).subscribe((data) => {
      console.log(data);
    }, (error) => {
        console.log(error);
    });
    
  }

}
