import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import { AccountStatementComponent } from './customer/account-statement.component';
import { DashboardComponent } from './customer/dashboard.component';
import { DepositComponent } from './customer/deposit.component';
import { TransferComponent } from './customer/transfer.component';
import { WithdrawComponent } from './customer/withdraw.component';
import { CreateCustomerComponent } from './employee/create-customer.component';
import { GetCustomerDetailsComponent } from './employee/get-customer-details.component';
import { HomeComponent } from './home.component';
import { LoginComponent } from './user/login.component';
import { DashboardComponent as empDashboardComponent } from './employee/dashboard.component';
import { AuthGaurd } from './user/auth.gaurd';

const routes: Routes = [  
  { path: 'login', component: LoginComponent },
  { path: 'customer/dashboard', component: DashboardComponent, canActivate: [AuthGaurd], data: {role : "Customer"} },
  { path: 'customer/deposit', component: DepositComponent, canActivate: [AuthGaurd], data: {role : "Customer"}  },
  { path: 'customer/withdraw', component: WithdrawComponent , canActivate: [AuthGaurd], data: {role : "Customer"}  },
  { path: 'customer/transfer', component: TransferComponent , canActivate: [AuthGaurd], data: {role : "Customer"}  },
  { path: 'customer/accountStatement', component: AccountStatementComponent , canActivate: [AuthGaurd], data: {role : "Customer"}  },
  { path: 'employee/dashboard', component: empDashboardComponent , canActivate: [AuthGaurd], data: {role : "Employee"}  },
  { path: 'employee/createCustomer', component: CreateCustomerComponent , canActivate: [AuthGaurd], data: {role : "Employee"} },
  { path: 'employee/getCustomerDetails', component: GetCustomerDetailsComponent , canActivate: [AuthGaurd], data: {role : "Employee"} },  
  { path: '', component: HomeComponent },  
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
