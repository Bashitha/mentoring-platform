import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorService } from './error.service';
import { BaseUrlService } from './base-url.service';
import { UserRole } from '../models/userRole.model';
import { User } from '../models/user.model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class UserService {

  constructor(
    private http: HttpClient,
    private baseUrl: BaseUrlService,
    private errorService: ErrorService) { }

    getUserRoles(): Observable<UserRole[]> {    
      const url = this.baseUrl.hosturl + `/api/UserRole/`; 
      return this.http.get<UserRole[]>(url).pipe(      
        catchError(this.errorService.handleError(`getUserRoles`, []))
      );
    }
       /** POST: add a new user to the server */
    createUser (user: User): Observable<User> {
      const url = this.baseUrl.hosturl + `/api/User/`;
      return this.http.post<User>(url, user, httpOptions).pipe(
        tap((user: User) => console.log(`created user Id=${user.userId}`)),
        catchError(this.errorService.handleError<User>('createUser'))
      );
    }

}
