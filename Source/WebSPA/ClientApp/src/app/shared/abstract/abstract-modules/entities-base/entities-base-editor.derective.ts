import { Directive, EventEmitter, Input, OnDestroy, OnInit, Output } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Subject } from "rxjs";
import { BaseWithNameModel } from "../../../models/baseWithName.model";
import { InputModel } from "../../../models/input.model";
import { EntitiesBaseEditorModalBuilder } from "./entities-base-editor-modal.builder";

@Directive()
export abstract class EntitiesBaseEditorModal<TE extends BaseWithNameModel> implements OnInit, OnDestroy{
    @Input() entity: TE;
    @Input() htmlInputs: { [key: string]: InputModel }
    @Output() updatedEntity= new EventEmitter<any>();
    @Output() createdEntity = new EventEmitter<any>();
    protected form: FormGroup;
    protected isLoading: boolean;
    protected destroyNotifier = new Subject();
    protected setFormValueFromEntityHandler: (entity: TE, form: FormGroup) => FormGroup;

    ngOnInit(): void {
        const builder = new EntitiesBaseEditorModalBuilder();
        this.onCreating(builder);
        this.builderHandler(builder);

        if (this.entity)
            this.setFormValueFromEntityHandler(this.entity, this.form);

        this.ngOnInitBase();
    }

    protected ngOnInitBase(): void {

    }

    protected onCreating(builder: EntitiesBaseEditorModalBuilder): void {

    }

    protected builderHandler(builder: EntitiesBaseEditorModalBuilder): void {
        const settings = builder.getSettings();

        this.form = settings.form;
        this.setFormValueFromEntityHandler = settings.setFormValueFromEntityHandler ?? this.setFormValueFromEntity;
    }


    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    private setFormValueFromEntity(entity: BaseWithNameModel, form: FormGroup): FormGroup {
        Object.keys(form.value).forEach(x => {
            if (entity[x])
                form.controls[x].setValue(entity[x]);
        });

        return form;
    }

    protected onSubmitForm(): void {
        
    }
}

