import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';

export function configureAuth(oidcConfigService: OidcConfigService): () => Promise<any> {
    return () =>
        oidcConfigService.withConfig({
              stsServer: 'https://localhost:5001',
              redirectUrl:'http://localhost:4200',
              postLogoutRedirectUri:'http://localhost:4200/home',
              clientId: 'angularFrontProcutClient',
              scope: 'openid scope1', // 'openid profile offline_access ' + your scopes
              responseType: 'code',
              silentRenew: false,
              useRefreshToken: false,
              renewTimeBeforeTokenExpiresInSeconds: 30,
          });
}

@NgModule({
    imports: [AuthModule.forRoot()],
    exports: [AuthModule],
    providers: [
        OidcConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: configureAuth,
            deps: [OidcConfigService],
            multi: true,
        },
    ],
})
export class AuthConfigModule {}
