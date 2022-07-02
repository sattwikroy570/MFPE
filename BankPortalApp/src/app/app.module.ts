import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { LoginComponent } from './user/login.component';
import { DepositComponent } from './customer/deposit.component';
import { WithdrawComponent } from './customer/withdraw.component';
import { TransferComponent } from './customer/transfer.component';
import { AccountStatementComponent } from './customer/account-statement.component';
import { NavbarComponent } from './shared/navbar.component';
import { FooterComponent } from './shared/footer.component';
import { SidebarComponent } from './customer/sidebar.component';
import { DashboardComponent } from './customer/dashboard.component';
import { CreateCustomerComponent } from './employee/create-customer.component';
import { GetCustomerDetailsComponent } from './employee/get-customer-details.component';
import { SidebarComponent as empSidebarComponent } from './employee/sidebar.component';
import { DashboardComponent as empDashboardComponent } from './employee/dashboard.component';
import { AuthGaurd } from './user/auth.gaurd';
import { AuthService } from './user/auth.service';
import { FormsModule } from '@angular/forms';
import { FlashMessagesModule, FlashMessagesService } from 'flash-messages-angular';
import { CustomerService } from './customer/customer.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    DepositComponent,
    WithdrawComponent,
    TransferComponent,
    AccountStatementComponent,
    NavbarComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    CreateCustomerComponent,
    GetCustomerDetailsComponent,
    empSidebarComponent,
    empDashboardComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    FlashMessagesModule.forRoot()
  ],
  providers: [AuthService, AuthGaurd, FlashMessagesService, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
