import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map, catchError, finalize } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppHttpInterceptorService implements HttpInterceptor {

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<any> {

    const request = this.addHeader(req);
    return next.handle(request).pipe(
      map(res => {
        return res;
      }),
      catchError(err => this.handlerError(err, req, next)),
      finalize(() => { }
      ));
  }

  addHeader(req) {
    let { headers } = req;
    if (headers.keys().length === 0) { headers = new HttpHeaders(); }
    return req.clone({
      headers,
      withCredentials: true,
      url: `${environment.baseUrl}${req.url}`
    });
  }

  private handlerError(err: HttpErrorResponse, req: any, next: any): Observable<any> {
    switch (err.status) {
      case 500:
        if (err.error && err.error.errors && err.error.errors.length > 0) {
          // this.errorPopup.showPopup(err.error.errors.join('\n'));
          console.log(err.error.errors.join('\n'));
        } else {
          // this.errorPopup.showPopup(this.ErrorMessage.serverError);
          console.log('Server Error:');
        }
        break;
    }
    return throwError(err);
  }
}
