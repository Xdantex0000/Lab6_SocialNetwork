import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'

export class Auth{
  Bearer: string;
}

@Component({
  selector: 'authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css'],
})
export class AppAuthorization implements OnInit {
  auth_user = new Auth();
  data: string;
  token = new Tokken();
  tokenKey = 'token';
  kek: number;
  constructor(private http: HttpClient){}
  
  user = {grant_type:'password',Email:'',Password:''};

  GetEmail(value: string) {
    this.user.Email = value;
  }
  GetPassword(value: string) {
    this.user.Password = value;
  }

  Authorization(){
    const params = new HttpParams({

      fromString: `username=${this.user.Email}&password=${this.user.Password}`
    
    });
    this.http.post('http://localhost:52575/api/account/token', params).subscribe((res: Tokken)=>{
      console.log(res);
      this.token=res;
      localStorage.setItem(this.tokenKey,this.token.access_token);
      localStorage.setItem("username",this.token.username);

      this.kek = 2;
    });
    
  }
  Sign_Up(){
    this.kek = 0;
  }

    ngOnInit(){
      this.kek = 1;
    }
  }