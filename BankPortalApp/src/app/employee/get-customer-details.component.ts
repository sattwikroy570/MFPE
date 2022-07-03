import { Component, OnInit } from '@angular/core';
import { FlashMessagesService } from 'flash-messages-angular';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-get-customer-details',
  templateUrl: './get-customer-details.component.html',
  styleUrls: ['./style.css']
})
export class GetCustomerDetailsComponent implements OnInit {

  constructor(
    private emp: EmployeeService,
    private flash: FlashMessagesService
  ) { }

  
  id:any;
  userDetails:any = null;

  ngOnInit(): void {
  }
  onGetCustomerdetailsSubmit(form:any){
      this.id = form.EmployeeID;
      this.emp.getCustomerDetails(this.id).subscribe((data:any)=>{
        if(data){            
          this.userDetails = data;
        }
      },  (err)=> {
              this.flash.show(err.error.title, { cssClass: 'alert-danger', timeout: 10000 });
      });
  }

}
