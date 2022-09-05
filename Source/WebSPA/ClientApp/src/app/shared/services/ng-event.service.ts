import { Injectable } from '@angular/core';
import { NgEventBus } from 'ng-event-bus';
import { BaseEventBusService } from '../abstract/interfaces/baseEventBusService';

@Injectable()
export class NgEventBusService implements BaseEventBusService{
    constructor(private eventBus: NgEventBus) { }

    cast(key: string, data: any): void {
        this.eventBus.cast(key, data);
    }

    on(pattern: string): any {
        return this.eventBus.on(pattern)
    }
}
