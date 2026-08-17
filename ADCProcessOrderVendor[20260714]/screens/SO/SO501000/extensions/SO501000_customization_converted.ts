import {
  PXFieldState,
  PXFieldOptions,
  placeAfterProperty
} from "client-controls";
import { SO501000, Filter } from "src/screens/SO/SO501000/SO501000";

export interface SO501000_FilterExt extends Filter { }
export class SO501000_FilterExt {
  @placeAfterProperty("SiteID")
  UsrIsPrintedReport: PXFieldState<PXFieldOptions.CommitChanges>;
}