import { Component } from '@angular/core';
import { Funcionarios } from 'src/app/interfaces/funcionario';
import { FuncionarioService } from 'src/app/services/funcionario.service';

@Component({
  selector: 'app-display-all-funcionarios',
  templateUrl: './display-all-funcionarios.component.html',
  styleUrls: ['./display-all-funcionarios.component.css']
})
export class DisplayAllFuncionariosComponent {

  funcionarios: any[] = [];
  constructor(private funcionariosService: FuncionarioService) {    
  }

  ngOnInit(){
    this.funcionariosService.getAllFuncionarios().subscribe(
      (response:any) => {
        this.funcionarios = response;
      },
      error => {
        console.log(error);
      }      
    )
  }
}