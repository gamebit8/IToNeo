import { Component, Input } from '@angular/core';
import { NavBarSetting } from '../shared/models/navBarSetting.model';

@Component({
  selector: 'nav-bar',
    templateUrl: './nav-bar.component.html'
})
export class NavBarComponent {
    @Input() navBarSettings: NavBarSetting[];
}
