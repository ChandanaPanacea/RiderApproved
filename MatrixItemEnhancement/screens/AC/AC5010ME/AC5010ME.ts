import {
	PXScreen,
	graphInfo,
	PXFieldState,
	PXFieldOptions,
	viewInfo,
	createSingle,
	createCollection,
	PXView,
	gridConfig,
	columnConfig,
	GridPreset,
} from "client-controls";

@graphInfo({
	graphType: "MatrixItemEnhancement.IN.ACMEMatrixItemUpdateInq",
	primaryView: "TemplateFilter",
})
export class AC5010ME extends PXScreen {

	

	@viewInfo({ containerName: "Filter" })
	TemplateFilter = createSingle(ACMEFilter);

	@viewInfo({ containerName: "Rows" })
	Rows = createCollection(ACMERow);
}
export class ACMEFilter extends PXView {
	TemplateItemID: PXFieldState<PXFieldOptions.CommitChanges>;

	DfltPrice: PXFieldState<PXFieldOptions.CommitChanges>;

	DfltVendorPrice: PXFieldState<PXFieldOptions.CommitChanges>;

	Min: PXFieldState<PXFieldOptions.CommitChanges>;

	Max: PXFieldState<PXFieldOptions.CommitChanges>;

	Visibility: PXFieldState<PXFieldOptions.CommitChanges>;

	Availability: PXFieldState<PXFieldOptions.CommitChanges>;
}

@gridConfig({
	preset: GridPreset.Inquiry,
	allowDelete: false,
	allowInsert: false,
})
export class ACMERow extends PXView {
	@columnConfig({
		width: 80,
		allowCheckAll: true
	})
	Selected: PXFieldState<PXFieldOptions.CommitChanges>;



	@columnConfig({
		width: 80,
	})
	InventoryCD: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	Descr: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	LastCost: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	BasePrice: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	DfltSiteID: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	ItemClassID: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	Color: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	Size: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	TaxCategoryID: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	StkMin: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	StkMax: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	Visibility: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	Availability: PXFieldState<PXFieldOptions.CommitChanges>;

	@columnConfig({
		width: 80,
	})
	VendorPrice: PXFieldState<PXFieldOptions.CommitChanges>;


}