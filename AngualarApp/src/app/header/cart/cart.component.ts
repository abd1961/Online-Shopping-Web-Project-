import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Products } from 'src/app/models/ProductsModel';
import { ProductServiceService } from 'src/app/Services/product-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  public onlyCartProducts : Products[] = [];
  public userId = Number(localStorage.getItem("userId"));
  public productIds : Number[];

  
  constructor(private productService:ProductServiceService,private router:Router){
    
  }

  //getting all User specific Cart products
  ngOnInit(){
    this.productService.getUserCartProducts(this.userId).subscribe(response =>{
      this.onlyCartProducts = response
    })
  }


  removeFromCart(product:Products){
    this.productService.removeFromCartService(product).subscribe(response =>{
      console.log("response,",response);
    })
  }


  //Place order
  PlaceOrder(){
    let index=0;
    this.onlyCartProducts.forEach(element => {
      this.productIds[index++] = element.productId;
    });
    this.productService.placeOrderFromCart([1,2,3,4]).subscribe(response => {
      console.log("place order response :",response);
    });
  }
}
