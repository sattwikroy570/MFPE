import { Component, OnInit } from '@angular/core';
import { AuthService } from '../user/auth.service';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./style.css']
})
export class DashboardComponent implements OnInit {

  constructor(
    private cs: CustomerService,
    private auth: AuthService
  ) { }

  userName:any;
  customerAccounts:any = [];

  ngOnInit(): void {
      this.userName = this.auth.getUserName();
      this.cs.getUserAccounts(this.userName).subscribe((data:any) => {
        this.customerAccounts = data;
      });
  }

}
