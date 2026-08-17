import {
	PXView,
	PXFieldState,
	PXFieldOptions,
	createCollection,
	gridConfig,
	columnConfig,
	GridPreset,
	GridColumnDisplayMode,
	placeAfterProperty,
	IGridColumn
} from "client-controls";

import {
	IN203000,
	MatrixItems as BaseMatrixItems
} from "src/screens/IN/IN203000/IN203000";
export interface IN203000_ACME extends IN203000 { }

export class IN203000_ACME {
	ACMEColorsByTemplateItem = createCollection(ACMEColorByTemplateItem);
}

@gridConfig({
	preset: GridPreset.Details,
	showBottomBar: true,
	adjustPageSize: true,
	pageSize: 15,
	initNewRow: true
})
export class ACMEColorByTemplateItem extends PXView {
	@columnConfig({
		hideViewLink: true,
		displayMode: GridColumnDisplayMode.Text
	})
	Color: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({ allowCheckAll: true })
	IsActive: PXFieldState<PXFieldOptions.CommitChanges>;
}