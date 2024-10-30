import AddIcon from "@mui/icons-material/Add";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import { Box, Button, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { PageHeader } from "../../components/PageHeader";
import { EmployeeDialog } from "./EmployeeDialog";
import { useNavigate } from "react-router-dom";
import { useGetAllEmployeesQuery } from "../../app/api";
import { EmployeeList } from "./EmployeeList";
import SetupMenu from "../Job/SetupMenu";

const Header = ({ text }: { text: string }) => (
  <Typography
    variant="h5"
    sx={{ lineHeight: 2.5, flex: 1, pt: 2, display: "block" }}
    color="textSecondary"
  >
    {text}
  </Typography>
);

export const EmployeesHome = () => {
  // const { allocations } = useAllocations();
  const [dialogOpened, setDialogOpened] = useState(false);
  const { data } = useGetAllEmployeesQuery();
  // const permissions = usePermission();
  const navigate = useNavigate();
  return (
    <Box>
      <PageHeader title={"Employees"} icon={undefined} />
      <Box sx={{ display: "flex" }}>
        <Box sx={{ flex: 1 }}></Box>
        <Button
          variant="outlined"
          startIcon={<AddIcon />}
          onClick={() => {
            setDialogOpened(true);
            //navigate('/test')
          }}
          //    disabled={!permissions.canCreateOrUpdateAllocation}
        >
          Add New Employee
        </Button>
      </Box>

      {dialogOpened && (
        <EmployeeDialog
          onClose={() => {
            setDialogOpened(false);
          }}
          // title="Add Allocation"
        />
      )}
      <Box>
        <EmployeeList items={data} />
      </Box>
    </Box>
  );
};
