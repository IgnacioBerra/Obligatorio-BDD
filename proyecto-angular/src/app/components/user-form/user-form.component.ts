import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})


export class UserFormComponent {
  carnetsalud: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router) { }

  onChange() {
    console.log(this.carnetsalud);
  }

  enviar() {
    if (this.carnetsalud) {
      this.router.navigate(['/carneSaludForm'], { relativeTo: this.route });
    } else {
      this.router.navigate(['/agendaForm'], { relativeTo: this.route }); //lo manda a agendarse en la clinica ucu
    }
  }
}