import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
import { NavFragmentSettings } from '../../models/navFragmentSettings.model';


@Component({
    selector: 'navs-fragment',
    templateUrl: './navs-fragment.component.html',
    styleUrls: ['./navs-fragment.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class NavsFragmentComponent {
    @Input() activeNavFragment: string
    @Input() settings = new Array<NavFragmentSettings>();
    @Output() selectNav = new EventEmitter<string>()

    constructor(private cdr: ChangeDetectorRef) {

    }

    onSelectNav(fragment: string) {
        this.selectNav.emit(fragment);
    }
}
