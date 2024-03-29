import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Skinet';

  constructor(private basketService: BasketService, private accountService: AccountService) { }
  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id')
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe({
        next: () => {
          // console.log("initialised basket");
        },
        error: e => console.error(e)
      });
    }
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');

    this.accountService.loadCurrentUser(token).subscribe({
      next: () => {
        // console.log("loaded user");
      },
      error: err => {
        console.error(err);
      }
    })

  }
}
