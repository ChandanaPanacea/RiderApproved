import { PXFieldState } from "client-controls";
import {
	IN202500,
	InventoryItem,
} from "src/screens/IN/IN202500/IN202500";

export interface IN202500_ACVI extends IN202500 { }

export class IN202500_ACVI { }

export interface InventoryItem_ACVI extends InventoryItem { }

export class InventoryItem_ACVI {
	UsrStkMin: PXFieldState;
	UsrStkMax: PXFieldState;
}