import React from "react";


export interface PMSApiHttpClient {
//   Shareholders?: ShareholdersClient;
//   Allocations?: AllocationClient;
//   Subscriptions?: SubscriptionsClient;
//   account?: AccountClient;
//   admin?: AdminClient;
//   user?: UsersClient;
//   SubscriptionGroup?: GroupClient;
//   Payments?: PaymentsClient;
//   Parvalues?: ParValueClient;
//   Transfers?: TransfersClient;
//   SubscriptionAllocation?: SubscriptionAllocationClient;
}

export const HttpClientContext = React.createContext<
  PMSApiHttpClient | undefined
>(undefined);
