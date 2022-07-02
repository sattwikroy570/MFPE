import { Component, OnInit } from '@angular/core';
import { AuthService } from '../user/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {

  constructor(
    private auth : AuthService
    ) { }

  isLoggedIn : any;

  ngOnInit(): void {
    this.auth.loggedIn().subscribe((value:boolean) => {
      this.isLoggedIn = value;
    });
  }
  onLogoutClick(){
    this.auth.logout()
  }

}
