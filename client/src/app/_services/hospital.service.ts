import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HospitalService {
  baseUrl = environment.apiUrl;
 

  constructor(private http: HttpClient) { }
  getHospitalNameFromId(hospital_id: number) {
    return this.http.get<string>(this.baseUrl + "hospital/getHospitalNameFromId/" + hospital_id, { responseType: 'text' as 'json'} );
  }




}
