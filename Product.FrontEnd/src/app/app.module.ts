import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { from } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListProductsComponent } from './Products/list-products/list-products.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { SiteFooterComponent } from './_layout/site-footer/site-footer.component';
import { SiteHeaderComponent } from './_layout/site-header/site-header.component';
import { LoginComponent } from './Account/login/login.component';
import { ProductDetailFormComponent } from './Products/product-detail-form/product-detail-form.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { AuthConfigModule } from './auth/auth-config.module';

import { AuthModule, LogLevel, OidcConfigService } from 'angular-auth-oidc-client';
import { ProductDetailService } from './Products/shared/Product-detail.service';

// export function configureAuth(oidcConfigService: OidcConfigService) {
//   return () =>
//     oidcConfigService.withConfig({
//       stsServer: 'http://localhost:5001',
//       redirectUrl: window.location.origin,
//       postLogoutRedirectUri: window.location.origin,
//       clientId: 'angularFrontProcutClient',
//       scope: 'openid profile email IdentityServerApi',
//       responseType: 'code',
//       silentRenew: true,
//       silentRenewUrl: `${window.location.origin}/silent-renew.html`,
//       logLevel: LogLevel.Debug,
//     });
// }
@NgModule({
  declarations: [
    AppComponent,
    ListProductsComponent,SiteLayoutComponent,SiteFooterComponent,SiteHeaderComponent,LoginComponent,
    ProductDetailFormComponent,
    HomeComponent
  ],
  imports: [
    HttpClientModule,FormsModule,
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), AuthConfigModule, // ToastrModule added
    
  ],
  providers: [ProductDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
