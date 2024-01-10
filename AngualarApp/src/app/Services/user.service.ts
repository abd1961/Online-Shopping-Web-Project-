import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, filter, BehaviorSubject} from 'rxjs';
import { UserModel } from '../models/UserModel';
import { AddUserModel } from '../models/AddUserModel';
import { AuthReponseModel } from '../models/AuthResponseModel';
import { AuthService } from "../shared/auth.service";
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginDialogComponent } from '../dialog/login-dialog/login-dialog.component';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  islogin  =new BehaviorSubject<boolean>(false);
  searchItem = new BehaviorSubject<String>("");
  //checklogin= this.islogin.asObservable(); --> used when islogin private

  constructor(private http:HttpClient,private authService:AuthService,public dialog: MatDialog, private router: Router) { 

    this.islogin.next(this.authService.isAuthenticated());

  }

  api_path = "http://localhost:5119/api/User/";
  //validating,user is a valid user or not 
  validateUser(user:UserModel):Observable<AuthReponseModel> {
    return this.http.post<AuthReponseModel>(this.api_path+"Authentication",user);
  }
  
  //adding a new user, with default customer role
  addUser(user: AddUserModel):Observable<any>{
      return this.http.post<any>(this.api_path+"AddUser",user)
  }

  openLoginDialog(){
    this.dialog.open(LoginDialogComponent,
    { 
      width: '320px',
      closeOnNavigation: true
    } );
  }
}
