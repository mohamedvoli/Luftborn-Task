import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../../../core/services/data.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-clinic-form',
  templateUrl: './add-clinic.component.html',
  styleUrls: ['./add-clinic.component.css'],
  providers: [MessageService] // Required for Toast notifications
})
export class ClinicFormComponent implements OnInit {
  clinicForm!: FormGroup;
  isSubmitting = false;

  @Input() visible: boolean = false;
  @Output() clinicAdded = new EventEmitter<any>(); // Emit event when a new clinic is added
  

  constructor(
    private fb: FormBuilder,
    private dataService: DataService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.clinicForm = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{10,15}$/)]],
      email: ['', [Validators.required, Validators.email]],
      openingTime: [null, Validators.required],  // Change: Use null instead of string
      closingTime: [null, Validators.required],  // Change: Use null instead of string
      description: ['']
    });
  }

  onSubmit() {
    if (this.clinicForm.invalid) {
      this.messageService.add({ severity: 'warn', summary: 'Validation Error', detail: 'Please fill all required fields' });
      return;
    }

    const formData = { ...this.clinicForm.value };
    formData.openingTime = formData.openingTime.toISOString(); // Convert Date to ISO string
    formData.closingTime = formData.closingTime.toISOString();

    this.isSubmitting = true;
    this.dataService.postData('api/Clinics/create', formData).subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Clinic added successfully' });
        this.clinicForm.reset();
      },
      error: (error) => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to add clinic' });
        console.error(error);
      },
      complete: () => {
        this.isSubmitting = false; this.visible = false;
        this.dataService.getData('api/Clinics/create/all').subscribe(res => { })

      }
    });
  }

  
}
