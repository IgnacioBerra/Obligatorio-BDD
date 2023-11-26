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

  fechaDesde = '';
  fechaHasta = '';

  constructor(private router: Router, private periodoService: PeriodoActualizacionService) {
  }

  agregarFecha() {

    if (this.fechaDesde && this.fechaHasta) {

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


      const Fch_Inicio = fechaDesdeDate.toISOString();
      const Fch_Fin = fechaHastaDate.toISOString();

      let periodoActualizacion: PeriodosActualizacion = {
        Año: añoDesde,
        Semestre: semestre,
        Fch_Inicio: Fch_Inicio,
        Fch_Fin: Fch_Fin
      }

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
    } else {
      console.log('Fechas inválidas');
    }
  }



}
