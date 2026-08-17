import { PXFieldState } from "client-controls";
import { POOrderHeader } from "src/screens/PO/PO301000/PO301000";
export interface POOrderHeader_Ext extends POOrderHeader { }
export class POOrderHeader_Ext {
  UsrPOSource: PXFieldState;
}