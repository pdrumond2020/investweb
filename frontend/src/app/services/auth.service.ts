import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthService {

  module: string = 'api/User';
  private readonly _baseUrl: string = `${environment.API}`;

  constructor(private http: HttpClient) { }

  authenticate(data: any) : Observable<any> {
    return this.http.post<any>(this._baseUrl + this.module + "/authenticate", data);
  }
}
