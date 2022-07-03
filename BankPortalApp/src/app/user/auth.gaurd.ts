import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router'
import { FlashMessagesService } from 'flash-messages-angular';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
  })
export class AuthGaurd implements CanActivate {
    constructor( 
        private router: Router,
        private auth : AuthService,
        private flash : FlashMessagesService
        )
        { }

        isLoggedin:boolean = false;

    canActivate(route: ActivatedRouteSnapshot) {
        this.auth.loggedIn().subscribe((value:boolean)=>{
           this.isLoggedin=value;
        });
        if(this.isLoggedin){
            if(this.auth.getRole() == route.data['role']){
                return true;
            }
            else{ 
                console.log(this.auth.getRole,route.data['role']);                  
                this.flash.show('Acess Denied.', { cssClass: 'alert-danger' } );
                this.router.navigate(['']);
                return false;
            }
        } 
        else {
            this.flash.show('You must login first.', { cssClass: 'alert-danger' } );
            this.router.navigate(['/login']);
        return false;
        }
    }

}

