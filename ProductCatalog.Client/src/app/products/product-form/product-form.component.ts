import { Component } from '@angular/core';
import { ProductsService } from '../../shared/services/products.service';
import { Product } from '../../shared/models/product.model';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.scss',
})
export class ProductFormComponent {
  form: Product = new Product();

  constructor(public service: ProductsService) {}

  onSubmit() {
    this.service.createProduct(this.form).subscribe({
      next: (res) => {
        this.service.refreshProductList(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
