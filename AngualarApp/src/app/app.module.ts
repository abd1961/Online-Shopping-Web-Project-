import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MatIconModule } from '@angular/material/icon'
import { MatDialogModule} from '@angular/material/dialog';
import { MatButtonModule} from '@angular/material/button';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdersComponent } from './header/orders/orders.component';
import { CartComponent } from './header/cart/cart.component';
import { AuthComponent } from './auth/auth.component';
import { NoPageFoundComponent } from './no-page-found/no-page-found.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductsComponent } from './products/products.component';
import { ProductServiceService } from './Services/product-service.service';
import { FavoritesComponent } from './header/favorites/favorites.component';
import { LoginDialogComponent } from './dialog/login-dialog/login-dialog.component';
import { OrderDialogComponent } from './dialog/order-dialog/order-dialog.component';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ProductsComponent,

    OrdersComponent,
    CartComponent,
    AuthComponent,
    NoPageFoundComponent,
    ProductsComponent,
    FavoritesComponent,
    LoginDialogComponent,
    OrderDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatIconModule,
    MatDialogModule,
    MatButtonModule,
    CanvasJSAngularChartsModule,
    MatProgressSpinnerModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ProductServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
