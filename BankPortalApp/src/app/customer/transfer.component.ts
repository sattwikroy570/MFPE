import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from '../user/auth.service';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./style.css']
})
export class TransferComponent implements OnInit {

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

  onTransferSubmit(form:any) {
    var AccountID = {SourceAccountId: +form.sourceAccountID, DestinationAccountId : form.destinationAccountID, Amount: form.Amount};
    this.cust.transfer(AccountID).subscribe((data:any)=>{
      if(data.message != "Warning"){
        this.flash.show(data.message + " Balance : Rs." + data.balance, { cssClass: 'alert-success', timeout: 10000 });
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
