import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { AdminPageComponent } from "./components/admin-page/admin-page.component";
import { DisplayFuncionariosComponent } from './components/display-funcionarios/display-funcionarios.component';
import { DateAdminComponent } from './components/date-admin/date-admin.component';
import { CambiarFechaComponent } from './components/cambiar-fecha/cambiar-fecha.component';
import { AgregarFechaComponent } from './components/agregar-fecha/agregar-fecha.component';
import { AgendaComponent } from './components/agenda/agenda.component';
import { FormCarneSaludComponent } from './components/form-carne-salud/form-carne-salud.component';
import { AgendaFormComponent } from './components/agenda-form/agenda-form.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { DisplayAllFuncionariosComponent } from './components/display-all-funcionarios/display-all-funcionarios.component';
import { FormularioCompletoComponent } from "./components/formulario-completo/formulario-completo.component";

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
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }