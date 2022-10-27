import { Component, OnInit } from '@angular/core';
import { Account } from 'src/app/shared/models/account';
import { AccountService } from 'src/app/shared/service/account.service';
import {Customer} from "../../shared/models/customer";
import {CustomerService} from "../../shared/service/customer.service";

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.css']
})
export class AccountsListComponent implements OnInit {
  accounts: Account[] = [];
  constructor(private accountService: AccountService) { /* TODO document why this constructor is empty */ }

  async ngOnInit(){
    await this.refresh();
  }

  async refresh(){
    const accounts = await this.accountService.getAccounts()
    this.accounts = accounts;
  }

  async deleteAccount(accountId: any) {
    const account = await this.accountService.deleteAccount(accountId);
    this.accounts = this.accounts.filter(a => a.id != account.id);
  }
}
