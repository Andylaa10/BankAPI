import {Injectable} from '@angular/core';
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
export class AccountService {

  constructor() {
  }

  async getAccounts(){
    const httpResponse = await customAxios.get<any>('Account');
    return httpResponse.data;
  }

  async getAccountById(id: number){
    const httpResponse = await customAxios.get<any>('Account/'+`${id}`);
    return httpResponse.data;
  }

  async addAccount(dto: {accountName: string, amount: number}){
    const httpResult = await customAxios.post('Account', dto);
    return httpResult.data;
  }

  async updateAccount(dto: {id: any, accountName: string, amount: number}, id: Number){
    const httpResult = await customAxios.put('Account/'+`${id}`, dto);
    return httpResult.data;
  }

  async deleteAccount(accountId: Number){
    const httpResult = await customAxios.delete('Account/' + accountId);
    return httpResult.data;
  }
}
