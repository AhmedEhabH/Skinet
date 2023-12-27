import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketItem, IBasketTotals } from '../../models/basket';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent {
  @Input() shipping: number;
  @Input() subtotal: number;
  @Input() total: number;


  /**
   *
   */
  constructor(private basketService: BasketService) { }

  ngOnInt(){
    
  }
}
