import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Agenda } from 'src/app/interfaces/agenda';
import { AgendaService } from 'src/app/services/agenda.service';


@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css']
})
export class AgendaFormComponent {
  fecha = '';
  ci: number | null = null;

  constructor(private agendaService: AgendaService, private router: Router){}

  enviarAgenda(){
    if(this.fecha != '' && this.ci != null){
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
  }
}