import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { GraphModel } from '../_models/GraphModel';
import { CasesPerMonthModel } from '../_models/CasesPerMonthModel';

@Injectable()
export class GraphService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getVlad(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'vladGraphPerHospital/' + userId + '/' + id); }
    getCM(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'cmGraphPerHospital/' + userId + '/' + id); }
    getAge(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'ageGraphPerHospital/' + userId + '/' + id); }
    getBand(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'euroGraphPerHospital/' + userId + '/' + id); }
    getPM(userId: number,id: number) {return this.http.get<CasesPerMonthModel>(this.baseUrl + 'proceduresPerMonthGraphPerHospital/' + userId + '/' + id); }
    getPY(userId: number,id: number) {return this.http.get<GraphModel>(this.baseUrl + 'proceduresPerYearGraphPerHospital/' + userId + '/' + id); }
}
