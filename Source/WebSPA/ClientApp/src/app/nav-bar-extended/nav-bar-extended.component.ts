import { Component, EventEmitter, Input, Output } from '@angular/core';
import { faBars, faCog, faDesktop, faUsers, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { NavBarSetting } from '../shared/models/navBarSetting.model';

@Component({
    selector: 'nav-bar-extended',
    templateUrl: './nav-bar-extended.component.html',
    styleUrls: ['./nav-bar-extended.component.css']
})

export class NavBarExtendedComponent {
    @Output() toogleDisplayNavMenuExtended: EventEmitter<any> = new EventEmitter();
    @Input() navBarSettings: NavBarSetting[];
    @Input() appName: string = '';
    private faBars: IconDefinition = faBars;

    constructor() {

    }

    private onToogleDisplayNavMenuExtended(): void {
        this.toogleDisplayNavMenuExtended.emit(null);
    }

}
