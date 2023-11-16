import { Component} from '@angular/core';


@Component({
  selector: 'app-cambiar-fecha',
  templateUrl: './cambiar-fecha.component.html',
  styleUrls: ['./cambiar-fecha.component.css']
})
export class CambiarFechaComponent {

  isDisabled = true;
  buttonText = 'Modificar';
  
  cambiarFecha() {
    this.isDisabled = !this.isDisabled;
    this.buttonText = this.isDisabled ? 'Modificar' : 'Guardar';
  }


}
