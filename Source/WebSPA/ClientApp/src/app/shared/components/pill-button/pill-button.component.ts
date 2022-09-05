import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { faSpinner, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';

@Component({
    selector: 'pill-button',
    templateUrl: './pill-button.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class PillButtonComponent {
    @Input() isLoading: boolean;
    @Input() title = '';
    @Input() buttonDisabled: boolean;
    private faSpinner: IconDefinition = faSpinner;

    constructor(private configService: ConfigurationService) {
        this.title = this.configService.localization.apply;
    }
}
