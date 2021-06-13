import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ListProductsComponent } from './Products/list-products/list-products.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { AccessdeniedComponent } from './accessdenied/accessdenied.component';
import { LoginComponent } from './Account/login/login.component';
import { ProductDetail } from './Products/shared/product-detail.model';
import { ProductDetailFormComponent } from './Products/product-detail-form/product-detail-form.component';
import { HomeComponent } from './home/home.component';
const routes: Routes = [ { path: 'login', component: LoginComponent },

{ 
  path: '', 
  component: SiteLayoutComponent,
  children: [
     { path: '', component: HomeComponent, pathMatch: 'full'},
    { path: 'home', component: HomeComponent },
    { path: 'products', component: ListProductsComponent },
    { path: 'product', component: ProductDetailFormComponent },
    { path: 'product/:id', component: ProductDetailFormComponent },
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
