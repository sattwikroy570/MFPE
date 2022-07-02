import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router'
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

    canActivate(){
        this.auth.loggedIn().subscribe((value:boolean)=>{
           this.isLoggedin=value;
        });
        if(this.isLoggedin){
            return true;
        } 
        else {
            this.flash.show('You must login first.', { cssClass: 'alert-danger' } );
            this.router.navigate(['/login']);
        
        return false;
        }
    }

}

