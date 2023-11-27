import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionarios } from 'src/app/interfaces/funcionario';
import { FuncionarioService } from 'src/app/services/funcionario.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})


export class UserFormComponent {
  carnetsalud: boolean = false;
  nombre = "";
  apellido = "";
  ci: number | null = null;
  fecha_nacimiento = "";
  funcionarios: any[] = [];
  logId: number = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private funcionarioService: FuncionarioService) {
      this.route.params.subscribe(params => {
        this.logId = +params['logId'];     
        console.log(typeof this.logId) 
      });
     }

  onChange() {
    console.log(this.carnetsalud);
  }

  enviar() {
    if (this.apellido === '' || this.nombre === '' || this.fecha_nacimiento === '') {
      alert("Debe ingresar todos los campos");
    } else {

      this.funcionarioService.getAllFuncionarios().subscribe(
        (response:any) => {
          this.funcionarios = response;
        const funcionarioEncontrado = this.funcionarios.find(funcionario => funcionario.ci === this.ci);
        // const funcionarioEncontrado = this.funcionarios.find(funcionario => 
        //     funcionario.logId === this.logId &&
        //     funcionario.ci === this.ci &&
        //     funcionario.apellido.trim() === this.apellido.trim() &&
        //     funcionario.nombre.trim() === this.nombre.trim() &&
        //     funcionario.fch_Nacimiento=== this.fecha_nacimiento
            
        // );
      
      if(funcionarioEncontrado && funcionarioEncontrado.nombre.trim() === this.nombre.trim() && funcionarioEncontrado.apellido.trim() === this.apellido.trim() && funcionarioEncontrado.logId === this.logId && funcionarioEncontrado.fch_Nacimiento.split('T')[0] === this.fecha_nacimiento){
        if (this.carnetsalud) {
          this.router.navigate(['/carneSaludForm'], { relativeTo: this.route });
        }
        else {
          this.router.navigate([`/agendaForm/${this.ci}`], { relativeTo: this.route }); //lo manda a agendarse en la clinica ucu
        }
      }else{
        console.log(funcionarioEncontrado);

        alert("Usuario no encontrado");
      }
          
        },
        error => {
          console.log(error);
        }
      )

      
      
    }
  }
}