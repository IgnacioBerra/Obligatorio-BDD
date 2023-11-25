import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Logins } from '../interfaces/logins';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginUrl = `https://${environment.apiUrl}:7214/api/Login/`;

  constructor(private _http : HttpClient) { }

  logeo(user: Logins){
       //const url = `${this.loginUrl}Logeo?logId=${user.logId}&password=${user.password}`
      return this._http.post<string>(`${this.loginUrl}Logeo`, user);
  }

  addUser(password: string): Observable<any> {
    return this._http.post<any>(`${this.loginUrl}AddUser`, password);
  }

  deleteUser(logId: number): Observable<any> {
    return this._http.delete<any>(`${this.loginUrl}DeleteUser?logId=${logId}`); //eliminando desde..?
  }

  changePassword(logId: number, oldPassword: number, newPassword: number): Observable<any> {
    return this._http.put<any>(`${this.loginUrl}ChangePassword`, { logId, oldPassword, newPassword });
  }

}
