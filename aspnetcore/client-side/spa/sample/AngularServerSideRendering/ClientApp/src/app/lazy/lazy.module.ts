import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LazyComponent } from './lazy.component';

@NgModule({
  declarations: [LazyComponent],
  imports: [
    RouterModule.forChild([
      { path: '', component: LazyComponent }
    ])
  ]
})
export class LazyModule {
}
