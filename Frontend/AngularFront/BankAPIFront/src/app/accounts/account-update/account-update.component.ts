import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AccountService} from "../../shared/service/account.service";
import {Account} from "../../shared/models/account";

@Component({
  selector: 'app-account-update',
  templateUrl: './account-update.component.html',
  styleUrls: ['./account-update.component.css']
})
export class AccountUpdateComponent implements OnInit {
  account: Account = new Account();

  accountForm = new FormGroup({
    id: new FormControl(),
    accountName: new FormControl(''),
    amount: new FormControl(''),
  })

  constructor(private accountService: AccountService, private route: ActivatedRoute, private router: Router) { }

  async ngOnInit(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.account = await this.accountService.getAccountById(id)
    this.accountForm.patchValue({
      id: this.account.id,
      accountName: this.account.accountName,
      amount: this.account.amount
    });
  }

  // Update is working but I do not have customerId yet
  async save(){
    const account = this.accountForm.value;
    let dto = {
      id: this.account.id,
      accountName: this.account.accountName,
      amount: this.account.amount
    }
    await this.accountService.updateAccount(dto, account.id)
    await this.router.navigateByUrl('/accounts');
  }

}
