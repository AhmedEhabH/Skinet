import { Component } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
  products: IProduct[];

  constructor(private shopService: ShopService){}

  ngOnInit(){
    this.shopService.getProducts().subscribe({
      next:(response)=>this.products = response.data,
      error:(e)=>console.error(e)
      
    })
  }
}
