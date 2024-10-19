import { ReactNode, useEffect, useState } from "react";

import { HttpClientContext, PMSApiHttpClient,  } from "./HttpClientContext";

interface Props {
  children?: ReactNode;
}

export const HttpClientContextProvider = ({ children }: Props) => {
  const [client, setClient] = useState<PMSApiHttpClient>();
  useEffect(() => {
    setClient({
    //   Shareholders: new ShareholdersClient(),
    //   Allocations: new AllocationClient(),
    //   Subscriptions: new SubscriptionsClient(),
    //   account: new AccountClient(),
    //   user: new UsersClient(),
    //   Parvalues: new ParValueClient(),
    //   SubscriptionGroup: new GroupClient(),
    //   admin: new AdminClient(),
    //   Payments: new PaymentsClient(),
    //   Transfers: new TransfersClient(),
    //   SubscriptionAllocation: new SubscriptionAllocationClient(),
    });
  }, []);

  return (
    <HttpClientContext.Provider value={client}>
      {children}
    </HttpClientContext.Provider>
  );
};
