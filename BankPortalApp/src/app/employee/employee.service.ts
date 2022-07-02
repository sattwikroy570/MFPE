import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../user/auth.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(    
    private http: HttpClient,
    private auth: AuthService
  ) { }

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization':'bearer '+this.auth.getToken() 
  });

  httpOptions = {headers : this.headers};
  
  getCustomerDetails(id:any){
    return this.http.get("https://localhost:5001/Customer/getDetails/"+id,this.httpOptions);
  }
  createCustomer(data:any){
    return this.http.post("https://localhost:5001/Customer/create",data,this.httpOptions);
  }
}
