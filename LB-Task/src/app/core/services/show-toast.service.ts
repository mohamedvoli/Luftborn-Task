import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ShowToastrService {

  constructor(private toastr: ToastrService) { }

  showToastr(severity: string, message: string, title: string, time?: number, custom?: boolean) {
    // Severity => error/warning/success/info
    this.toastr.show(message, title, {
      timeOut: time ? time : 8000,
      extendedTimeOut: time ? time : 3000,
      // ...(custom) && {enableHtml: true},
      enableHtml: true,
      toastClass: `ngx-toastr override-toast toast-${severity} ${custom ? 'custom' : ''}`,
    });
  }
}
