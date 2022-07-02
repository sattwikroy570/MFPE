import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private router: Router,
    private auth : AuthService,
    private flash: FlashMessagesService
    ) { }

  ngOnInit(): void {

  }
  onLoginSubmit(form:any){
    var user = {
      UserName: form.username,
      Password: form.password,
      Roles: form.role
    }
    this.auth.login(user).subscribe((data:any) => {
        if(data.sucess==true){
          this.auth.storeUserData(data.token, user.UserName, user.Roles);
          this.flash.show('Succesfully Logged in. ',{ cssClass: 'alert-success' } );
          if(user.Roles == "Customer"){          
            this.router.navigate(['customer/dashboard']);
          }
          else{                   
            this.router.navigate(['employee/dashboard']);
          }
        }
        else{
          this.flash.show('Unable to login! ', { cssClass: 'alert-danger' } );
        }      
      });
    }

}
