import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { AdminPageComponent } from "./admin-page/admin-page.component";
import { DisplayFuncionariosComponent } from './display-funcionarios/display-funcionarios.component';
import { DateAdminComponent } from './date-admin/date-admin.component';
import { CambiarFechaComponent } from './cambiar-fecha/cambiar-fecha.component';
import { AgregarFechaComponent } from './agregar-fecha/agregar-fecha.component';
import { AgendaComponent } from './agenda/agenda.component';
import { FormCarneSaludComponent } from './form-carne-salud/form-carne-salud.component';
import { AgendaFormComponent } from './agenda-form/agenda-form.component';
import { UserFormComponent } from './user-form/user-form.component';
import { DisplayAllFuncionariosComponent } from './display-all-funcionarios/display-all-funcionarios.component';
import { FormularioCompletoComponent } from "./formulario-completo/formulario-completo.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    AdminPageComponent,
    DisplayFuncionariosComponent,
    DateAdminComponent,
    CambiarFechaComponent,
    AgregarFechaComponent,
    AgendaComponent,
    FormCarneSaludComponent,
    AgendaFormComponent,
    UserFormComponent,
    DisplayAllFuncionariosComponent,
    FormularioCompletoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
