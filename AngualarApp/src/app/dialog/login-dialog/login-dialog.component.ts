import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { first, tap } from 'rxjs';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.scss']
})
export class LoginDialogComponent {
 islogin: boolean;
 constructor( private router :Router,private userService : UserService, public dialogRef:MatDialogRef<LoginDialogComponent> ){
  this.userService.islogin.subscribe(x=>this.islogin=x);

 }

 onCancel(){
   this.dialogRef.close();
 }

 onLogin(){
   if(!this.islogin){
    this.router.navigate(['authenticate'])
    this.dialogRef.close();
   }
   else{
      this.userService.islogin.next(false);
      localStorage.removeItem('jwt');
      localStorage.removeItem('userId');
      this.router.navigate(['/']);
      this.dialogRef.close();
     // window.location.reload();
   }
  }
} 
