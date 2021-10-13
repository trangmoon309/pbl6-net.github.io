import { ModuleWithProviders, NgModule } from '@angular/core';
import { HREO_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class HreoConfigModule {
  static forRoot(): ModuleWithProviders<HreoConfigModule> {
    return {
      ngModule: HreoConfigModule,
      providers: [HREO_ROUTE_PROVIDERS],
    };
  }
}
