import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'
import { Friends_Object } from '../Friends_Object';
import { Friend } from '../Friend';

@Component({
  selector: 'userslist',
  templateUrl: './userslist.component.html',
  styleUrls: ['./userslist.component.css'],
})

export class AppUsersList implements OnInit {

username: string;
users: Array<string>;
constructor(private http: HttpClient){}
kek: number;
data: string;

Invite(name: string){
  const formData = new FormData();
  formData.append('Login',name);

  this.http.post('http://localhost:52575/api/account/Invite',formData).subscribe((res:Array<string>)=>{
    this.kek=2;
  });
}
    
ngOnInit(){
  this.http.get('http://localhost:52575/api/account/GetPeople').subscribe((res:Array<string>)=>{
    this.users=res;
    this.kek=1;
  });
}
}