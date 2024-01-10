import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Products } from 'src/app/models/ProductsModel';
import { ProductServiceService } from "../../Services/product-service.service";
import { OrderDialogComponent } from 'src/app/dialog/order-dialog/order-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { FavModel } from 'src/app/models/FavProductsModel';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.scss']
})

export class FavoritesComponent {
  public onlyFavProducts : Products[];
  public userId = Number(localStorage.getItem("userId"));
  public order:FavModel;
  //getting all fav products
  constructor(private productService:ProductServiceService, private router:Router, private dialog : MatDialog){
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.productService.getUserFavProducts(this.userId).subscribe(response =>{
      this.onlyFavProducts = response.reverse();
    })
  }

  //remove from favourites
  removeFromFavProduct(productId:number){
    this.productService.removeFavProduct({productId,userId:this.userId}).subscribe(response => {
      this.onlyFavProducts = response;
      //console.log("after response",this.onlyFavProducts.length);
    });
  }

  //to add order
  addOrder(productId:number){
    //dialog for order confirmation
    const dialogRef = this.dialog.open(OrderDialogComponent, {width: '320px'} );
    //after closing dialog 
    dialogRef.afterClosed().subscribe(result=>{
        if(result){
          this.order = {
            productId:productId,
            userId:this.userId
          }
          this.productService.addOrderService(this.order).subscribe(response => {
           //console.log("order response",response)
          });
        }
    });      
  } 
}
