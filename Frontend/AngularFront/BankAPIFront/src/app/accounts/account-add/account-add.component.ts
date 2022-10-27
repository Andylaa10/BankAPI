import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {CustomerService} from "../../shared/service/customer.service";
import {ActivatedRoute, Router} from "@angular/router";
import {AccountService} from "../../shared/service/account.service";
import {Account} from "../../shared/models/account";
import {Customer} from "../../shared/models/customer";

@Component({
  selector: 'app-account-add',
  templateUrl: './account-add.component.html',
  styleUrls: ['./account-add.component.css']
})
export class AccountAddComponent implements OnInit {

  accountName: any = "";
  amount: any = "";



  constructor(private accountService: AccountService,
              private route: Router,
              private customerService: CustomerService) {
  }

  async ngOnInit(){

  }

  async save() {
    let dto ={
      accountName: this.accountName,
      amount: this.amount
    }
    await this.accountService.addAccount(dto)
    await this.route.navigateByUrl('/accounts');
  }
}
