import { Directive, EventEmitter, Input, OnChanges, Output, SimpleChanges } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Subject } from "rxjs";
import { BaseWithNameModel } from "../../shared/models/baseWithName.model";
import { InputModel } from "../../shared/models/input.model";

@Directive()
export abstract class EquipmentsBaseComponent<TE extends BaseWithNameModel> implements OnChanges{
    @Input() entity: TE;
    @Input() entityInput: {[key: string]: InputModel}
    @Output() update: EventEmitter<string> = new EventEmitter<string>();
    @Input() entityForm: FormGroup;
    protected isLoading: boolean;
    protected destroyNotifier = new Subject();

    ngOnChanges(changes: SimpleChanges): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }
}
