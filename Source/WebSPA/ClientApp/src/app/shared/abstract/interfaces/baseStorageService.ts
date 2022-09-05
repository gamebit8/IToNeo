export interface BaseStorageService {
    retrieve(key: string): any 
    store(key: string, value: any): void 
    remove(key: string): void 
}

