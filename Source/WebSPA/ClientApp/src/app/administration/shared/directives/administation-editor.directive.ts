import { Directive, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../../shared/enums/responseStatus';
import { BaseWithNameModel } from '../../../shared/models/baseWithName.model';
import { InputModel } from '../../../shared/models/input.model';
import { Localization } from '../../../shared/models/localization.model';
import { AdministrationEditorBuilder } from '../administration-editor.builder';
import { AdministrationEditorService } from '../services/administration-editor.service';


@Directive()
export class AdministationEditorDirective<TE extends BaseWithNameModel> implements OnInit{
    @Input() updatedEntityId: string
    protected componentTitle: string = '';
    protected localization: Localization;
    protected inputSettings: { [key: string]: InputModel };
    protected form: FormGroup;
    protected showEditor: boolean;
    protected isLoading: boolean;
    protected destroyNotifier = new Subject();

    constructor(protected administrationEditorService: AdministrationEditorService<TE>) {
        this.localization = this.administrationEditorService.getLocalization();

        const builder = new AdministrationEditorBuilder();
        this.onCreating(builder);

        const res = builder.getSettings();

        this.inputSettings = res.inputSettings;

        this.componentTitle = res.title;
        this.form = res.form;
    }

    ngOnInit(): void {
        if (this.updatedEntityId) 
            this.onEditEntity(this.updatedEntityId);
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
        this.clearform();
    }

    protected onCreating(builder: AdministrationEditorBuilder): void {

    }

    protected onEditEntity(id: string | number): void {
        this.administrationEditorService
            .getEntityById(id)
            .pipe(takeUntil(this.destroyNotifier))
            .subscribe(res => {
                if (res.status == ResponseStatus.Ok)
                    this.setFormValues(res.data);
            });
    }

    protected setFormValues(entity: TE): void {
        Object.keys(entity).forEach(key => {
            try {
                this.form.controls[key].setValue(entity[key]);
            }
            catch {
                console.log(`Error map ${key}`)
            }
        });
    }

    protected onSubmitForm(): void {
        const entity: TE = this.getEntityFromForm();

        if (entity.id) {
            this.updateEntity(entity);
        } else {
            this.addEntity(entity);
        }
    }

    protected getEntityFromForm(): TE {
        try {
            return this.form.getRawValue() as TE

        } catch {
            console.log('Error map form to entity');
        }
    }

    protected updateEntity(entity: TE): void {
        this.beforeSendEntity();

        this.administrationEditorService
            .updateEntity(entity.id, entity)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.afterSendEntity())
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Ok) {

                    };
                }
            );
    }

    protected beforeSendEntity(): void {
        this.isLoading = true;
        this.form.disable();
    }

    protected afterSendEntity(): void {
        this.isLoading = false;
        this.form.enable();
    }

    protected addEntity(entity: TE): void {
        this.beforeSendEntity();

        this.administrationEditorService
            .addEntity(entity)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => this.afterSendEntity())
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Created) {

                    }
                }
            );
    }

    protected clearform(): void {
        this.form.reset();
        this.form.markAsUntouched();
    }
}
