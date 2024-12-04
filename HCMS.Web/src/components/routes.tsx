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
import Home from "../Home";
import { BusinessUnitsHome } from "../features/BusinessUnit";
import { JobCatagoryHome } from "../features/Job/JobCatagory/JobCatagoryHome";
import { JobGradeHome } from "../features/Job/JobGrade/JobGradeHome";
import { JobTitleHome } from "../features/Job/JobTitle/JobTitleHome";
import { EmployeesHome } from "../features/Employee/EmployeeHome";
import { JobHome } from "../features/Job/Job/JobHome";
import {
  ApprovalRequests,
  ApprovedBusinessUnits,
  DraftBusinessUnits,
  RejectedApprovalRequests,
} from "../features/BusinessUnit/BuisnessUnitGrids";

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

  return (
    <Routes>
      <Route path="login" element={<Login />} />
      <Route path="verify" element={<MFA />} />

      <Route path="home" element={<Home />} />
      <Route path="" element={<Home />} />
      <Route path="/businessunit" element={<BusinessUnitsHome />}>
        <Route index element={<ApprovedBusinessUnits />} />
        <Route path="approval-requests" element={<ApprovalRequests />} />
        <Route
          path="rejected-approval-requests"
          element={<RejectedApprovalRequests />}
        />
        <Route path="draft" element={<DraftBusinessUnits />} />
      </Route>
      <Route path="jobcatagory" element={<JobCatagoryHome />} />
      <Route path="jobgrade" element={<JobGradeHome />} />
      <Route path="jobtitle" element={<JobTitleHome />} />
      <Route path="employees" element={<EmployeesHome />} />
      <Route path="job" element={<JobHome />} />
    </Routes>
  );
};

export default AppRoutes;
