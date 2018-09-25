import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorService } from './error.service';
import { BaseUrlService } from './base-url.service';
import { UserRole } from '../models/userRole.model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class UserRoleService {

  constructor(
    private http: HttpClient,
    private baseUrl: BaseUrlService,
    private errorService: ErrorService
  ) { }

  getUserRoles(): Observable<UserRole[]> {    
    const url = this.baseUrl.hosturl + `/api/UserRole/`; 
    return this.http.get<UserRole[]>(url).pipe(      
      catchError(this.errorService.handleError(`getUserRoles`, []))
    );
  }

    /** POST: add a new userRole to the server */
  createUserRole (userRole: UserRole): Observable<UserRole> {
    const url = this.baseUrl.hosturl + `/api/UserRole/`;
    return this.http.post<UserRole>(url, userRole, httpOptions).pipe(
      tap((userRole: UserRole) => console.log(`created user role Id=${userRole.id}`)),
      catchError(this.errorService.handleError<UserRole>('createUserRole'))
    );
  }

}
