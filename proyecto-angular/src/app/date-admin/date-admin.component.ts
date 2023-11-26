import { Component } from '@angular/core';

@Component({
  selector: 'app-date-admin',
  templateUrl: './date-admin.component.html',
  styleUrls: ['./date-admin.component.css']
})
export class DateAdminComponent {
  fechaActual: Date = new Date();
  fechaActualización: Date = new Date('2023-11-25T23:59:59'); //esta fecha se va a obtener desde la bd
  tiempoRestanteAct: any = {};
  dateText = '';

  constructor() {
    this.calcularDiasRestantes();
  }

  calcularDiasRestantes() {
    const fechaActual = new Date();
    const tiempoRestante = this.fechaActualización.getTime() - fechaActual.getTime();
    this.tiempoRestanteAct.dias = Math.floor(tiempoRestante / (1000 * 60 * 60 * 24));
    this.tiempoRestanteAct.horas = Math.floor((tiempoRestante % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    this.tiempoRestanteAct.minutos = Math.floor((tiempoRestante % (1000 * 60 * 60)) / (1000 * 60));
    if (this.tiempoRestanteAct.dias<0) {
      this.dateText+='La fecha de actualización ha vencido';
    }else{
      this.dateText+='Faltan: '+this.tiempoRestanteAct.dias +'días,'+ this.tiempoRestanteAct.horas +' horas y '+ this.tiempoRestanteAct.minutos +' minutos para que el periodo de actualización finalice'
    }
  }
}
