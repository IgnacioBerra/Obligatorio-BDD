import { Component } from '@angular/core';
import {Location} from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { CarnetSaludService } from 'src/app/services/carnet-salud.service';
import { CarnetSalud } from 'src/app/interfaces/carnetSalud';
 

@Component({
  selector: 'app-form-carne-salud',
  templateUrl: './form-carne-salud.component.html',
  styleUrls: ['./form-carne-salud.component.css']
})
export class FormCarneSaludComponent {
  urlImg: string = "";
  ci: number = 0;
  
   fechaVencimiento  = "";
 
  
  constructor(private _location: Location,private route: ActivatedRoute,private router: Router, private carnetService: CarnetSaludService){
    this.route.params.subscribe(params => {
      this.ci = +params['ci'];     
    });
   }

  onFileSelected(event: any): void {
    const inputElement = event.target;
    if (inputElement.files.length > 0) { 
      const selectedFile = inputElement.files[0];
      const fileName = selectedFile.name;
      console.log('Archivo seleccionado:', fileName); 
      this.urlImg = URL.createObjectURL(selectedFile);
      
      console.log('Ruta completa del archivo:', this.urlImg); 
    }
  }


  enviar(){

    let carnet: CarnetSalud ={
      CI: this.ci,
      fechaEmision: new Date().toISOString(),
      fechaVencimiento: new Date(this.fechaVencimiento).toISOString(),
      Comprobante: this.urlImg
    }

    this.carnetService.AñadirCarnetSalud(carnet).subscribe(
      response => {
     
      
        alert("Se ha añadido con exito su carnet de salud.")
        this.router.navigate([`/`], { relativeTo: this.route });
        
      },
      error => {
        console.error('Error en la solicitud POST:', error);

      }
    );    
  }

  goBack(): void{
    this._location.back();
  }
}