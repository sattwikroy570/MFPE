import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrls: ['./style.css']
})
export class CreateCustomerComponent implements OnInit {

  constructor(
    private emp :EmployeeService,
    private flash: FlashMessagesService
  ) { }

  
  today:string = new Date().toLocaleDateString('en-CA') ;

  ngOnInit(): void {
  }

  
  onPanBlur(event:any){
    var value = (event.target as HTMLInputElement).value
    if(value.length< 10){
      this.flash.show("Enter valid Pan No", { cssClass: 'alert-danger', timeout: 5000 });
    }
  }

  onCreateCustomerSubmit(form:any){
    var customer = {CustomerId: form.custid,Name: form.CustomerName,Address: form.CustomerAddress,DateOfBirth: form.CustomerDOB,PanNumber: form.CustomerPAN};
    this.emp.createCustomer(customer).subscribe((data:any)=>{
      if(data){
        this.flash.show("Customer created sucessfully !!", { cssClass: 'alert-success', timeout: 10000 });
      }
      else{
        this.flash.show("Error couldn't create customer please try again later!", { cssClass: 'alert-danger', timeout: 10000 });
      }
    },  (err)=> {
      for(let e in err.error.errors){
            this.flash.show(err.error.errors[e], { cssClass: 'alert-danger', timeout: 10000 });
          }
    });
  }

}
