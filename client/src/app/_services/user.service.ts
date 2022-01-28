import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl= environment.apiUrl;
  constructor(private http: HttpClient) { }

  
  getUserFromId(id: number){return this.http.get<User>(this.baseUrl + 'users/' + id)};
}
