import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
private baseUrl:string = "https://localhost:7072/api/usuario/"
constructor(private http : HttpClient) { }
  signUp(userObjt:any){
    return this.http.post<any>(`${this.baseUrl}register`, userObjt)
  }

  login(loginObjt:any){
    return this.http.post<any>(`${this.baseUrl}authenticate`,loginObjt)
  }
}
