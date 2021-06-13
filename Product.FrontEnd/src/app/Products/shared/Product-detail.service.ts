import { Injectable } from '@angular/core';
//import { ProductDetailFormComponent } from './../product-detail-form/product-detail-form.component';
import { HttpClient ,HttpHeaders } from "@angular/common/http";
import { ProductDetail } from './product-detail.model';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  


  formData: ProductDetail= new ProductDetail();
  readonly baseURL = 'http://localhost:19663/api/ProductDetails';
  list!: ProductDetail[];
   headerWToken=  {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' +  this.oidcSecurityService.getToken(),
    }),responseType:'json'
  }
  constructor(private http: HttpClient,public oidcSecurityService: OidcSecurityService) { }
  //token:any;
  //httpOptions:any;
//   ngOnInit() {
//     const headers = { 'Authorization':  this.oidcSecurityService.getToken(), 'My-Custom-Header': 'foobar' }
//     this.http.get<any>(this.baseURL, { headers }).subscribe(data => {
//       this.list = data as ProductDetail[];
//       console.log(this.list+"ffff" );
//     })
// }
     token = this.oidcSecurityService.getToken();
  
     httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' +this.token,
      }),
    };
 
  headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
    withCredentials: true,
  };
  postProductDetail(formData: ProductDetail) {
    return this.http.post(this.baseURL, formData);
  }
  putProductDetail(formData: ProductDetail) {
    return this.http.put(`${this.baseURL}/${formData.productDetailId}`, formData);
  }
  deleteProductDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    console.log("calling ffff" );
    console.log('Bearer ' +this.oidcSecurityService.getToken() );
    
    // const headers = { 'Authorization':  'Bearer ' +  this.oidcSecurityService.getToken(), 'My-Custom-Header': 'foobar' }
    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     Authorization: 'Bearer ' +  this.oidcSecurityService.getToken(),
    //   }),responseType:'text'
    // };

    // this.http.get<any>(this.baseURL,httpOptions).subscribe(data => {
    //   this.list = data as ProductDetail[];
    //   console.log(this.list+"ffff" );
    // })
    this.http.get(this.baseURL,
      {
        headers: new HttpHeaders({
          Authorization: 'Bearer ' +  this.oidcSecurityService.getToken(),
        }),responseType:'json'
      })
      .subscribe(res =>this.list = res as ProductDetail[]);
  }
  
  GetProductByID(id: number): Observable<ProductDetail> {
    return this.http.get<ProductDetail>(this.baseURL + '/GetProductByID/' + id,
  ).pipe();
  }
}
