import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionarios } from '../../interfaces/funcionario';
import { FuncionarioService } from '../../services/funcionario.service';


@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})


export class RegisterFormComponent {
  carnetsalud: boolean = false;
  nombre = "";
  apellido = "";
  direccion =  "";
  email = "";
  password = "";
  telefono: number | null = null;
  ci: number | null = null;
  fecha_nacimiento = "";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private funcService: FuncionarioService) { }

  onChange(event: any) {
    this.carnetsalud = event.target.checked;
    console.log(this.carnetsalud);
  }

  signIn() {
    if(this.nombre && this.apellido && this.fecha_nacimiento && this.ci && this.telefono && this.direccion && this.email){
      const fechaNacimientoFormateada = new Date(this.fecha_nacimiento).toISOString();
      
      let funcionario: Funcionarios = {
        CI: this.ci,
        Nombre: this.nombre,
        Apellido: this.apellido,
        Fch_Nacimiento: fechaNacimientoFormateada,
        Direccion: this.direccion,
        Telefono: this.telefono,
        Email: this.email,
        Password: this.password
      }

      this.funcService.addFuncionario(funcionario).subscribe(
        response => {
       
          console.log('Solicitud POST exitosa:', {response});
          alert("LOGID: "+ response.message)
          if (this.carnetsalud) {
            this.router.navigate([`/carneSaludForm/${funcionario.CI}`], { relativeTo: this.route });
          } else {
            this.router.navigate([`/agendaForm/${funcionario.CI}`], { relativeTo: this.route }); //lo manda a agendarse en la clinica ucu
          }
          
        },
        error => {
          console.error('Error en la solicitud POST:', error);
          console.error('body de la respuesta:', error.error);
        }
      );    
    }else{
      alert("Campos obligatorios!");
    }
  }

}