import { Component, OnInit } from '@angular/core';
import { AuthService } from './user/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  constructor(
    private auth: AuthService
  ) { }
  
  isLoggedIn : any;
  isEmployee:any;

  ngOnInit(): void {
    this.auth.loggedIn().subscribe((value:boolean) => {
      this.isLoggedIn = value;
    });
    this.isEmployee = this.auth.getRole() == "Employee" ? true : false;
  }

}
