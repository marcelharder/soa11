import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Valve } from '../_models/Valve';
import { dropItem } from '../_models/dropItem';
import { hospitalValve } from '../_models/hospitalValve';
import { valveType } from '../_models/valveType';
import { valveSize } from '../_models/valveSize';

@Injectable({
    providedIn: 'root'
})
export class ValveService {

    baseUrl = environment.apiUrl;
  
    constructor(private http: HttpClient) { }

    getConduits(id: number) { return this.http.get<Valve[]>(this.baseUrl + 'Valved_Conduit/valvedConduitsFromProcedure/' + id); }
    getSpecificValvedConduit(id: number) {return this.http.get<Valve>(this.baseUrl + 'Valved_Conduit/' + id); }
    addValvedConduitInProcedure(procedure_id: number) { return this.http.post<Valve>(this.baseUrl + 'Valved_Conduit/' + procedure_id, {}); }
    saveValvedConduit(c: Valve) { return this.http.put<Valve>(this.baseUrl + 'Valved_Conduit', c, { responseType: 'text' as 'json' }); }
  
    

    getValveRepairs(id: number) { return this.http.get<Valve[]>(this.baseUrl + 'ValveRepair/valveRepairsFromProcedure/' + id); }
    getSpecificValveRepair(id: number, procedure_id:number) {return this.http.get<Valve>(this.baseUrl + 'ValveRepair/' + id + '/' + procedure_id); }
    addValveRepairInProcedure(position: string,procedure_id: number) { return this.http.post<Valve>(this.baseUrl + 'ValveRepair/' + position + '/' + procedure_id, {}); }
    saveValveRepair(c: Valve) { return this.http.put<Valve>(this.baseUrl + 'ValveRepair', c, { responseType: 'text' as 'json' }); }
  

    getValves(id: number) { return this.http.get<Valve[]>(this.baseUrl + 'Valve/valvesFromProcedure/' + id); }
    getValveFromSerial(serial: string, id: number)  { return this.http.get<Valve>(this.baseUrl + 'Valve/' + serial + '/' + id); }
    addValveInProcedure(serial: string, id: number) { return this.http.post<Valve>(this.baseUrl + 'Valve/' + serial + '/' + id, {}); }
    saveValve(c: Valve) { return this.http.put<Valve>(this.baseUrl + 'valve', c, { responseType: 'text' as 'json' }); }
    deleteValve(id: number){ return this.http.delete<string>(this.baseUrl + 'Valve/'+ id, { responseType: 'text' as 'json' });}


    getValveModels(type: string, position: string) { return this.http.get<dropItem[]>(this.baseUrl + 'Valve/models/' + type + '/' + position); }
    getValveDescription(model: string) { return this.http.get<string>(this.baseUrl + 'Valve/valveDescriptionFromModel/' + model, { responseType: 'text' as 'json' }); }
    getValveTypeDescription(id: string) { return this.http.get<string>(this.baseUrl + 'Valve/valveDescriptionFromType/' + id, { responseType: 'text' as 'json' }); }
    getHospitalValves(type: string, position: string) {return this.http.get<hospitalValve[]>(this.baseUrl + 'Valve/hospitalValves/' + type + '/' + position); }


    getSpecificHospitalValve(code: string) { return this.http.get<hospitalValve>(this.baseUrl + 'Valve/readHospitalValve/' + code); }
    deleteSpecificHospitalValve(codeId: number) { return this.http.delete<string>(this.baseUrl + 'Valve/deleteHospitalValve/' + codeId, { responseType: 'text' as 'json' }); }
    updateSpecificHospitalValve(hv: hospitalValve) { return this.http.put<string>(this.baseUrl + 'Valve/updateHospitalValve', hv, { responseType: 'text' as 'json' }); }
    createSpecificHospitalValve(hv: hospitalValve) { return this.http.post<string>(this.baseUrl + 'Valve/createHospitalValve', hv, { responseType: 'text' as 'json' }); }
    
    
    getPPM(productCode: string, size: string, weight: string, height: string) {
        let params = new HttpParams();
        params = params.append('productCode', productCode);
        params = params.append('size', size);
        params = params.append('weight', weight);
        params = params.append('height', height);
        return this.http.get<string>(this.baseUrl + 'ppm', { observe: 'response', params, responseType: 'text' as 'json' });
    }
    searchHospitalValveOnline(type: string, position: string) {
        return this.http.get<dropItem[]>(this.baseUrl + 'products/' + type + "/" + position);
    }
    getSpecificValveType(id: number) {
        return this.http.get<valveType>(this.baseUrl + 'productByValveTypeId/' + id)
    }
    getValveCodeSizes(id: number) {
        return this.http.get<valveSize[]>(this.baseUrl + 'getValveCodeSizes/' + id)
    } 




    

}


