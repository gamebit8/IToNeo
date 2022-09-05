import { BaseStorageService } from "../interfaces/baseStorageService";

export abstract class StorageService implements BaseStorageService{
    store(key: string, value: any): void { }
    remove(key: string): void { }
    retrieve(key: string): any { return }
} 
