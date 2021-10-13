import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { HreoComponent } from './components/hreo.component';
import { HreoRoutingModule } from './hreo-routing.module';

@NgModule({
  declarations: [HreoComponent],
  imports: [CoreModule, ThemeSharedModule, HreoRoutingModule],
  exports: [HreoComponent],
})
export class HreoModule {
  static forChild(): ModuleWithProviders<HreoModule> {
    return {
      ngModule: HreoModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<HreoModule> {
    return new LazyModuleFactory(HreoModule.forChild());
  }
}
