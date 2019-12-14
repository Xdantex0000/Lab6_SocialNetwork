import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {HttpParams} from "@angular/common/http";
import { Tokken } from '../Tokken'

export enum ViewState {
  FRIENDS_LIST, USER_LIST, INVITE_LIST
}

@Component({
  selector: 'wrapper',
  templateUrl: './wrapper.component.html',
  styleUrls: ['./wrapper.component.css'],
})

export class AppWrapper implements OnInit {
    username: string;
    kek: number;
  readonly viewState = ViewState;

  state: ViewState = ViewState.FRIENDS_LIST;
  Log_out(){
    this.kek = 2;
    localStorage.removeItem("token");
    localStorage.removeItem("username");
  }
  constructor(private http: HttpClient){}

    ngOnInit(){
      this.username = localStorage.getItem("username");
      this.kek=1;
    }
}