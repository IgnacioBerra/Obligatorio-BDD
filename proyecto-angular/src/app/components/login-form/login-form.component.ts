import { Component } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Logins } from '../../interfaces/logins';

import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {

  password: string = "";
  logId = null; 

  constructor(private loginService: LoginService,  private router: Router) {
  }

  log() {

    if ((this.logId) && (this.password != "")) {
       let login: Logins = {
           logId: this.logId,
           password: this.password
         }
         
      
      this.loginService.logeo(login).subscribe(
        response => {
          console.log(login.logId);
          if(login.logId == 1 && login.password == 'admin')  {
          this.router.navigate(['/indexAdmin']);
        }else{
          this.router.navigate([`/userForm/${login.logId}`]);
        }
        },
        error => {
          console.error('Error:', error);
          alert("Usuario no encontrado")
          return;
        }
      );
       
    
  }else{
    alert("Campos obligatorios")
  }
  }
}