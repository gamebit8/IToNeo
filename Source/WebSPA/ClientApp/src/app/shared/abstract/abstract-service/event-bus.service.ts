import { BaseEventBusService } from '../interfaces/baseEventBusService';

export enum castKey {
    operationСomponentConfiguration = 'operationСomponentConfiguration',
    operationComponentEvents = 'operationButtonEvent'
} 

export abstract class EventBusService implements BaseEventBusService{

    cast(key: string, data: any):void { }

    on(pattern: string): any {
        return;
    }
}
