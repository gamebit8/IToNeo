import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';
import { faAngleRight } from '@fortawesome/free-solid-svg-icons';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';

@Component({
    selector: 'search-bar',
    templateUrl: './search-bar.component.html',
    styleUrls: ['./search-bar.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class SearchBarComponent {
    @Output() close = new EventEmitter();
    private faAngleRight = faAngleRight;
    private title = '';

    constructor(private configService: ConfigurationService) {
        this.title = this.configService.localization.search;    
    }

    onClose() {
        this.close.emit();
    }
}
