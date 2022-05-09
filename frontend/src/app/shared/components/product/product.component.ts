import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  produto: ProductModel | undefined
  constructor() { }

  ngOnInit(): void {
  }

}
