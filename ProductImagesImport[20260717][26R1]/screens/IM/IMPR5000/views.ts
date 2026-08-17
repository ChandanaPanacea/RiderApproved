import { PXView, PXFieldState, gridConfig, treeConfig, fieldConfig, controlConfig, actionConfig, headerDescription, ICurrencyInfo, disabled, PXFieldOptions, linkCommand, columnConfig, GridColumnShowHideMode, GridColumnType, PXActionState, TextAlign, GridPreset, GridFilterBarVisibility, GridFastFilterVisibility, ISelectorControlConfig, ControlParameter } from "client-controls";
import { IMPR5000 } from "./IMPR5000";


// Views

@gridConfig({
	syncPosition: true,
	showFastFilter: GridFastFilterVisibility.False,
	mergeToolbarWith: "ScreenToolbar",
	preset: GridPreset.Inquiry,
    allowImport: true,
    importView: "ProductImages"
})
export class ProductImageImport extends PXView {
	@columnConfig({
		width: 60,
		allowCheckAll: true,
	})
	Selected: PXFieldState<PXFieldOptions.CommitChanges>;
	@columnConfig({
		width: 180
	})
	InventoryCD: PXFieldState;
	@columnConfig({
		width: 400
	})
	ImageURL: PXFieldState;
	@columnConfig({
		width: 100
	})
	ProcessStatus: PXFieldState;
	@columnConfig({
		width: 500
	})
	Message: PXFieldState;
	@columnConfig({
		width: 140,
		format: "g"
	})
	ProcessedDate: PXFieldState;
}