import { Component } from '@angular/core';
import { DataService } from '../../../core/services/data.service';
import { ConfirmationService, MessageService } from 'primeng/api';


@Component({
  selector: 'app-clinic',
  templateUrl: './clinic.component.html',
  styleUrls: ['./clinic.component.css']
})
export class ClinicComponent {
  visible: boolean = false;
  clonedClinics: { [s: string]: any } = {};
  // Static array of objects
  clinics: any[] = []

  constructor(private dataService: DataService, private messageService: MessageService, private confirmationService: ConfirmationService,) { }
  ngOnInit() {
    this.getClinics()
  }

  getClinics() {
    this.dataService.getData('api/Clinics/all').subscribe((response: any) => {
      this.clinics = response
    })
  }

  deleteClinic(clinicId: number) {
    this.dataService.deleteData(`api/Clinics/delete/${clinicId}`).subscribe(res => {
      this.showSuccess('Deleted Successfully')
    }, error => {
      this.showError()
    })
  }

  showSuccess(message: string) {
    this.messageService.add({ severity: 'success', summary: 'Success', detail: message });
  }

  showError() {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Message Content' });
  }

  showDialog() {
    this.visible = !this.visible;
  }

  hideDialog() {
    this.visible = false; // Hide the popup
  }

  // Handle adding a new clinic (called from child component)
  onAddClinic(newClinic: any) {
    this.clinics.push(newClinic);
  }
  // Row edit functions (you can define them based on your requirements)
  onRowEditInit(clinic: any) {
    this.clonedClinics[clinic.id as string] = { ...clinic };
  }

  onRowDeleteInit(event: any, clinic: any) {
    this.clonedClinics[clinic.id as string] = { ...clinic };
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: `Do you want to delete this ${clinic.name}?`,
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",
      accept: () => {
        this.deleteClinic(clinic.id)
      },
      // reject: () => {
      //   this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
      // }
    });
  }


  onRowEditSave(clinic: any) {
    // Handle row edit save
    this.dataService.putData('api/Clinics/update', clinic).subscribe(response => {
      this.showSuccess('Edited Successfully')
    }, error => {
      this.showError()
    })
  }

  onRowEditCancel(clinic: any, ri: any) {
    // Restore the original data from the clonedClinics object
    this.clinics[ri] = this.clonedClinics[clinic.id];

    // Remove the cloned data from the clonedClinics object
    delete this.clonedClinics[clinic.id];
  }
}
