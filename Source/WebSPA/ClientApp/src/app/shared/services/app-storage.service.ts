import { Injectable } from '@angular/core';
import { BaseStorageService } from '../abstract/interfaces/baseStorageService';

@Injectable()
export class AppStorageService implements BaseStorageService{
    private storage: any;

    constructor() {
        this.storage = localStorage;
    }

    retrieve(key: string): any {
        let item = this.storage.getItem(key);

        if (item && item !== 'undefined') {
            try {
                return JSON.parse(item);
            } catch {
                return item;
            }
        }

        return;
    }

    store(key: string, value: any):void {
        const stringValue = JSON.stringify(value);
        this.storage.setItem(key, stringValue);
    }

    remove(key: string): void {
        this.storage.removeItem(key);
    }
}
