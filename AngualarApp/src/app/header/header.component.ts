import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Products } from '../models/ProductsModel';
import { ProductServiceService } from '../Services/product-service.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  islogin:boolean;
  // product:Products[];

 constructor(private productdataService: ProductServiceService, private router : Router, private userService : UserService){
    this.userService.islogin.subscribe(x=>this.islogin=x);
    // this.productdataService.getAllProducts().subscribe(data=>
    //   this.product=data);
  }

  checkLogin(){
    if(!this.islogin)  //changed
      this.router.navigateByUrl('authenticate');
    else{
      this.userService.openLoginDialog();
    }
  }

  searchproduct(event : any)
 {
   if(String(event.target.value).length>0)
      this.userService.searchItem.next(String(event.target.value));
   //this.router.navigate(['/', String(event.target.value)]);
 }
}
