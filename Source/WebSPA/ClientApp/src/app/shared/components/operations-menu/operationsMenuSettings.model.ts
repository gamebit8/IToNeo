export const enum OperationsMenuEvents {
    add,
    delete,
    edit,
    search
};

export interface OperationComponentSettings extends OperationButtonsSettings {
    title?: string;
}

export interface OperationButtonsSettings {
    addOperation: boolean;
    deleteOperation: boolean;
    editOperation: boolean;
    searchOperation: boolean;
}
