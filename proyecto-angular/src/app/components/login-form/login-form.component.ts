import { Component } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Logins } from '../../interfaces/logins';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {

  password: string = "";
  logId = null; 

  constructor(private loginService: LoginService, private toastr: ToastrService, private router: Router) {
  }

  log() {

    if ((this.logId) && (this.password != "")) {
       let login: Logins = {
           logId: this.logId,
           password: this.password
         }
         
      this.loginService.logeo(login).subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/indexAdmin']);
        },
        error => {
          console.error('Error:', error);
          this.toastr.error("Usuario no encontrado");
          return;
        }
      );
       
    }else{
      this.toastr.error("Los campos son obligatorios", "Error");
    }
  }
}
