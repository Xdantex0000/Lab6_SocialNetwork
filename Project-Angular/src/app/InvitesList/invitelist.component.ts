import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'

@Component({
  selector: 'invitelist',
  templateUrl: './invitelist.component.html',
  styleUrls: ['./invitelist.component.css'],
})

export class AppInviteList implements OnInit {
    invites: Array<string>;
    kek: number;
    constructor(private http: HttpClient){}
    
    GetInvites(){
      this.http.get('http://localhost:52575/api/account/GetInvites').subscribe((res:Array<string>)=>{
        console.log(this.invites);
      this.invites=res;
      this.kek=1;
  });
    }
    Invite(name: string){
      const formData = new FormData();
      formData.append('FriendLogin',name);

      this.http.post('http://localhost:52575/api/account/AddFriend',formData).subscribe((res:Array<string>)=>{
      this.kek=2;
  });
    }

    ngOnInit(){
      this.http.get('http://localhost:52575/api/account/GetInvites').subscribe((res:Array<string>)=>{
        console.log(this.invites);
      this.invites=res;
      this.kek=1;
  });
    }
}