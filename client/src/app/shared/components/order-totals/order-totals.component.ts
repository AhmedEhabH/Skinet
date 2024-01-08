import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketTotals } from '../../models/basket';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent {
  @Input() shippingPrice: number;
  @Input() subtotal: number;
  @Input() total: number;
  basketTotals$: Observable<IBasketTotals>;

  constructor() { }

  ngOnInt() {

  }
}
