import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from '../user/auth.service';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./style.css']
})
export class WithdrawComponent implements OnInit {

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

  onWithdrawSubmit(form:any) {
    var AccountID = {AccountId: +form.AccountID,Amount: form.Amount};
    this.cust.withdraw(AccountID).subscribe((data:any)=>{
      if(data.message != "Warning"){
        if(data.message === "Inscufficient Balance"){          
          this.flash.show(data.message, { cssClass: 'alert-danger', timeout: 10000 });
        }
        else{          
          this.flash.show("Acc ID : "+data.accountId + " " + data.message + " Balance : Rs." + data.balance, { cssClass: 'alert-success', timeout: 10000 });
        }
      }
      else{
        this.flash.show("Warning !! Minimum Balance should be Rs.500", { cssClass: 'alert-danger', timeout: 10000 });
      }
    }, (err)=> {
      for(let e in err.error.errors){
            this.flash.show(err.error.errors[e], { cssClass: 'alert-danger', timeout: 10000 });
      }
    });
  }
}
