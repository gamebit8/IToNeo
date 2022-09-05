import { MetaData } from "ng-event-bus/lib/meta-data";
import { Observable } from "rxjs";

export interface BaseEventBusService {
    cast(key: string, data: any): void;
    on(pattern: string): Observable<MetaData>;
}
