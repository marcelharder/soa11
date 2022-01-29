import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { RefPhysModel } from '../_models/RefPhysModel';
import { dropItem } from '../_models/dropItem';
import { EmailModel } from '../_models/EmailModel';

@Injectable()
export class RefPhysService {
    baseUrl = environment.apiUrl;
   
    constructor(private http: HttpClient) { }

    getSpecificRefPhys(id: number) { return this.http.get<RefPhysModel>(this.baseUrl + 'specificRefPhys/' + id); }

    updateRefPhys(c: RefPhysModel) { return this.http.put<RefPhysModel>(this.baseUrl + 'updateRefPhys/', c); }

    addRefPhys() { return this.http.get<RefPhysModel>(this.baseUrl + 'addRefPhys'); }

    deleteRefPhys(id: number) { return this.http.delete<number>(this.baseUrl + 'deleteRefPhys/' + id);}

    getRefPhys(id: number) { return this.http.get<dropItem[]>(this.baseUrl + 'AllRefPhys/' + id); }

    sendEmail(e: EmailModel) // Use the config service to send email
    {
        return this.http.post<string>(this.baseUrl + 'sendEmail', e,{ responseType: 'text' as 'json' });
    }


}
