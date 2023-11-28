import { Component } from '@angular/core';
import { PeriodoActualizacionService } from 'src/app/services/periodo-actualizacion.service';


@Component({
  selector: 'app-date-admin',
  templateUrl: './date-admin.component.html',
  styleUrls: ['./date-admin.component.css']
})
export class DateAdminComponent {
  fechaActual: Date = new Date();
  fechaActualización: Date = new Date();
  tiempoRestanteAct: any = {};
  dateText = '';


  constructor(private periodoService: PeriodoActualizacionService) {

    this.periodoService.getPeriodosActualizacion().subscribe(
      (response: any) => {
        this.fechaActualización = response[0].fch_Fin;
        console.log("fecha Actualizacion ", this.fechaActualización);
        let actualizada = new Date(this.fechaActualización);

        const fechaActual: Date = new Date();
        const tiempoRestante = actualizada.getTime() - fechaActual.getTime();
        this.tiempoRestanteAct.dias = Math.floor(tiempoRestante / (1000 * 60 * 60 * 24));
        this.tiempoRestanteAct.horas = Math.floor((tiempoRestante % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        this.tiempoRestanteAct.minutos = Math.floor((tiempoRestante % (1000 * 60 * 60)) / (1000 * 60));
        if (this.tiempoRestanteAct.dias < 0) {
          this.dateText += 'La fecha de actualización ha vencido';
        } else {
          this.dateText += 'Faltan: ' + this.tiempoRestanteAct.dias + ' días, ' + this.tiempoRestanteAct.horas + ' horas y ' + this.tiempoRestanteAct.minutos + ' minutos para que el periodo de actualización finalice'
        }
      }
    )
  }

}