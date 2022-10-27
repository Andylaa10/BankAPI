import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailComponent } from './accounts/account-detail/account-detail.component';
import { AccountsListComponent } from './accounts/accounts-list/accounts-list.component';
import { CustomerAddComponent } from './customers/customer-add/customer-add.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerUpdateComponent } from './customers/customer-update/customer-update.component';
import { CustomersListComponent } from './customers/customers-list/customers-list.component';
import { WelcomeComponent } from './welcome/welcome.component';
import {AccountUpdateComponent} from "./accounts/account-update/account-update.component";
import {AccountAddComponent} from "./accounts/account-add/account-add.component";
import {LoginComponent} from "./login/login.component";
import {AuthGuardService} from "./shared/service/auth-guard.service";

const routes: Routes = [

  { path: 'accounts-add', component: AccountAddComponent, canActivate: [AuthGuardService] },
  { path: 'accounts', component: AccountsListComponent, canActivate: [AuthGuardService] },
  { path: 'accounts/:id', component: AccountDetailComponent, canActivate: [AuthGuardService] },
  { path: 'accounts-update/:id', component: AccountUpdateComponent, canActivate: [AuthGuardService] },

  { path: 'customers-add', component: CustomerAddComponent, canActivate: [AuthGuardService] },
  { path: 'customers', component: CustomersListComponent, canActivate: [AuthGuardService]  },
  { path: 'customers/:id', component: CustomerDetailComponent, canActivate: [AuthGuardService]  },
  { path: 'customers-update/:id', component: CustomerUpdateComponent, canActivate: [AuthGuardService]  },

  { path: 'welcome', component: WelcomeComponent, canActivate: [AuthGuardService]  },

  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


