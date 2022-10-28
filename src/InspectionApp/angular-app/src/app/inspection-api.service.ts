import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const headers = new HttpHeaders()
   .set('Access-Control-Allow-Origin', '*');
@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inspectionAPIUrl = "http://192.168.2.11:7223";

  


  constructor(private http:HttpClient) {
    
   }

  getInspectionList():Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + '/inspections');
    
  }

  addInspection(data:any) {
    return this.http.post(this.inspectionAPIUrl + '/inspections', data,{ 'headers': headers });
  }

  updateInspection(id:number|string, data:any) {
    return this.http.put(this.inspectionAPIUrl + `/inspections/${id}`, data,{ 'headers': headers });
  }

  deleteInspection(id:number|string) {
    return this.http.delete(this.inspectionAPIUrl + `/inspections/${id}`,{ 'headers': headers });
  }

  // Inspection Types
  getInspectionTypesList():Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + '/inspectionTypes',{ 'headers': headers });
  }

  addInspectionTypes(data:any) {
    return this.http.post(this.inspectionAPIUrl + '/inspectionTypes', data,{ 'headers': headers });
  }

  updateInspectionTypes(id:number|string, data:any) {
    return this.http.put(this.inspectionAPIUrl + `/inspectionTypes/${id}`, data,{ 'headers': headers });
  }

  deleteInspectionTypes(id:number|string) {
    return this.http.delete(this.inspectionAPIUrl + `/inspectionTypes/${id}`,{ 'headers': headers });
  }

  // Statuses
  getStatusList():Observable<any[]> {
    return this.http.get<any>(this.inspectionAPIUrl + '/status',{ 'headers': headers });
  }

  addStatus(data:any) {
    return this.http.post(this.inspectionAPIUrl + '/status', data,{ 'headers': headers });
  }

  updateStatus(id:number|string, data:any) {
    return this.http.put(this.inspectionAPIUrl + `/status/${id}`, data,{ 'headers': headers });
  }

  deleteStatus(id:number|string) {
    return this.http.delete(this.inspectionAPIUrl + `/status/${id}`,{ 'headers': headers });
  }
}
