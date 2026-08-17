import {
    PXFieldState,
    placeAfterProperty, columnConfig
} from "client-controls";
import { SOLine } from "src/screens/SO/SO301000/SO301000";

export interface SOLine_Vendor_generated extends SOLine { }
export class SOLine_Vendor_generated {
    @placeAfterProperty('SiteID')
    @columnConfig({
        width: 180
    })
    UsrVendorID: PXFieldState;
    @placeAfterProperty('UsrVendorID')
    @columnConfig({
        width: 180
    })
    UsrEXTQtyOnHand: PXFieldState;

    @placeAfterProperty('UsrEXTQtyOnHand')
    @columnConfig({
        width: 180
    })
    UsrKCWHQtyOnHand: PXFieldState;

    @placeAfterProperty('UsrKCWHQtyOnHand')
    @columnConfig({
        width: 180
    })
    UsrMOStoreQtyOnHand: PXFieldState;
}