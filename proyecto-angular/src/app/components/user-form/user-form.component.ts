import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionarios } from 'src/app/interfaces/funcionario';
import { FuncionarioService } from 'src/app/services/funcionario.service';
import { AgendaService } from 'src/app/services/agenda.service';

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
  agenda : any[] = [];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private funcionarioService: FuncionarioService,private agendaService : AgendaService) {
      this.route.params.subscribe(params => {
        this.logId = +params['logId'];     
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
      
      if(funcionarioEncontrado && funcionarioEncontrado.nombre.trim() === this.nombre.trim() && funcionarioEncontrado.apellido.trim() === this.apellido.trim() && funcionarioEncontrado.logId === this.logId && funcionarioEncontrado.fch_Nacimiento.split('T')[0] === this.fecha_nacimiento){
        this.agendaService.getAgenda().subscribe((response:any)=>{
          this.agenda = response;
        })
        if (this.carnetsalud) {
          this.router.navigate([`/carneSaludForm/${this.ci}`], { relativeTo: this.route });
        }
        else if(this.agenda.find(agendado => agendado.ci === this.ci)== null){
          
            alert('Usted ya esta agendado');
            this.router.navigate([`/login/`], { relativeTo: this.route });
        }else{
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