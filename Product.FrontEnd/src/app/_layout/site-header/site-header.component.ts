import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OidcClientNotification, OidcSecurityService,AuthorizedState,OpenIdConfiguration, PublicConfiguration } from 'angular-auth-oidc-client';
@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls: ['./site-header.component.css']
})
export class SiteHeaderComponent implements OnInit {

  constructor( private route: Router,public oidcSecurityService: OidcSecurityService,
    // public AuthorizedState: AuthorizedState
    
    ) { }
isAuthorized = false;
configuration:any;
  ngOnInit() {
    
  }
  gettokn() {
    const token = this.oidcSecurityService.getToken();
  
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + token,
      }),
    };
  }
  isUserAuthorized() {
    // this.configuration = this.oidcSecurityService.configuration;
    
    // this.oidcSecurityService.checkAuth().subscribe((auth) => console.log('is authenticated', auth));
    // console.log("stat is"+  this.oidcSecurityService.getState());
   // return this.oidcSecurityService.checkAuth();
    //console.log("a stat"+this.AuthorizedState);
   //debugger;
   const token = this.oidcSecurityService.getToken();
   if(token){return true}else{return false}
   //return true;
   //return this.oidcSecurityService.isAuthenticated();
   // if(this.oidcSecurityService.getState()){return true}else{return false}
  }
 
  Login() {
    this.oidcSecurityService.authorize();
    this.isAuthorized =true;
  }
  Logout() {
    this.oidcSecurityService.logoffLocal();
    this.oidcSecurityService.logoff();
    this.oidcSecurityService.logoffAndRevokeTokens()
    .subscribe((result) => console.log(result));
    //this.oidcSecurityService.authorize();
    this.isAuthorized=false;
    //this.route.navigate(['home']);
    // this.service.LogoutUsers().subscribe(succ => {
     localStorage.clear();
      console.log('authoization return false');

    //   this.route.navigate(['home']);
    // }, err => console.log((err))
    // );
  }
}
