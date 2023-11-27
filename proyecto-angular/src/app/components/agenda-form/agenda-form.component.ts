import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agenda } from 'src/app/interfaces/agenda';
import { AgendaService } from 'src/app/services/agenda.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css']
})
export class AgendaFormComponent {
  fecha = '';
  ci: number | null = null;
  cedula: number = 0;

  constructor(private agendaService: AgendaService, private router: Router, private _location: Location, private route: ActivatedRoute,){
    this.route.params.subscribe(params => {
      this.cedula = +params['ci'];     
    });
  }

  enviarAgenda(){
    if(this.fecha != '' && this.ci != null){
      if(this.cedula !== this.ci){
        alert("Cédula no coincide")
      }else{
      const fch_Agenda = new Date(this.fecha).toISOString();
      
      let agenda: Agenda = {
        ci: this.ci,
        fch_Agenda: fch_Agenda
      }
      
      this.agendaService.addAgenda(agenda).subscribe(
        (response: any) => {
          this.router.navigate(['/login']);
          console.log("enviada");
        },
        (error: any) => {
          console.error('Error:', error);
          console.log(error.error);
        }
      );
      }
    }else{
      alert("Campos obligatorios!")
    }
  }

  goBack(): void{
    this._location.back();
  }
}