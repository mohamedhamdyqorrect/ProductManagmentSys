import { Component, OnDestroy, OnInit } from '@angular/core';
import { OidcClientNotification, OidcSecurityService, PublicConfiguration } from 'angular-auth-oidc-client';
import { HttpClient ,HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Product Front End';
  constructor(public oidcSecurityService: OidcSecurityService) {}

  // gettokn() {
  //   const token = this.oidcSecurityService.getToken();
  
  //   const httpOptions = {
  //     headers: new HttpHeaders({
  //       Authorization: 'Bearer ' + token,
  //     }),
  //   };
  // }
  ngOnInit() {
    console.log('Bearer ' +this.oidcSecurityService.getToken() );
    this.oidcSecurityService.checkAuth().subscribe((auth) => console.log('is authenticated', auth));
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }
}
