import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {

  module: string = 'api/User';
  private readonly _baseUrl: string = `${environment.API}`;

  constructor(private http: HttpClient) { 
  }

  get() {
    //return this.http.get<any>(this._baseUrl + this.module + "/list");
    return this.http.get<any>(this._baseUrl + this.module);
  }
  
}