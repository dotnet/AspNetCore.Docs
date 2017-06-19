import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CounterComponent } from './counter.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: CounterComponent }])
    ],
    exports: [RouterModule],
    declarations: [CounterComponent]
})

export class CounterModule { }