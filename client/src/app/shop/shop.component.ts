import { Component } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected: number = 0;
  typeIdSelected: number = 0;

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe({
      next: (response) => this.products = response.data,
      error: (e) => console.error(e)
    });
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: (response) => this.brands = [{ id: 0, name: 'All' }, ...response],
      error: (e) => console.error(e)
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: (response) => this.types = [{ id: 0, name: 'All' }, ...response],
      error: (e) => console.error(e)
    })
  }

  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts()
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts()
  }
}
