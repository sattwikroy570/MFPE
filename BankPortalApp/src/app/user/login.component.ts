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
    },(err)=>{
      if(err.error.status = 401){
        this.flash.show("Invalid Credentials", { cssClass: 'alert-danger', timeout: 10000 });
      }
      else{          
      for(let e in err.error.errors){
        this.flash.show(err.error.errors[e], { cssClass: 'alert-danger', timeout: 10000 });
        }
      }
    });
  }

}
