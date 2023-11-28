import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PeriodoActualizacionService } from '../../services/periodo-actualizacion.service';
import { PeriodosActualizacion } from '../../interfaces/periodosActualizacion';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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

  constructor(private router: Router, private periodoService: PeriodoActualizacionService) {
  }

  agregarFecha(formulario: any) {

   
      if (this.fechaDesde == '') {
        this.fechaDesdeInvalida = true;
      } if (this.fechaHasta == '') {
        this.fechaHastaInvalida = true;
      } else {
        this.fechaDesdeInvalida = this.fechaDesde > this.fechaHasta;
        this.fechaHastaInvalida = this.fechaDesde > this.fechaHasta
      }

      if(!this.fechaDesdeInvalida && !this.fechaHastaInvalida){
      //cambiando formato a fecha, para utilizar los metodos
      const fechaDesdeDate: Date = new Date(this.fechaDesde);
      const fechaHastaDate: Date = new Date(this.fechaHasta);

      const añoDesde: number = fechaDesdeDate.getFullYear();
      const mesDesde: number = fechaDesdeDate.getMonth() + 1;

      const añoHasta: number = fechaHastaDate.getFullYear();
      const mesHasta: number = fechaHastaDate.getMonth() + 1;


      let semestre: number;

      if (
        (mesDesde >= 1 && mesDesde <= 7 && añoDesde === añoHasta && mesHasta >= 1 && mesHasta <= 7)
      ) {
        semestre = 1;
      } else if (

        (mesDesde >= 8 && mesDesde <= 12 && añoDesde === añoHasta && mesHasta >= 8 && mesHasta <= 12)
      ) {
        semestre = 2;
      } else {
        semestre = 0;
      }


      const Fch_Inicio = fechaDesdeDate.toISOString().split('T')[0];
      const Fch_Fin = fechaHastaDate.toISOString().split('T')[0];

      console.log(Fch_Fin)
      console.log(Fch_Inicio)
      let periodoActualizacion: PeriodosActualizacion = {
        Año: añoDesde,
        Semestre: semestre,
        Fch_Inicio: Fch_Inicio,
        Fch_Fin: Fch_Fin
      }


      this.periodoService.getPeriodosActualizacion().subscribe(
        (response: any) => {
          if (response.length !== 0) {
            const nuevaFecha = {
              fechaAnteriorInicio: response[0].fch_Inicio,
              fechaNuevaInicio: periodoActualizacion.Fch_Inicio,
              fechaAnteriorFin: response[0].fch_Fin,
              fechaNuevaFin: periodoActualizacion.Fch_Fin,
              semestre: periodoActualizacion.Semestre,
              año: periodoActualizacion.Año
            }
            
          this.periodoService.cambiarFecha(nuevaFecha).subscribe(
            response => {
              console.log(response);
              this.router.navigate(['/indexAdmin/displayFunc']);
            },
            error => {
              console.log(error);
            }
          )
          } else {
            this.periodoService.addFecha(periodoActualizacion).subscribe(
              response => {
                console.log(response);
                this.router.navigate(['/indexAdmin/displayFunc']);
              },
              error => {
                console.log(error);
                console.log("ERROR: ", error.error);
              }
            );
          }
        },
        (error: any) => {
          console.log(error);
        }
      );
    
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