import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }   from '@angular/common/http';
import { AppAuthorization } from './Authorization/authorization.component';
import { AppRegistration } from './Registration/registration.component'
import { FormsModule }   from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { AppChat } from './Chat/chat.component';
import { AppComponent } from './app.component';
import { AppWrapper } from './Wrapper/wrapper.component';
import { AppInviteList } from './InvitesList/invitelist.component';
import { AppFriendsList } from './FriendsList/friendslist.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddHeaderInterceptor } from './Authorization/auth.interceptor';
import { AppUsersList } from './UsersList/userslist.component'

@NgModule({
  declarations: [
    AppRegistration,
    AppChat,
    AppComponent,
    AppAuthorization,
    AppWrapper,
    AppInviteList,
    AppFriendsList,
    AppUsersList
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    HttpClientJsonpModule,
  ],
  providers: [ 

    { provide: HTTP_INTERCEPTORS, useClass: AddHeaderInterceptor, multi: true },

  ],
  bootstrap: [ AppComponent ]
})  
export class AppModule { 
  
 }
