import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { ReturnStatement } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private apiUrl = "https://localhost:7027/api/"
  constructor(
    private http: HttpClient,
  ) { }

  GlobalId:number = 1;
  loginName:string = 'Phuc';

  //#region get
  getUser(): Observable<any>{
    return this.http.get<any>(this.apiUrl + `Project/getuser`);
  }

  getAPIUser(): string{
    return this.apiUrl + `Project/getuser`;
  }

  getMenu(): Observable<any>{
    return this.http.get<any>(this.apiUrl + `Project/getmenu`);
  }

  getAPIMenu(): string{
    return this.apiUrl + `Project/getmenu`;
  }
  //#endregion

  //#region post
  saveUser(prj:any): Observable<any>{
    return this.http.post<any>(this.apiUrl + `Project/saveuser`, prj);
  }
  //#endregion
}
