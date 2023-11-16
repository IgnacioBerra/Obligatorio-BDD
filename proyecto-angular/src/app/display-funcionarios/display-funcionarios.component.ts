import { Component } from '@angular/core';

@Component({
  selector: 'app-display-funcionarios',
  templateUrl: './display-funcionarios.component.html',
  styleUrls: ['./display-funcionarios.component.css']
})
export class DisplayFuncionariosComponent {
  funcionarios = [
    { id: 1, nombre: 'Juan Pérez', apellido: 'González', completado: 'true' },
    { id: 2, nombre: 'María Rodríguez', apellido: 'González', completado: 'true' },
    { id: 3, nombre: 'Carlos Gómez', apellido: 'González', completado: 'true' },
    { id: 4, nombre: 'Juan Pérez', apellido: 'González', completado: 'true' },
    { id: 5, nombre: 'María Rodríguez', apellido: 'González', completado: 'true' },
    { id: 6, nombre: 'Juan Pérez', apellido: 'González', completado: 'true' },
    { id: 7, nombre: 'María Rodríguez', apellido: 'González', completado: 'true' },
    { id: 8, nombre: 'Juan Pérez', apellido: 'González', completado: 'true' },
    { id: 9, nombre: 'María Rodríguez', apellido: 'González', completado: 'true' }
  ];

}


