import { Component} from '@angular/core';
import { PeriodoActualizacionService } from 'src/app/services/periodo-actualizacion.service';


@Component({
  selector: 'app-cambiar-fecha',
  templateUrl: './cambiar-fecha.component.html',
  styleUrls: ['./cambiar-fecha.component.css']
})
export class CambiarFechaComponent {

  isDisabled = true;
  buttonText = 'Modificar';
  fechas_actualizacion: any[] = [];
  fechaInico: string = '';
  fechaFin: string = '';

  constructor(private periodoService: PeriodoActualizacionService){}

  ngOnInit(){
    this.periodoService.getPeriodosActualizacion().subscribe(
      (response: any) => {
        if (response && response.length > 0 && response[0].fch_Inicio !== undefined && response[0].fch_Fin !== undefined) {
        this.fechaInico = response[0].fch_Inicio;
        this.fechaFin = response[0].fch_Fin;
        }
      },
      (error: any) => {
        console.error('Error al obtener los periodos:', error);
        console.log(error.error);
      }
    );
  }
  cambiarFecha() {
    this.isDisabled = !this.isDisabled;
    this.buttonText = this.isDisabled ? 'Modificar' : 'Guardar';
  }


}