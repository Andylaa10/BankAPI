import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5228',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
});

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) {
  }

  async getCustomers(){
    const httpResponse = await customAxios.get<any>('Customer');
    return httpResponse.data;
  }

  async getCustomersById(id: number){
    const httpResponse = await customAxios.get<any>('Customer/'+`${id}`);
    return httpResponse.data;
  }

  async addCustomer(dto: {firstName: string, lastName: string}){
    const httpResult = await customAxios.post('Customer', dto);
    return httpResult.data;
  }

  async updateCustomer(dto: {id: any, firstName: any, lastName: any}, id: number){
    const httpResult = await customAxios.put('Customer/'+`${id}`, dto);
    return httpResult.data;
  }

  async deleteCustomer(customerId: any){
    const httpResult = await customAxios.delete('Customer/' + customerId);
    return httpResult.data;
  }


}
