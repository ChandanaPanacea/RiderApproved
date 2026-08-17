import { Messages as SysMessages } from "client-controls/services/messages";
import { createCollection, createSingle, PXScreen, graphInfo, PXActionState, viewInfo, handleEvent, CustomEventType, actionConfig, RowSelectedHandlerArgs, PXViewCollection, PXPageLoadBehavior, ControlParameter } from "client-controls";
import { ProductImageImport } from "./views";

@graphInfo({graphType: "ProductImageImport.BLC.ProductImageImportMaint", primaryView: "ProductImages", pageLoadBehavior: PXPageLoadBehavior.PopulateSavedValues})
export class IMPR5000 extends PXScreen {
	Save: PXActionState;

	ProductImages = createCollection(ProductImageImport);
}