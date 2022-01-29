import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, JsonpClientBackend } from '@angular/common/http';
import { dropItem } from '../_models/dropItem';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DropdownService {

    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) { }


    getEmployees(hospital_id: string, job_id: string, activeState: string, liscense_to_kill: string){
        let params = new HttpParams();

          params = params.append('hospital_id', hospital_id);
          params = params.append('job_id', job_id);
          params = params.append('activeState', activeState);
          params = params.append('liscense_to_kill', liscense_to_kill);

        return this.http.get<dropItem[]>(this.baseUrl + 'dropEmployee',{ params });
    }
    isProcedureComplete(patientId: number){return this.http.get<string>(this.baseUrl + 'isComplete/'+ patientId.toString(),{ responseType: 'text' as 'json' }); }


    //#region <!-- cpb -->
    getVenousCanulation() { return this.http.get<dropItem[]>(this.baseUrl + 'ven_canulation_options'); }
    getArterialCanulation() { return this.http.get<dropItem[]>(this.baseUrl + 'art_canulation_options'); }
    getOcclusionMethod() { return this.http.get<dropItem[]>(this.baseUrl + 'occl_method'); }
    getMyoTech() { return this.http.get<dropItem[]>(this.baseUrl + 'myotech'); }
    getMPT() { return this.http.get<dropItem[]>(this.baseUrl + 'mpt'); }
    getCardioplegTiming() { return this.http.get<dropItem[]>(this.baseUrl + 'cardioplegtiming'); }
    getCardioplegTemp() { return this.http.get<dropItem[]>(this.baseUrl + 'cardioplegtemp'); }
    getDelivery() { return this.http.get<dropItem[]>(this.baseUrl + 'cardioplegdelivery'); }
    getIabpTiming() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_timing');  }
    getIabpIndication() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_ind');  }
    getTypeCardioplegia() { return this.http.get<dropItem[]>(this.baseUrl + 'typeCardiopleg'); }
    //#endregion
    //#region <!--  -->

    getGenderOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'gender_options'); }
    getWeightOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'weight_options'); }
    getHeightOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'height_options'); }
    getAgeOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'age_options'); }
    getCreatOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'creat_options'); }

    getTimingOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'timing_options'); }
    getYNOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'optionsYN'); }
    getHours() { return this.http.get<string[]>(this.baseUrl + 'dropHours'); }
    getMins() { return this.http.get<string[]>(this.baseUrl + 'dropMins'); }
    getUrgentOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'urgent_options'); }
    getEmergentOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'emergent_options'); }
    getInotropeOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'inotrope_options'); }
    getPacemakerOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'pacemaker_options'); }
    getPericardOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'pericard_options'); }
    getPleuraOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'pleura_options'); }

 //#endregion
    //#region <!-- cabg -->
    getCabgQuality() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_quality'); }
    getCabgDiameter() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_diameter'); }
    getCabgType() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_type'); }
    getCabgLocatie() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_locatie'); }
    getCabgProximal() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_proximal'); }
    getCabgConduit() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_conduit'); }
    getCabgProcedure() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_procedure'); }
    getCabgAngle() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_angle'); }
    getCabgDroplist1() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_dropList1'); }
    getCabgRadial() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_radial'); }
    getCabgLeg() { return this.http.get<dropItem[]>(this.baseUrl + 'cabg_leg'); }
    //#endregion

    getCategory_1_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 1); }
    getCategory_2_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 2); }
    getCategory_3_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 3); }
    getCategory_4_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 4); }
    getCategory_5_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 5); }
    getCategory_6_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 6); }
    getCategory_7_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 7); }
    getCategory_8_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 8); }
    getCategory_9_Options() { return this.http.get<dropItem[]>(this.baseUrl + 'addProcedureCategory/' + 9); }

    getEuroScore_Options(patientId: number) { return this.http.get<dropItem[]>(this.baseUrl + 'euroScoreOptions/' + patientId); }
    getHospitals(userId: number) {return this.http.get<dropItem[]>(this.baseUrl + 'hospitalOptions/' + userId);}


    //#region <!-- cpb -->
    getMyocardialPreservationTechnique() { return this.http.get<dropItem[]>(this.baseUrl + 'myocardialPreservationTechnique'); }
    getAC() { return this.http.get<dropItem[]>(this.baseUrl + 'art_choice'); }
    getVC() { return this.http.get<dropItem[]>(this.baseUrl + 'ven_choice'); }
    getIABPI() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_ind'); }
    getIABPT() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_timing'); }
    getNCCP() { return this.http.get<dropItem[]>(this.baseUrl + 'cpb_nccp'); }
    getAOX() { return this.http.get<dropItem[]>(this.baseUrl + 'cpb_aox'); }
    getCPB_TIMING() { return this.http.get<dropItem[]>(this.baseUrl + 'cpb_timing'); }
    getCPB_TEMP() { return this.http.get<dropItem[]>(this.baseUrl + 'cpb_temp'); }
    getCPB_delivery(i) { return this.http.get<dropItem[]>(this.baseUrl + 'cpb_delivery'); }
    getIABP_WHEN() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_when'); }
    getIABP_WHY() { return this.http.get<dropItem[]>(this.baseUrl + 'iabp_why'); }
    //#endregion

    //#region <!-- valve -->
    getAorticProcedure() { return this.http.get<dropItem[]>(this.baseUrl + 'aorticProcedure'); }
    getMitralProcedure() { return this.http.get<dropItem[]>(this.baseUrl + 'mitralProcedure'); }
    getPulmonaryProcedure() { return this.http.get<dropItem[]>(this.baseUrl + 'pulmonaryProcedure'); }
    getTricuspidProcedure() { return this.http.get<dropItem[]>(this.baseUrl + 'tricuspidProcedure'); }
    getAetiology() { return this.http.get<dropItem[]>(this.baseUrl + 'aetiology'); }
    getMitralValveRepair() { return this.http.get<dropItem[]>(this.baseUrl + 'mitralValveRepair'); }
    getTricuspidValveRepair() { return this.http.get<dropItem[]>(this.baseUrl + 'tricuspidValveRepair'); }
    getMitralRingType() { return this.http.get<dropItem[]>(this.baseUrl + 'mitralRingType'); }
    getTricuspidRingType() { return this.http.get<dropItem[]>(this.baseUrl + 'tricuspidRingType'); }
    getMitralRingsInHospital() { return this.http.get<dropItem[]>(this.baseUrl + 'mitralRingTypeInHospital'); }
    getTricuspidRingsInHospital() { return this.http.get<dropItem[]>(this.baseUrl + 'tricuspidRingTypeInHospital'); }
    getValveType() { return this.http.get<dropItem[]>(this.baseUrl + 'valveType'); }
    getImplantPosition() { return this.http.get<dropItem[]>(this.baseUrl + 'implantPosition'); }
    //#endregion

    getWoIntOptions() { return this.http.get<dropItem[]>(this.baseUrl + 'eu_weight_intervention'); }
    getPH() { return this.http.get<dropItem[]>(this.baseUrl + 'eu_pulmonary_hypertension'); }
    getNYHA() { return this.http.get<dropItem[]>(this.baseUrl + 'eu_NYHA'); }
    getLVFunction() { return this.http.get<dropItem[]>(this.baseUrl + 'eu_lv_function'); }

    //#region <!-- postop -->
    getAutoBloodTiming() { return this.http.get<dropItem[]>(this.baseUrl + 'AutoBloodTiming'); }
    getComp_options_01() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions01'); }
    getComp_options_02() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions02'); }
    getComp_options_03() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions03'); }
    getComp_options_04() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions04'); }
    getComp_options_05() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions05'); }
    getComp_options_06() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions06'); }
    getComp_options_07() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions07'); }
    getComp_options_08() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions08'); }
    getComp_options_09() { return this.http.get<dropItem[]>(this.baseUrl + 'complicationOptions09'); }
    //#endregion

    //#region <!-- discharge -->
    getActivitiesDischarge() { return this.http.get<dropItem[]>(this.baseUrl + 'discharge_activities'); }
    getDischargeDiagnosis() { return this.http.get<dropItem[]>(this.baseUrl + 'discharge_diagnosis'); }
    getDischargeDirection() { return this.http.get<dropItem[]>(this.baseUrl + 'discharge_direction'); }
    getMortalityLocation() { return this.http.get<dropItem[]>(this.baseUrl + 'dead_location'); }
    getMortalityCause() { return this.http.get<dropItem[]>(this.baseUrl + 'dead_cause'); }
    getMortality() { return this.http.get<dropItem[]>(this.baseUrl + 'dead'); }
    //#endregion

    //#region <!-- user edit -->
    getAllCountries() { return this.http.get<dropItem[]>(this.baseUrl + 'countriesDrops'); }
    getAllCities() { return this.http.get<dropItem[]>(this.baseUrl + 'citiesDrops'); }
    getRoles() { return this.http.get<dropItem[]>(this.baseUrl + 'roles'); }
    getCareerTopics(){return this.http.get<dropItem[]>(this.baseUrl + 'career');}
    // tslint:disable-next-line: max-line-length
    getAllHospitalsPerCountry(countryId: number) {
         return this.http.get<dropItem[]>(this.baseUrl + 'allHospitalOptionsPerCountry/' + countryId); }
    //#endregion

     //#region <!-- aneurysm -->
    getAneurysmType() { return this.http.get<dropItem[]>(this.baseUrl + 'aneurysmType'); }
    getDissectionOnset() { return this.http.get<dropItem[]>(this.baseUrl + 'dissectionOnset'); }
    getDissectionType() { return this.http.get<dropItem[]>(this.baseUrl + 'dissectionType'); }
    getPathology() { return this.http.get<dropItem[]>(this.baseUrl + 'pathology'); }
    getOpIndication() { return this.http.get<dropItem[]>(this.baseUrl + 'opIndication'); }
    getOpTechnique() { return this.http.get<dropItem[]>(this.baseUrl + 'optechnique'); }
    getRangeReplacement() { return this.http.get<dropItem[]>(this.baseUrl + 'rangeReplacement'); }
    //#endregion

    //#region <!-- ltx -->
    getLtxIndication() { return this.http.get<dropItem[]>(this.baseUrl + 'dropLtxIndication'); }
    getLtxType() { return this.http.get<dropItem[]>(this.baseUrl + 'dropLtxType'); }

     //endregion

    getConversionDetails() { return this.http.get<dropItem[]>(this.baseUrl + 'conversionDetails'); }
    getStrategy() { return this.http.get<dropItem[]>(this.baseUrl + 'strategy'); }
    getPrimary_incision() { return this.http.get<dropItem[]>(this.baseUrl + 'primaryIncision'); }
    getFollow1() { return this.http.get<dropItem[]>(this.baseUrl + 'follow1'); }
    getFollow2() { return this.http.get<dropItem[]>(this.baseUrl + 'follow2'); }
    getLimaHarvest() { return this.http.get<dropItem[]>(this.baseUrl + 'limaHarvest'); }
    getStabilization() { return this.http.get<dropItem[]>(this.baseUrl + 'stabilization'); }
    getSuture_technique() { return this.http.get<dropItem[]>(this.baseUrl + 'sutureTechnique'); }
    getFollow3() { return this.http.get<dropItem[]>(this.baseUrl + 'follow3'); }

    getAllHospitals() { return this.http.get<dropItem[]>(this.baseUrl + 'allHospitals'); }
    

}
