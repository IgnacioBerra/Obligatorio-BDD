import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { RegisterFormComponent } from "./components/register-form/register-form.component";
import { AdminPageComponent } from "./components/admin-page/admin-page.component";
import { DisplayFuncionariosComponent } from "./components/display-funcionarios/display-funcionarios.component";
import { AgregarFechaComponent } from "./components/agregar-fecha/agregar-fecha.component";
import { AgendaComponent } from "./components/agenda/agenda.component";
import { FormCarneSaludComponent } from "./components/form-carne-salud/form-carne-salud.component";
import { UserFormComponent } from "./components/user-form/user-form.component";
import { AgendaFormComponent } from "./components/agenda-form/agenda-form.component";
import { DisplayAllFuncionariosComponent } from "./display-all-funcionarios/display-all-funcionarios.component";
import { FormularioCompletoComponent } from "./formulario-completo/formulario-completo.component";

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginFormComponent },
  { path: 'register', component: RegisterFormComponent },
  {
    path: 'indexAdmin', component: AdminPageComponent,
    children: [
      { path: '', redirectTo: 'displayFunc', pathMatch: 'full' },
      { path: 'displayFunc', component: DisplayFuncionariosComponent },
      { path: 'verAgenda', component: AgendaComponent },
      { path: 'displayAllFunc', component: DisplayAllFuncionariosComponent }
    ]
  },
  { path: 'displayFunc', component: DisplayFuncionariosComponent },
  { path: 'agregarFecha', component: AgregarFechaComponent },
  { path: 'carneSaludForm', component: FormCarneSaludComponent },
  { path: 'userForm', component: UserFormComponent },
  { path: 'agendaForm', component: AgendaFormComponent },
  { path: 'formCompleto', component: FormularioCompletoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
