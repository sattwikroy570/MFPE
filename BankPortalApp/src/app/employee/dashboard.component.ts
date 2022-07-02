import { Component, OnInit } from '@angular/core';
import { AuthService } from '../user/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./style.css']
})
export class DashboardComponent implements OnInit {

  constructor(
    private auth: AuthService
  ) { }

  userName:any;
  ngOnInit(): void {
      this.userName = this.auth.getUserName();
  }

}
