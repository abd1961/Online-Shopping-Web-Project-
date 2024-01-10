import { Component } from '@angular/core';
import { MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { ProductServiceService } from 'src/app/Services/product-service.service';
import { OrderResponseModel } from 'src/app/models/OrderResponseModel';

@Component({
  selector: 'app-order-dialog',
  templateUrl: './order-dialog.component.html',
  styleUrls: ['./order-dialog.component.scss']
})
export class OrderDialogComponent {

  constructor(private productService : ProductServiceService, private dialogRef : MatDialogRef<OrderDialogComponent>){}

  onCancel(){
    this.dialogRef.close();
  }

  order(){
    this.dialogRef.close(true);
  }
}
