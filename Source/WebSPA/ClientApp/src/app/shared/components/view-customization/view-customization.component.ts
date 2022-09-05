import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faChevronDown, faChevronLeft, faChevronRight, faChevronUp, faTimes } from '@fortawesome/free-solid-svg-icons';
import { ConfigurationService } from '../../abstract/abstract-service/configuration.service';
import { Localization } from '../../models/localization.model';

@Component({
    selector: 'view-customization',
    templateUrl: './view-customization.component.html',
    styleUrls: ['./view-customization.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class ViewCustomizationComponent implements OnInit{
    @Input() selectedItems = Array<string>();
    @Input() allItems = Array<string>();
    @Output() closeViewCustomization = new EventEmitter();
    @Output() submitViewCustomizationChanges = new EventEmitter();
    private availableItems = Array<string>();
    private selectedAvailableItemsIndex: Array<number>;
    private selectedSelectedItemsIndex: Array<number>;
    private localization: Localization;
    private faTimes = faTimes;
    private faChevronLeft = faChevronLeft;
    private faChevronRight = faChevronRight;
    private faChevronDown = faChevronDown;
    private faChevronUp = faChevronUp;

    constructor(private configurationService: ConfigurationService) {

    }

    ngOnInit(): void {
        if (this.allItems && this.selectedItems)
            this.availableItems = this.getUniqueValues(this.allItems, this.selectedItems);
        this.localization = this.configurationService.localization;
    }

    private onClose(): void {
        this.closeViewCustomization.emit();
    }

    private onSubmitChanges(): void {
        this.submitViewCustomizationChanges.emit(this.selectedItems);
    }

    private getUniqueValues(array1: Array<string>, array2: Array<string>): Array<string> {
        return array1.filter(item => { return array2.indexOf(item) == -1 });
    }

    private upSelectedItems(): void {
        const length = this.selectedSelectedItemsIndex.length;
        let lastIndex: number;
        let lastIndexChange: boolean;
        for (var i = 0; i < length; i++) {
            let index = this.selectedSelectedItemsIndex[i];
            if (index != 0) {
                if (lastIndexChange = true && lastIndex != index - 1) {
                    let temp = this.selectedItems[index - 1];
                    this.selectedItems[index - 1] = this.selectedItems[index];
                    this.selectedItems[index] = temp;
                    this.selectedSelectedItemsIndex[i]--;
                    lastIndexChange = true;
                }
            }

            lastIndex = this.selectedSelectedItemsIndex[i];
        }
    }

    private downSelectedItems(): void {
        const length = this.selectedSelectedItemsIndex.length;
        let lastIndex: number;
        let lastIndexChange: boolean;
        for (var i = length - 1; i >= 0; i--) {
            let index = this.selectedSelectedItemsIndex[i];
            if (index != this.selectedItems.length - 1) {
                if (lastIndexChange = true && lastIndex != index + 1) {
                    let temp = this.selectedItems[index + 1];
                    this.selectedItems[index + 1] = this.selectedItems[index];
                    this.selectedItems[index] = temp;
                    this.selectedSelectedItemsIndex[i]++;
                    lastIndexChange = true;
                }
            }

            lastIndex = this.selectedSelectedItemsIndex[i];
        }
    }

    private addToAvailableItems(): void {
        let correction: number = 0;
        this.selectedSelectedItemsIndex.forEach(index => {
            let i = index - correction;
            this.availableItems.push(this.selectedItems[i]);

            this.selectedItems.splice(i, 1);
            correction++;
        })

        this.selectedSelectedItemsIndex = null;
    }

    private addToSelectedItems(): void {
        let correction: number = 0;
        this.selectedAvailableItemsIndex.forEach(index => {
            let i = index - correction;
            this.selectedItems.push(this.availableItems[i]);

            this.availableItems.splice(i, 1);
            correction++;
        })

        this.selectedAvailableItemsIndex = null;
    }
}
