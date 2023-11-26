import { Component } from '@angular/core';

@Component({
  selector: 'app-agregar-fecha',
  templateUrl: './agregar-fecha.component.html',
  styleUrls: ['./agregar-fecha.component.css']
})
export class AgregarFechaComponent {

  fechaDesde: string = '';
  fechaHasta: string = '';
  fechaDesdeInvalida: boolean = false;
  fechaHastaInvalida: boolean = false;
  errorText = '';


  guardarFecha(formulario: any): void {
    console.log(this.fechaDesde);
    if (this.fechaDesde == '') {
      this.fechaDesdeInvalida = true;
    } if (this.fechaHasta == '') {
      this.fechaHastaInvalida = true;
    } else {
      this.fechaDesdeInvalida = this.fechaDesde > this.fechaHasta;
      this.fechaHastaInvalida = this.fechaDesde > this.fechaHasta
    }
  }

  // Función para verificar si la fecha desde es inválida
  esFechaDesdeInvalida(): boolean {
    if (this.fechaDesde == '') {
      this.errorText = 'Por favor complete este campo';
    } else {
      if (this.fechaDesdeInvalida) {
        this.errorText = 'La fecha desde no puede ser mayor que la fecha hasta.'
      }
    }
    return this.fechaDesdeInvalida;
  }

  // Función para verificar si la fecha hasta es inválida
  esFechaHastaInvalida(): boolean {
    if (this.fechaHasta == '') {
      this.errorText = 'Por favor complete este campo';
    } else {
      if (this.fechaHastaInvalida) {
        this.errorText = 'La fecha hasta no puede ser menor que la fecha desde.'
      }
    }
    return this.fechaHastaInvalida;
  }
}
