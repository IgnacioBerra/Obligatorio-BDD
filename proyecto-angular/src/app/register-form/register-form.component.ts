import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {
  carnetsalud: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router) { }

  onChange() {
    console.log(this.carnetsalud);
  }

  signIn() {
    if (this.carnetsalud) {
      this.router.navigate(['/carneSaludForm'], { relativeTo: this.route });
    } else {
      this.router.navigate(['/agendaForm'], { relativeTo: this.route }); //lo manda a agendarse en la clinica ucu
    }

  }


}
