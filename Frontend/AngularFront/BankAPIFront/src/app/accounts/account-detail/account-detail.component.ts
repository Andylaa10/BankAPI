import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/shared/models/account';
import { AccountService } from 'src/app/shared/service/account.service';

@Component({
  selector: 'app-account-detail',
  templateUrl: './account-detail.component.html',
  styleUrls: ['./account-detail.component.css']
})
export class AccountDetailComponent implements OnInit {
  id!: number;
  accountName: any;
  amount: any;
  account: Account = new Account();


  constructor(private accountService: AccountService, private route: ActivatedRoute) {

  }

  async ngOnInit(){
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.account = await this.accountService.getAccountById(this.id);
  }
}
