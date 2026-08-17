import {
	PXFieldState,
	placeAfterProperty,
	columnConfig,
	handleEvent,
	CustomEventType,
	ValueChangedHandlerArgs,
	PXViewCollection,
	PXFieldOptions,
} from "client-controls";

import {
	PO301000,
} from "src/screens/PO/PO301000/PO301000";

import {
	SiteStatusLookupBase,
	SiteStatusLookupResults,
	SiteStatusLookupFilter
} from "src/screens/IN/common/panel-site-status-lookup/panel-site-status-lookup";

import {
	PO301000_SiteStatusLookupResults,
} from "src/screens/PO/PO301000/extensions/PO301000_SiteStatusLookup";

export interface PO301000_ACVI extends PO301000, SiteStatusLookupBase { }

export class PO301000_ACVI extends SiteStatusLookupBase {
	@handleEvent(CustomEventType.ValueChanged, { view: "ItemInfo", field: "Selected", order: 10 })
	onSelectedChangeACVI(args: ValueChangedHandlerArgs<PXViewCollection<SiteStatusLookupResults>>) {
		const modelRow = args.viewModel.activeRow as PO301000_ACVISiteStatusLookupResults;

		if (modelRow?.Selected?.value === undefined) {
			return;
		}

		const selected: boolean = !!modelRow.Selected.value;

		if (!selected) {
			modelRow.QtySelected.value = 0;
			this.ItemInfo.activeRowChanged = true;
			return;
		}

		const stkMaxValue = modelRow.UsrStkMax?.value;
		const totalQtyOnHandValue = modelRow.UsrTotalQtyOnHand?.value;

		const stkMax: number = Number(stkMaxValue);
		const totalQtyOnHand: number = Number(totalQtyOnHandValue ?? 0);

		if (
			stkMaxValue === null ||
			stkMaxValue === undefined ||
			Number.isNaN(stkMax)
		) {
			modelRow.QtySelected.value = 1;
			this.ItemInfo.activeRowChanged = true;
			return;
		}

		const qtyToOrder: number = stkMax - totalQtyOnHand;

		modelRow.QtySelected.value = qtyToOrder > 0 ? qtyToOrder : 1;

		this.ItemInfo.activeRowChanged = true;
	}
}

export interface PO301000_ACVISiteStatusLookupFilter extends SiteStatusLookupFilter { }

export class PO301000_ACVISiteStatusLookupFilter extends SiteStatusLookupFilter {

	UsrFilterByQty: PXFieldState<PXFieldOptions.CommitChanges>;

	UsrMinQty: PXFieldState<PXFieldOptions.CommitChanges>;

	UsrMaxQty: PXFieldState<PXFieldOptions.CommitChanges>;
}

export interface PO301000_ACVISiteStatusLookupResults extends PO301000_SiteStatusLookupResults { }

export class PO301000_ACVISiteStatusLookupResults extends PO301000_SiteStatusLookupResults {
	@placeAfterProperty("QtyOnHandExt")
	UsrTotalQtyOnHand: PXFieldState;

	@placeAfterProperty("UsrTotalQtyOnHand")
	UsrDefaultQtyToOrder: PXFieldState;

	@placeAfterProperty("UsrTotalQtyOnHand")
	UsrStkMin: PXFieldState;

	@placeAfterProperty("UsrStkMin")
	UsrStkMax: PXFieldState;

	@placeAfterProperty("UsrStkMax")
	UsrS30: PXFieldState;

	@placeAfterProperty("UsrS30")
	UsrS365: PXFieldState;

	@placeAfterProperty("UsrS365")
	UsrVendorStock: PXFieldState;

	@columnConfig({ allowCheckAll: true })
	Selected: PXFieldState;
}