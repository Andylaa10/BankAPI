import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/shared/models/customer';
import { CustomerService } from 'src/app/shared/service/customer.service';
import {addWarning} from "@angular-devkit/build-angular/src/utils/webpack-diagnostics";

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {

  customers: Customer[] = [];
  constructor(private customerService: CustomerService) { /* TODO document why this constructor is empty */ }

  async ngOnInit(){
    await this.refresh();
  }

  async refresh(){
    const customers = await this.customerService.getCustomers();
    this.customers = customers;
  }

  async deleteCustomer(customerId: any){
    const customer = await this.customerService.deleteCustomer(customerId);
    this.customers = this.customers.filter(c => c.id != customer.id);
  }
}
