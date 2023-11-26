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

  constructor(private periodoService: PeriodoActualizacionService){}

  ngOnInit(){
    this.periodoService.getPeriodosActualizacion().subscribe(
      (response: any) => {
        this.fechas_actualizacion = response;
        console.log(this.fechas_actualizacion); 
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
