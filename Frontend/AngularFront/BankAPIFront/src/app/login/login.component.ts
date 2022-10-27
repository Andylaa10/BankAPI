import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../shared/service/authentication.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: any;
  password: any;

  constructor(private auth: AuthenticationService) { }

  ngOnInit(): void {
  }

  async login() {
    let dto = {
      email: this.email,
      password: this.password
    }
    const token = await this.auth.login(dto);
    localStorage.setItem('token', token);
  }
}
