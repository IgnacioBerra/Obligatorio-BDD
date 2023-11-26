import { Component } from '@angular/core';
import { FuncionarioService } from '../../services/funcionario.service';

@Component({
  selector: 'app-display-funcionarios',
  templateUrl: './display-funcionarios.component.html',
  styleUrls: ['./display-funcionarios.component.css']
})
export class DisplayFuncionariosComponent {

  funcionarios: any[] = [];

  constructor(private funcService: FuncionarioService){}

  ngOnInit(): void {
    this.obtenerActualizaciones();
  }

  obtenerActualizaciones() {
    this.funcService.getFuncionariosActualizados().subscribe(
      (response: any) => {
        this.funcionarios = response;
        console.log(this.funcionarios); 
      },
      (error: any) => {
        console.error('Error al obtener las actualizaciones:', error);
        console.log(error.error);
      }
    );
  }
}


