import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { UserService } from '../Services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth : AuthService, private router : Router, private userService : UserService){}
  canActivate(){
    if(this.auth.isAuthenticated())
      return true;
    else{
      this.userService.openLoginDialog();
      return false;
    }
  }
  
}
