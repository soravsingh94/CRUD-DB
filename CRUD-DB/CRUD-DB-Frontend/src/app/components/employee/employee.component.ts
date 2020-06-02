import { EmployeeService } from './../../services/employee.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})

export class EmployeeComponent implements OnInit {

  employeeList: any;
  columns: any;
  constructor(private employeeService: EmployeeService) {

  }

  ngOnInit() {
    this.columns = this.getGridColumns();
    this.employeeService.getEmployee().subscribe(response => {
      this.employeeList = response;
    });
  }

  getGridColumns() {
    return [
      this.getGridColumnProperty('Name', 'Name'),
      this.getGridColumnProperty('Age', 'Age'),
      this.getGridColumnProperty('Gender', 'Gender'),
      this.getGridColumnProperty('Contact', 'Contact'),
      this.getGridColumnProperty('DOB', 'DOB'),
      this.getGridColumnProperty('EmailId', 'Email'),
    ]
  }

  getGridColumnProperty(field: string, displayName: string) {
    return {
      field,
      header: displayName
    };
  }
}
