import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/shared/models/customer';
import { CustomerService } from 'src/app/shared/service/customer.service';
import {Account} from "../../shared/models/account";

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  customer: Customer = new Customer();

  constructor(private customerService: CustomerService, private route: ActivatedRoute) {

  }

  async ngOnInit(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.customer = await this.customerService.getCustomersById(id);
  }

}
