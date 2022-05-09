import { Injectable } from '@angular/core';
import {
    HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders, HttpEvent
} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private authenticationService: AuthenticationService, private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Get the auth token from the service.
        const userLogged = this.authenticationService.isUserLogged();
        if (userLogged === false){
            return next.handle(req);
        }

        const userInformation = this.authenticationService.getUserInformation();
        const authReq = req.clone({
            headers: new HttpHeaders({
                'access_token': userInformation.token.accessToken,
                'client_id': environment.ClientId,
            })
        });

        // send cloned request with header to the next handler.
        return this.nextHandle(authReq, next);
    }

    private nextHandle(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
        .pipe(tap(() => null, (error) => {
            if (error.status === 401 || error.status === 403) {
              this.authenticationService.logout();
              this.router.navigate(['/login']);
            }
        }));
    }
}
