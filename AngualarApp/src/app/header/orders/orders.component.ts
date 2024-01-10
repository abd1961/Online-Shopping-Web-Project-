import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductServiceService } from 'src/app/Services/product-service.service';
import { OrderResponseModel } from 'src/app/models/OrderResponseModel';
@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent {
  public orderedProducts: OrderResponseModel[];
  public categories: string[] = ["Apparels", "Electronics", "Footwear", "Home Needs", "Sports", "Stationery"];
  
  datapoints: any[] = [];
  chartOptions: any; // Initialize chartOptions without data
  
  constructor(private productService: ProductServiceService, private router: Router) {
    //get all ordersData
    this.productService.getAllOrdersService().subscribe(response => {
      this.orderedProducts = response.reverse();
      this.categoryChart(); // Call chartData once data is fetched
    });
  }
  
  categoryChart() {
    let productTypes = this.orderedProducts.map(x => x.category);
    let totalProducts = productTypes.length; 

    this.categories.forEach(type => {
      let typeCount = productTypes.filter(x => x === type).length; //getting each category count
      let percentage = (typeCount / totalProducts) * 100; // Calculate percentage

      this.datapoints.push({ y: percentage, name: type }); //pushing to datapoints array
    });
  
    this.chartOptions = {
      animationEnabled: true,
      title: {
        text: "orders placed on category wise"
      },
      data: [{
        type: "doughnut",
        yValueFormatString: "#,###.##'%'",    
        indexLabel: "{name}",
        dataPoints: this.datapoints // Assign the datapoints to dataPoints property
      }]
    };
  }  
}
