import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from '../user/auth.service';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-account-statement',
  templateUrl: './account-statement.component.html',
  styleUrls: ['./style.css']
})
export class AccountStatementComponent implements OnInit {

  constructor(
    private cust: CustomerService, 
    private flash: FlashMessagesService,
    private auth: AuthService
  ) { }

  userName:any;  
  customerAccounts:any;
  accountStatements:any = [];

  ngOnInit(): void {    
    this.userName = this.auth.getUserName();
    this.cust.getUserAccounts(this.userName).subscribe((data:any) => {
      this.customerAccounts = data;
    });
  }
  onAccountStatementSubmit(form:any){
    this.cust.getAccountStatement(+form.AccountID, form.to_date, form.from_date).subscribe((data:any)=>{
      this.accountStatements = data;
      console.log(this.accountStatements);
    }, (error)=> {
      console.log(error)
      this.flash.show("Error! Sorry couldn't  complete your request", { cssClass: 'alert-danger', timeout: 10000 });
    });
  }

}
