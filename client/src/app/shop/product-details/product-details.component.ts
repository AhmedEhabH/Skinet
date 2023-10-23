import { Component } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent {
  product: IProduct;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }
  ngOnInit(){
    this.loadProduct();
  }

  loadProduct() {
    this.shopService
      .getProduct(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe({
        next: (response) => this.product = response,
        error: (e) => console.error(e)
      });
  }
}
