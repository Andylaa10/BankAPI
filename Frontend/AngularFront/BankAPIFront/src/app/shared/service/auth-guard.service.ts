import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";
import jwtDecode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor() { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let token = localStorage.getItem("token");
    if(token){
      let decodedToken = jwtDecode(token) as Token;
      if (decodedToken.expired){
        let currentDate = new Date();
        let expired = new Date(decodedToken.expired*1000);

        if (currentDate < expired){
          return true
        }
      }
    }
    return false
  }
}

class Token{
  expired?: number;

}
