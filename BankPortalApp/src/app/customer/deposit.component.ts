import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from '../user/auth.service';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./style.css']
})
export class DepositComponent implements OnInit {

  constructor(
    private cust : CustomerService,
    private flash : FlashMessagesService,
    private auth: AuthService
  ) { }

  userName:any;
  AccountId:any;
  customerAccounts:any = [];

  ngOnInit(): void {
    this.userName = this.auth.getUserName();
    this.cust.getUserAccounts(this.userName).subscribe((data:any) => {
      this.customerAccounts = data;
    });
  }

  onAmountBlur(event:any){
    var value = (event.target as HTMLInputElement).value
    if(+value< 0){
      this.flash.show("Amount cannot be negative", { cssClass: 'alert-danger', timeout: 5000 });
    }
  }
  onDepositSubmit(form:any) {
    var Account = {AccountId: +form.AccountID, Amount: form.Amount};
    this.cust.deposit(Account).subscribe((data:any)=>{
        this.flash.show("Acc ID : "+data.accountId + " " + data.message + " Balance : Rs." + data.balance, { cssClass: 'alert-success', timeout: 10000 });
    } ,(err)=> {
      for(let e in err.error.errors){
            this.flash.show(err.error.errors[e], { cssClass: 'alert-danger', timeout: 10000 });
          }
    });
  }

}
