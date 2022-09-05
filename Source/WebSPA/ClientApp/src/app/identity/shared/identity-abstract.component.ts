import { OnDestroy } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Subject } from "rxjs";
import { InputModel } from "../../shared/models/input.model";
import { Localization } from "../../shared/models/localization.model";
import { IdentityAbstractService } from "./identity-abstract.service";
import { IdentityComponentBuilder } from "./identity-component-builder";

export abstract class IdentityAbstract implements OnDestroy{
    protected form: FormGroup;
    protected inputSettings: { [key: string]: InputModel }[];
    protected localization: Localization;
    protected isLoading: boolean;
    protected notifier = new Subject();
    private builderComponent: IdentityComponentBuilder = new IdentityComponentBuilder();

    constructor(protected identityService: IdentityAbstractService) {
        this.getLocalization();
        this.onCreateComponent(this.builderComponent);
        if (this.builderComponent)
            this.build(this.builderComponent);
    }
    ngOnDestroy(): void {
        this.notifier.next();
        this.notifier.complete();
    }

    protected onCreateComponent(builder: IdentityComponentBuilder) {

    }

    private getLocalization(): void {
        if (!this.localization) {
            this.localization = this.identityService.localization;
        }
    }

    private build(builder: IdentityComponentBuilder): void {
        this.form = builder.form;
        this.inputSettings = builder.inputSettings;
    }
}
