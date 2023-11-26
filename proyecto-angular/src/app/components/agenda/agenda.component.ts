import { Component } from '@angular/core';
import { AgendaService } from 'src/app/services/agenda.service';

@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styleUrls: ['./agenda.component.css']
})
export class AgendaComponent {
  agendas: any[] = [];
  error: boolean = false;
  
  constructor(private agendaService: AgendaService) {
    this.getAgendas();
  }

  

  getAgendas(){
    this.agendaService.getAgenda().subscribe(
      (response: any) => {
        this.agendas = response;
      },
      (error: any) => {
        console.log(error);
        this.error = true;
      }
    )
  }

}
