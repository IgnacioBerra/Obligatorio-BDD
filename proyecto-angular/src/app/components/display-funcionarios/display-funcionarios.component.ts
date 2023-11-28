import { Component } from '@angular/core';
import { CarnetSaludService } from 'src/app/services/carnet-salud.service';

@Component({
  selector: 'app-display-funcionarios',
  templateUrl: './display-funcionarios.component.html',
  styleUrls: ['./display-funcionarios.component.css']
})
export class DisplayFuncionariosComponent {

  funcionarios: any[] = [];

  constructor(private carnetSaludService: CarnetSaludService){}

  ngOnInit(): void {
    this.obtenerActualizaciones();
  }

  obtenerActualizaciones() {
    this.carnetSaludService.ConseguirCarnetSalud().subscribe(
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