import { Input, Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'

@Component({
  selector: 'chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
})

export class AppChat implements OnInit {
  @Input() userName: string;
  messages: Array<string>;
  message: string;
  kek: number;
  constructor(private http: HttpClient){}
  
  GetMessage(value: string) {
    this.message = value;
  }
  Send_Message(){
    const formData = new FormData();
      formData.append('FriendLogin',this.userName);
      formData.append('Message',this.message);

      this.http.post('http://localhost:52575/api/chat/AddMessage',formData).subscribe((res:Array<string>)=>{
        this.kek=2;
      });
  }
    ngOnInit(){
      const formData = new FormData();
      formData.append('FriendLogin',this.userName);

      this.http.post('http://localhost:52575/api/chat/GetMessages',formData).subscribe((res:Array<string>)=>{
    this.messages=res;
    this.kek=1;
  });
    }
}