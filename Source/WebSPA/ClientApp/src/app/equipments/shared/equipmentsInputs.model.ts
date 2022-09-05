import { InputModel } from "../../shared/models/input.model";

export interface EquipmentsInputs {
    status: InputModel;
    organization: InputModel;
    type: InputModel;
    place: InputModel;
    name: InputModel;
    inventoryNumber: InputModel;
    serialNumber: InputModel;
    employee: InputModel;
    note: InputModel;
    dateOfCreation: InputModel;
    dateOfInstallation: InputModel;
    writeOffName: InputModel;
    writeOffLiquidationValue: InputModel;
    writeOffDate: InputModel;
    writeOffNote: InputModel;
    disposalName: InputModel;
    disposalResalePrice: InputModel;
    disposalDate: InputModel;
    disposalNote: InputModel;
}
