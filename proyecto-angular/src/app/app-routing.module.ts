import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from "./login-form/login-form.component";
import { RegisterFormComponent } from "./register-form/register-form.component";
import { AdminPageComponent } from "./admin-page/admin-page.component";
import { DisplayFuncionariosComponent } from "./display-funcionarios/display-funcionarios.component";
import { AgregarFechaComponent } from "./agregar-fecha/agregar-fecha.component";
import { AgendaComponent } from "./agenda/agenda.component";

const routes: Routes = [
  { path: '', redirectTo: '/indexAdmin', pathMatch: 'full' },
  { path: 'login', component: LoginFormComponent },
  { path: 'register', component: RegisterFormComponent },
  {
    path: 'indexAdmin', component: AdminPageComponent,
    children: [
      { path: '', redirectTo: 'displayFunc', pathMatch: 'full' },
      { path: 'displayFunc', component: DisplayFuncionariosComponent },
      { path: 'verAgenda', component: AgendaComponent }
    ]
  },
  { path: 'displayFunc', component: DisplayFuncionariosComponent },
  { path: 'agregarFecha', component: AgregarFechaComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
