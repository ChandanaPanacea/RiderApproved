import {
	PXView, PXFieldState, gridConfig,
	PXFieldOptions, linkCommand, columnConfig, GridColumnType, GridPreset,
	GridFastFilterVisibility,
	GridNoteFilesShowMode
} from "client-controls";
import { ADPO5000 } from "./ADPO5000";

// Views
export class ADCSOPickPackFilter extends PXView {
	POSource: PXFieldState<PXFieldOptions.CommitChanges>;
	ShipVia: PXFieldState<PXFieldOptions.CommitChanges>;
	IsPrintedReport: PXFieldState<PXFieldOptions.CommitChanges>;
}

@gridConfig({
	syncPosition: true,
	allowDelete: false,
	allowInsert: false,
	showFastFilter: GridFastFilterVisibility.False,
	mergeToolbarWith: "ScreenToolbar",
	preset: GridPreset.Processing,
	showNoteFiles:GridNoteFilesShowMode.HideByDefault
})
export class ADCSOPickPackProjection extends PXView {
    @columnConfig({ allowNull: false, type: GridColumnType.CheckBox, allowCheckAll: true })
    Selected: PXFieldState<PXFieldOptions.CommitChanges>;
    @linkCommand("ViewCustomer")
    CustomerID: PXFieldState;
    @columnConfig({ hideViewLink: true })
	OrderType: PXFieldState;

	@linkCommand("ViewDocument")
	OrderNbr: PXFieldState;
    Status: PXFieldState;
    InventoryID: PXFieldState;
    POSource: PXFieldState;
    ShipVia: PXFieldState;  
    OrderQty: PXFieldState;
    CuryUnitPrice: PXFieldState;   
    OrderDate: PXFieldState;    
    OrderDesc: PXFieldState;
    CustomerOrderNbr: PXFieldState;
  PickPackPrinted: PXFieldState;
	UserName: PXFieldState;
	@columnConfig({
        width: 220,
        format: "M/d/yyyy h:mm tt"
    })
    ProcessedDate: PXFieldState;
}