import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersListComponent } from './customers/customers-list/customers-list.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { AccountsListComponent } from './accounts/accounts-list/accounts-list.component';
import { AccountDetailComponent } from './accounts/account-detail/account-detail.component';
import { CustomerAddComponent } from './customers/customer-add/customer-add.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CustomerUpdateComponent } from './customers/customer-update/customer-update.component';
import { AccountUpdateComponent } from './accounts/account-update/account-update.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import { AccountAddComponent } from './accounts/account-add/account-add.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import {MatIconModule} from "@angular/material/icon";
import {MatMenuModule} from "@angular/material/menu";
import {MatOptionModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomersListComponent,
    NavbarComponent,
    WelcomeComponent,
    CustomerDetailComponent,
    AccountsListComponent,
    AccountDetailComponent,
    CustomerAddComponent,
    CustomerUpdateComponent,
    AccountUpdateComponent,
    AccountAddComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatMenuModule,
    MatOptionModule,
    MatSelectModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
