import {
	createCollection, createSingle, PXScreen, graphInfo,
	PXPageLoadBehavior
} from "client-controls";
import { ADCSOPickPackFilter, ADCSOPickPackProjection } from "./views";

@graphInfo({
	graphType: "ADCPOSource.BLC.ADCSOPickPackMaint",
	primaryView: "PickPackFilter", pageLoadBehavior: PXPageLoadBehavior.PopulateSavedValues,
	hideFilesIndicator: false, hideNotesIndicator: false,
})
export class ADPO5000 extends PXScreen {

	PickPackFilter = createSingle(ADCSOPickPackFilter);
	PickPackOrders = createCollection(ADCSOPickPackProjection);
}