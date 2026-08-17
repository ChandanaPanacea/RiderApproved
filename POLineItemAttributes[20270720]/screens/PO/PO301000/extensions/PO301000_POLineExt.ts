import { placeAfterProperty, PXFieldState } from "client-controls";
import { POLine } from "src/screens/PO/PO301000/PO301000";

export interface PO301000POLine_Ext extends POLine { }
export class PO301000POLine_Ext {
    @placeAfterProperty('SiteID')
    UsrPOColor: PXFieldState;
    @placeAfterProperty('UsrPOColor')
    UsrPOSize: PXFieldState;
}