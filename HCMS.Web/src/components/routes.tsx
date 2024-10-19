import { useEffect, useMemo } from "react";
import {
  matchRoutes,
  Navigate,
  Route,
  Routes,
  useLocation,
  useNavigate,
} from "react-router-dom";



import { useAuth } from "../hooks";
import { Login, MFA } from "../features/user";
import { Admin } from "../features/HCMSAdmin";
import Home from "../Home";

const AppRoutes = () => {
  const navigate = useNavigate();
  const { loggedIn } = useAuth();

  const location = useLocation();
  const matches = matchRoutes([{ path: "/login" }], location);

  useEffect(() => {
    if (loggedIn && matches && matches[0].pathname === "/login") {
      navigate("/login");
    }
  }, [loggedIn, navigate, matches]);

  // const permissions = usePermission();

  // const isSysAdmin = useMemo(() => {
  //   return permissions.canCreateOrUpdateUser;
  // }, [permissions.canCreateOrUpdateUser]);

  // const isShareHead = useMemo(() => {
  //   return permissions.canProcessEndOfDay;
  // }, [permissions.canProcessEndOfDay]);

  return (
    <Routes>
      <Route path="login" element={<Login />} />
      <Route path="verify" element={<MFA />} />
     
      <Route path="home" element={<Home />} />
      {/* <Route path="forgot-password" element={<ForgotPassword />} />
      <Route element={<AuthenticatedRoutes />}>
        <Route path="/" element={<Navigate to="/shareholders" replace />} />
        <Route path="/shareholders" element={<Shareholders />}>
          <Route index element={<ApprovedShareholders />} />
          <Route path="approval-requests" element={<ApprovalRequests />} />
          <Route
            path="rejected-approval-requests"
            element={<RejectedApprovalRequests />}
          />
          <Route path="draft" element={<DraftShareholders />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Route>
        <Route path="/shareholder-detail/:id" element={<ShareholderDetail />}>
          <Route index element={<SummaryTab />} />
          <Route path="summary" element={<SummaryTab />} />
          <Route path="subscriptions" element={<SubscriptionTab />} />
          <Route path="payments" element={<PaymentTab />} />
          <Route path="transfers" element={<TransferTab />} />
          <Route path="dividends" element={<DividendTab />} />
          <Route path="documents" element={<DocumentsTab />} />
          <Route path="certificates" element={<CertificateTab />} />
        </Route>
        <Route path="/admin/:tab?" element={<Admin />}>
          <Route index element={<BankAllocation />} />
          <Route path="par-values" element={<ParValues />} />
          <Route path="bank-allocation" element={<BankAllocation />} />
          <Route path="allocations" element={<Allocations />} />
          <Route path="subscription-groups" element={<SubscriptionGroup />} />
          <Route path="dividend-setup" element={<DividendSetup />} />
        </Route>
        {isSysAdmin && (
          <Route path="/sys-admin" element={<SysAdminDashboard />}>
            <Route index element={<Users />} />
            <Route path="users" element={<Users />}></Route>
            <Route path="users/:id/:tab?" element={<UserDetail />}></Route>
            <Route path="new-user" element={<RegisterNewUser />}></Route>
          </Route>
        )}
        <Route path="/reports" element={<ReportsDashboard />}></Route>
        {isShareHead && <Route path="/endofday" element={<EndOfDaysForm />} />}
      </Route> */}
    </Routes>
  );
};

export default AppRoutes;
