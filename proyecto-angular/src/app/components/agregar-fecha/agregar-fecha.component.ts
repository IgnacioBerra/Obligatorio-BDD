import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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

  // fechaDesde: Date = new Date();
  // fechaHasta: Date = new Date();
  
  // constructor(private toastr: ToastrService, private router: Router, private periodoService: PeriodoActualizacionService) {
  // }

  // agregarFecha() {
  //   console.log(typeof this.fechaDesde);
  //   if (this.fechaDesde && this.fechaHasta) {
      
  //     console.log(this.fechaDesde);
  //     console.log(this.fechaHasta);

  //     //cambiando formato fecha
  //     const fechaDesdeDate: Date = new Date(this.fechaDesde);
  //     const fechaHastaDate: Date = new Date(this.fechaHasta);

  //     const añoDesde: number = fechaDesdeDate.getFullYear(); 
  //     const mesDesde: number = fechaDesdeDate.getMonth() + 1;
  //     const diaDesde = fechaDesdeDate.getDate();

  //     const añoHasta: number = fechaHastaDate.getFullYear();
  //     const mesHasta: number = fechaHastaDate.getMonth() + 1;
  //     const diaHasta = fechaHastaDate.getDate();
      
  //     let semestre: number;
  
  //     if (
  //       (mesDesde >= 1 && mesDesde <= 7 && añoDesde === añoHasta && mesHasta >= 1 && mesHasta <= 7) 
  //     ) {
  //       semestre = 1;
  //     } else if (
        
  //       (mesDesde >= 8 && mesDesde <= 12 && añoDesde === añoHasta && mesHasta >= 8 && mesHasta <= 12)
  //     ) {
  //       semestre = 2;
  //     } else {
  //       semestre = 0;
  //     }
  
          
  //     const fechaFormateadaInicio = `${añoDesde}-${mesDesde}-${diaDesde}`; // Formato 'YYYY-MM-DD'
  //     const fechaFormateadaFin = `${añoHasta}-${mesHasta}-${diaHasta}`; // Formato 'YYYY-MM-DD'

  //     let periodoActualizacion: PeriodosActualizacion ={
  //       año: añoDesde,
  //       semestre: semestre,
  //       fechaInicio: fechaFormateadaInicio,
  //       fechaFin: fechaFormateadaFin
  //     }

  //     console.log(fechaFormateadaFin);
  //     this.periodoService.addFecha(periodoActualizacion).subscribe(
  //       response => {
  //         console.log(response);
  //       },
  //       error => {
  //         console.log(error);
  //         console.log(error.error)
  //       }
  //     );
  //   } else {
  //     console.log('Fechas inválidas');
  //   }
  // }
  
  fechasPeriodosActualizacion = new FormGroup({
    fechaDesde: new FormControl('', Validators.required),
    fechaHasta: new FormControl('', Validators.required)
  });


  constructor(){

  }

  agregarFecha() {
    const fechaDesdeControl = this.fechasPeriodosActualizacion.get('fechaDesde');
    const fechaHastaControl = this.fechasPeriodosActualizacion.get('fechaHasta');
  
    if (fechaDesdeControl && fechaHastaControl && fechaDesdeControl.value && fechaHastaControl.value) {
      const fechaDesdeValue: string = fechaDesdeControl.value;
      const fechaHastaValue: string = fechaHastaControl.value;
  
      const fechaDesdeParts = fechaDesdeValue.split('-').map(Number);
      const fechaHastaParts = fechaHastaValue.split('-').map(Number);
  
      // Aquí, usamos el constructor new Date(YYYY, MM - 1, DD) para crear la fecha
      const fechaDesde: Date = new Date(fechaDesdeParts[0], fechaDesdeParts[1] - 1, fechaDesdeParts[2]);
      const fechaHasta: Date = new Date(fechaHastaParts[0], fechaHastaParts[1] - 1, fechaHastaParts[2]);

      //probar ahora con lo comentado de arriba
      
      
    }
  }
  
}
