import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { Funcionarios } from '../interfaces/funcionario';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {

  url = `https://${environment.apiUrl}:7214/api/Funcionarios/`;
  
  constructor(private _http : HttpClient) { }

  addFuncionario(func: Funcionarios){
    return this._http.post<any>(`${this.url}AddFuncionario`, func);
  }

  getAllFuncionarios(){
    return this._http.get(`${this.url}ConseguirFuncionarios`);
  }

  getFuncionariosActualizados(){
    return this._http.get(`https://${environment.apiUrl}:7214/api/ActualizacionFuncionario/GetActualizaciones`);
  }

}