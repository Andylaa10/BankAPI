import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5228/auth',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
});

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  async login(dto: any){
    const httpResult = await customAxios.post('/login', dto);
    return httpResult.data;
  }
}

