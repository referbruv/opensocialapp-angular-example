import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';
import { OidcAuthService } from '../auth/oidc-auth.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: "root"
})
export class PostsInterceptor implements HttpInterceptor {

    constructor(private oidcAuthService: OidcAuthService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var requestPath = req.url;
        if (requestPath.indexOf('posts') > -1) {
            let auth_header = "";
            var xRequestId = Guid.create().toString();
            // var headers = req.headers.append("X-Request-ID", xRequestId);
            if (this.oidcAuthService.isLoggedIn()) {
                auth_header = this.oidcAuthService.getAuthorizationHeaderValue();
            }
            req = req.clone({
                setHeaders: {
                    "X-Request-ID": xRequestId,
                    "Authorization": auth_header
                }
            });
        }

        // passes on the request to next handler
        // once all the handlers are executed
        // the request is now pushed into the network
        // for handling by the API
        return next.handle(req);
    }
}