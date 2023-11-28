import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { CarnetSalud } from '../interfaces/carnetSalud';

@Injectable({
  providedIn: 'root'
})
export class CarnetSaludService {

  url = `https://${environment.apiUrl}:7214/api/CarnetSalud/`;
  
  constructor(private _http : HttpClient) { }

  AñadirCarnetSalud(carnet: CarnetSalud){
    return this._http.post<any>(`${this.url}AñadirCarnetSalud`, carnet);
  }

  ConseguirCarnetSalud(){
    return this._http.get(`${this.url}ConseguirCarnetSalud`);
  }

}