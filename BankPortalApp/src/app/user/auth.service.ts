import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from  '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  authToken: any;
  user:any;
  role:any;
  isLoggedIn = new BehaviorSubject(false);

  login(user:any){
    return this.http.post("https://localhost:5001/login",user);
  }

  storeUserData(token :any, user :any, role: any){
    localStorage.setItem('id_token', token);
    localStorage.setItem('user', JSON.stringify(user));
    localStorage.setItem('role', JSON.stringify(role));
    this.isLoggedIn.next(true);
  }

  getUserName() : string{
    this.user = JSON.parse(localStorage.getItem('user') || "{}");
    return this.user;
  }

  getRole() : string{
    this.role = JSON.parse(localStorage.getItem('role') || "{}");
    return this.role;
  }
  getToken(){
    this.loadToken();
    return this.authToken;
  }
  loadToken(){
    const token = localStorage.getItem('id_token');
    this.authToken = token;
  }

  loggedIn(): Observable<boolean> {
    this.loadToken();
    this.isLoggedIn.next((this.authToken !== null) ? true : false);
    return  this.isLoggedIn;
  }

  logout(){
    this.authToken= null;
    this.user = null;
    this.isLoggedIn.next(false);
    localStorage.clear();
  }

}
