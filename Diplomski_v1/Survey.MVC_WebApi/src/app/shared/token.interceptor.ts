import { AuthService } from './../auth/auth.service';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService) { }
    

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

       // console.log("pocelo");
        const token = this.authService.getToken();

        request = request.clone({
            setHeaders: {
                'Authorization': `Bearer ${token}`
            }
        });

        return next.handle(request)
            .do(succ => {
                console.log(succ);
            },
                (err : Response) => {
                    console.log(err.status);
                    if(err.status === 401 || (err.status === 400 && err.statusText === 'invalid_grant'))
                    {
                        this.authService.logOut();
                    }
                   // if(err.)
                    
                })
    }
}
