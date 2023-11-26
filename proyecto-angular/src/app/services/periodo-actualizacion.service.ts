import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';

import { PeriodosActualizacion } from '../interfaces/periodosActualizacion';

@Injectable({
  providedIn: 'root'
})
export class PeriodoActualizacionService {

  url = `https://${environment.apiUrl}:7214/api/PeriodosActualizacion/`;
  
  constructor(private _http : HttpClient) { }

  addFecha(periodoActualizacion: PeriodosActualizacion){
    console.log(periodoActualizacion);
    return this._http.post<any>(`${this.url}AñadirFecha`, periodoActualizacion);
  }

  getPeriodosActualizacion(){
    return this._http.get(`${this.url}GetPeriodos`);
  }


}
