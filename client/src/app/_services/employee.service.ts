import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Employee } from '../_models/Employee';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) { }

    getEmployeeDetails(id: number) { return this.http.get<Employee>(this.baseUrl + 'Employee/getSpecificEmployee/' + id); }
    addEmployee(profession: string) { return this.http.get<Employee>(this.baseUrl + 'Employee/addEmployee/' + profession); }
    deleteEmployee(id: number) { return this.http.delete<number>(this.baseUrl + 'Employee/deleteEmployee/' + id); }
    updateEmployee(pd: Employee) { return this.http.put<number>(this.baseUrl + 'Employee/updateEmployee', pd);}

}
