import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/shared/models/customer';
import { CustomerService } from 'src/app/shared/service/customer.service';

@Component({
  selector: 'app-customer-update',
  templateUrl: './customer-update.component.html',
  styleUrls: ['./customer-update.component.css']
})
export class CustomerUpdateComponent implements OnInit {
  customer: Customer = new Customer();

  customerForm = new FormGroup({
    id: new FormControl(),
    firstName: new FormControl(''),
    lastName: new FormControl('')
  });

  constructor(private customerService: CustomerService, private route: ActivatedRoute, private router: Router) { }

  async ngOnInit(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.customer = await this.customerService.getCustomersById(id);
    this.customerForm.patchValue({
      id: this.customer.id,
      firstName: this.customer.firstName,
      lastName: this.customer.lastName
    });
  }

  async save() {
    const customer = this.customerForm.value;
    let dto = {
      id: customer.id,
      firstName: customer.firstName,
      lastName: customer.lastName
    }
    await this.customerService.updateCustomer(dto, customer.id)
    await this.router.navigateByUrl('/customers');
  }


}


