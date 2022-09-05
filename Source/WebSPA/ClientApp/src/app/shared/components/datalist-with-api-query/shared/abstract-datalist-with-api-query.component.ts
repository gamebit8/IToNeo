import { ChangeDetectorRef, Directive, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { inputType } from '../../../enums/inputType';
import { BaseWithNameModel } from '../../../models/baseWithName.model';
import { InputModel } from '../../../models/input.model';
import { Localization } from '../../../models/localization.model';
import { DatalistWithApiQueryService } from '../shared/datalist-with-api-query.service';

@Directive()
export abstract class AbstractDatalistWithApiQueryComponent<T> implements OnInit, OnChanges, OnDestroy{
    @Input() entity: BaseWithNameModel;
    @Input() input: InputModel = <InputModel>{ type: inputType.text };
    @Input() isBlockInput: boolean;
    @Input() inputValue: T;
    @Output() inputValueChange = new EventEmitter<T>();
    destroyNotifier = new Subject();
    protected localization: Localization;
    protected isRequired: boolean;
    protected isLoadingData: boolean;
    protected entities: BaseWithNameModel[];

    constructor(protected dataListWithApiQueryService: DatalistWithApiQueryService, protected cdr: ChangeDetectorRef) {
        this.localization = this.dataListWithApiQueryService.getLocalization();
    }

    ngOnDestroy(): void {
        this.destroyNotifier.next();
        this.destroyNotifier.complete();
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['entity'] || changes['input'] || changes['isBlockInput'])
            this.cdr.detectChanges();
    }

    ngOnInit(): void {
        this.dataListWithApiQueryService.setEntitiesUrl(this.input.searchHelperUrl);
        this.ngOnInitBase();
    }

    protected ngOnInitBase(): void {

    }

    protected getEntity(name?: string): void {
        this.isLoadingData = true;
        this.dataListWithApiQueryService
            .getEntities(name)
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => {
                    this.isLoadingData = false;
                    this.cdr.detectChanges();
                })
            )
            .subscribe(ent => {
                this.entities = ent;
            });
    }

    protected onScrollToEnd(): void {
        this.isLoadingData = true;
        this.dataListWithApiQueryService
            .getNextPageEntities()
            .pipe(
                takeUntil(this.destroyNotifier),
                finalize(() => {
                    this.isLoadingData = false;
                    this.cdr.detectChanges();
                })
            )
            .subscribe(ent => {
                this.entities = this.entities.concat(ent);
            });
    }

    protected onSearch(event: any): void {
        if (String(event.term).length > 2) {
            this.getEntity(event.term);
        }
    }

    protected onFocus(): void {
        this.getEntity();
    }

    protected onChange(): void {
        this.inputValueChange.emit(this.inputValue);
    }

    protected onClear(): void {

    }

}

