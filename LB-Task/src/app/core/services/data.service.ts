import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environment/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  baseURL:string =environment.baseURL

  constructor(private httpClient: HttpClient) { 
    console.log('Base URL:', this.baseURL); // Debug the value
  }

  //get data
  getData(url:string):Observable<any>{
   return this.httpClient.get(`${this.baseURL}${url}`)
  }
  //Post data
  postData(url:string,bodyRequest:any):Observable<any>{
   return this.httpClient.post(`${this.baseURL}${url}`,bodyRequest)
  }
  //Put data
  putData(url:string,bodyRequest:any):Observable<any>{
   return this.httpClient.put(`${this.baseURL}${url}`,bodyRequest)
  }
  //Delete data
  deleteData(url:string):Observable<any>{
   return this.httpClient.delete(`${this.baseURL}${url}`)
  }
}
