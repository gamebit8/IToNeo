import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventBusService } from '../shared/abstract/abstract-service/event-bus.service';
import { SharedModule } from '../shared/shared.module';
import { HeaderBarComponent } from './header-bar.component';
import { HeaderBarService } from './header-bar.service';

@NgModule({
    imports: [
        SharedModule,
    ],
    exports: [
        RouterModule,
        HeaderBarComponent  
    ],
    declarations: [HeaderBarComponent],
    providers: [HeaderBarService]
})
export class HeaderBarModule {

}
