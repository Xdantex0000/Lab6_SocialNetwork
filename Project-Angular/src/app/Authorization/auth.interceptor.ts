import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
  } from '@angular/common/http';
  import { Observable } from 'rxjs';

  export class AddHeaderInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      // Clone the request to add the new header
      if (req.url.includes('GetFriends')){
        req = req.clone({
            setHeaders: {
                'Content-Type' : 'application/json; charset=utf-8',
                'Accept'       : 'application/json',
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('GetInvites')){
        req = req.clone({
            setHeaders: {
                'Content-Type' : 'application/json; charset=utf-8',
                'Accept'       : 'application/json',
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('GetMessages')){
        req = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('GetPeople')){
        req = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('Invite')){
        req = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('AddFriend')){
        req = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      if (req.url.includes('AddMessage')){
        req = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`,
              },
        });
      }
      return next.handle(req);
    }
  }