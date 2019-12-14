import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { User } from '../User';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})

export class AppRegistration implements OnInit {
  user = new User();
  data: string;
  kek: number;
  constructor(private http: HttpClient){
  }
  
  GetEmail(value: string) {
    this.user.username = value;
  }
  GetPassword(value: string) {
    this.user.password = value;
  }
    
  Register(){
    const params = new HttpParams({

      fromString: `username=${this.user.username}&password=${this.user.password}`
    
    });
    this.http.post('http://localhost:52575/api/account/DbUser', params).subscribe((get_data: string)=>this.data = get_data);
  }
  Sign_In(){
   this.kek = 0;
  }
    ngOnInit(){
      this.kek = 1;
    }
}