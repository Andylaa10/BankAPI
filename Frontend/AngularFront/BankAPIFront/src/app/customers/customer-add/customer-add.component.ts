import {Component, OnInit, ViewChild} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/shared/service/customer.service';
import {Account} from "../../shared/models/account";
import {AccountService} from "../../shared/service/account.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {

  firstName: any = "";
  lastName: any = "";

  constructor(private customerService: CustomerService,
              private route: Router
              ) { }

  ngOnInit(): void {
  }

  async save(){
    let dto = {
      firstName: this.firstName,
      lastName: this.lastName
    }

    await this.customerService.addCustomer(dto);
    await this.route.navigateByUrl("/customers")
  }
}
