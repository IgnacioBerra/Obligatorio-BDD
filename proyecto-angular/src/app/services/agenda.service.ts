import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { Agenda } from '../interfaces/agenda';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  url = `https://${environment.apiUrl}:7214/api/Agenda/`;
  
  constructor(private _http : HttpClient) { }

  addAgenda(agenda: Agenda){
    return this._http.post<any>(`${this.url}addAgenda`, agenda);
  }

  getAgenda(){
    return this._http.get(`${this.url}ConseguirAgenda`);
  }

}