import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { Product } from '../models/product.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private url: string = `${environment.apiBaseUrl}/Products`;
  private productsSource: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);

  products$ = this.productsSource.asObservable();

  constructor(private http: HttpClient) {
    this.getProducts().subscribe((res) => this.productsSource.next(res));
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }

  createProduct(form: Product): Observable<Product[]> {
    return this.http.post<Product[]>(this.url, form);
  }

  refreshProductList(newProducts: Product[]) {
    this.productsSource.next(newProducts);
  }
}
