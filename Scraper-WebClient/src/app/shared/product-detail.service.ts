import { Injectable } from '@angular/core';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  constructor(private http: HttpClient) { }

  readonly baseUrl = 'https://localhost:5001/allitemsinstock'
  productList: ProductDetail[];

  getAllItemsInStock()
  {
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.productList = res as ProductDetail[])
  }

}

