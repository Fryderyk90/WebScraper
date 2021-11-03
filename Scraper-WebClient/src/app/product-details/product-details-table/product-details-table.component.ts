import { Component, OnInit } from '@angular/core';
import { ProductDetailService } from 'src/app/shared/product-detail.service';

@Component({
  selector: 'app-product-details-table',
  templateUrl: './product-details-table.component.html',
  styles: [
  ]
})
export class ProductDetailsTableComponent implements OnInit {

  constructor(public service:ProductDetailService) { }

  ngOnInit(): void {
    this.service.getAllItemsInStock();
  }

}
