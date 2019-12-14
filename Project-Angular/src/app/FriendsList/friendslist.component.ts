import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'
import { Friends_Object } from '../Friends_Object';
import { Friend } from '../Friend';

@Component({
  selector: 'friendlist',
  templateUrl: './friendlist.component.html',
  styleUrls: ['./friendlist.component.css'],
})

export class AppFriendsList implements OnInit {

username: string;
friends: Array<string>;
constructor(private http: HttpClient){}
kek: number;
data: string;

Send_Message(friend: string){
  this.username = friend;
  this.kek=2;
}
    
ngOnInit(){
  this.http.get('http://localhost:52575/api/account/GetFriends').subscribe((res:Array<string>)=>{
    this.friends=res;
    this.kek=1;
  });
}
}