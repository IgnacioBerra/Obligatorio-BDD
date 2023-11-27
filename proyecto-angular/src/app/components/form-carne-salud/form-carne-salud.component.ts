import { Component } from '@angular/core';
import {Location} from '@angular/common';

@Component({
  selector: 'app-form-carne-salud',
  templateUrl: './form-carne-salud.component.html',
  styleUrls: ['./form-carne-salud.component.css']
})
export class FormCarneSaludComponent {
  urlImg: string = "";

  constructor(private _location: Location){}

  onFileSelected(event: any): void {
    const inputElement = event.target;
    if (inputElement.files.length > 0) { //control
      const selectedFile = inputElement.files[0];
      const fileName = selectedFile.name;
      console.log('Archivo seleccionado:', fileName); //sólo el nombre del archivo
      this.urlImg = URL.createObjectURL(selectedFile);
      
      console.log('Ruta completa del archivo:', this.urlImg); //ruta de la img
    }
  }

  goBack(): void{
    this._location.back();
  }
}