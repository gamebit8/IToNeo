import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ConfigurationService } from '../../../abstract/abstract-service/configuration.service';
import { Localization } from '../../../models/localization.model';

@Component({
    selector: 'label-with-invalid-tooltip',
    templateUrl: './label-with-invalid-tooltip.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class LabelWithInvalidTooltipComponent implements OnChanges{
    @Input() title: string;
    @Input() field: string;
    @Input() isRequired: boolean;
    private toogleFieldName: string;
    private localization: Localization;

    constructor(private cdr: ChangeDetectorRef, private configService: ConfigurationService) {
        this.localization = this.configService.localization;
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['title'] || changes['field']) { }
            this.toogleFieldName = this.title ?? this.field;
    }
}
