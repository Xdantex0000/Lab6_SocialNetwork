import {Component, OnDestroy, OnInit} from '@angular/core';
import {interval, Unsubscribable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
    title = 'InFriends'

    constructor(private httpClient: HttpClient) 
    { }

    ngOnInit(){}
}
