import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../user/auth.service';

@Injectable({
  providedIn: 'root'
})



export class CustomerService {

  constructor(
    private http: HttpClient,
    private auth : AuthService
  ) { }

  
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization':'bearer '+this.auth.getToken() 
  });

  httpOptions = {headers : this.headers};
  
  getUserAccounts(user:any){
      return this.http.get("https://localhost:5001/Accounts/getCustomerAccounts/"+user,this.httpOptions);
  }
  deposit(data:any){
    return this.http.post("https://localhost:5001/Transaction/Deposit",data,this.httpOptions);
  }
  withdraw(data:any){
    return this.http.post("https://localhost:5001/Transaction/Withdraw",data,this.httpOptions);
  }
  transfer(data:any){
    return this.http.post("https://localhost:5001/Transaction/Transfer",data,this.httpOptions);
  }
  getAccountStatement(acc:any,toDate:any,fromDate:any){
    return this.http.get("https://localhost:5001/Accounts/getStatement/"+acc+"/"+fromDate+"/"+toDate,this.httpOptions);
}
}
