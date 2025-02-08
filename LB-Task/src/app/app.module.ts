import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClinicComponent } from './pages/clinic/clinic/clinic.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
import { TagModule } from 'primeng/tag';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ToastComponent } from './components/shared/toast/toast/toast.component'; 
import { ConfirmationService, MessageService } from 'primeng/api';
import { ToastrModule } from 'ngx-toastr';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { ClinicFormComponent } from './components/addClinic/add-clinic/add-clinic.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';


@NgModule({
  declarations: [
    AppComponent,
    ClinicComponent,
    ToastComponent,
    ClinicFormComponent,
    
  ],
  imports: [
    ConfirmDialogModule,   
    DialogModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
    toastClass: 'ngx-toastr override-toast',
    messageClass: 'toast-message override-toast-message'
  }),
  CalendarModule,
    CardModule,
    ToastModule,
    CommonModule,
    TagModule,
    ButtonModule,
    InputTextModule,
    DropdownModule,
    InputTextareaModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    TableModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [MessageService,ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
