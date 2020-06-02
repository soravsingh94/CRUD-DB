import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../models/constant/literals';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {

  constructor(private http: HttpClient) {
  }

  getEmployee() {
    return this.http.get(ApiConstant.getEmployeeUrl);
  }
}
