import { Component } from '@angular/core';
import { FormGroup,FormControl, FormArray,Validator, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthReponseModel } from '../models/AuthResponseModel';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})

export class AuthComponent {

  public authForm: FormGroup;
  alreadyUser=false;
  newUser : boolean = false;

  constructor(private userService:UserService,private router:Router){

  }

    ngOnInit(){
      this.authForm = new FormGroup({
        username: new FormControl('',[Validators.required]),
        password : new FormControl('',[Validators.required, Validators.minLength(8)]),
        email : new FormControl(),
        confirmPassword : new FormControl()
      });
    }


    LoginUser(){
      //printing to console
      //console.log("username :"+this.authForm.get('username').value);
      //console.log("username :"+this.authForm.get('password').value);
      let username = this.authForm.get('username').value;
      let password = this.authForm.get('password').value;

      this.userService.validateUser({username,password}).subscribe(response=>{
        const token = response.token;
        let id = response.userId;
        localStorage.setItem("userId",String(id));
        localStorage.setItem("jwt",token);
        console.log("userId :",Number(localStorage.getItem("userId")));
       // console.log("Token :",localStorage.getItem("jwt"));

        this.userService.islogin.next(true);
        this.alreadyUser=true;
        this.router.navigate(["/"]);
      },

      error => {
        this.alreadyUser=false;
      });
      

    }
    
    RegisterUser(){
      let username = this.authForm.get('username').value;
      let password = this.authForm.get('password').value;
      let email = this.authForm.get('email').value;
      let role = "customer"
      this.userService.addUser({username,password,email,role}).subscribe(respone=>
      {  console.log("response : ",respone)
         this.LoginUser()},
      error => {
        console.log("error in registering")
      });

    }

    createUser(){
      this.newUser=!this.newUser;
    }
}
