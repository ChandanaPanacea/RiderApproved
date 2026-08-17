import { PXFieldState } from "client-controls";
import {
	PO101000,
	POSetup,
} from "src/screens/PO/PO101000/PO101000";

export interface PO101000_ACVI extends PO101000 { }

export class PO101000_ACVI { }

export interface POSetup_ACVI extends POSetup { }

export class POSetup_ACVI {
	UsrSite1ID: PXFieldState;
	UsrSite2ID: PXFieldState;
	UsrSite3ID: PXFieldState;
}