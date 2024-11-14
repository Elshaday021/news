import AddIcon from "@mui/icons-material/Add";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import { Box, Button, Divider, Grid, Paper, Typography } from "@mui/material";
import { useState } from "react";
import { PageHeader } from "../../components/PageHeader";
import { BusinessUnitDialog } from "./BusinessUnitDialog";
import { Outlet, useNavigate } from "react-router-dom";
import GroupsIcon from "@mui/icons-material/Groups";
import { BusinessUnitList } from "./BusinessUnitList";
import { useBusinessUnit } from "./useBusinessUnits";
import { useGetAllBusinessUnitsQuery, useGetBusinessUnitCountPerApprovalStatusQuery } from "../../app/api";
import BusinessCenterIcon from "@mui/icons-material/BusinessCenter";
import SetupMenu from "../Job/SetupMenu";
import { BusinessUnitListTabs } from "./BuisnessUnitGrids/BusinessUnitListTabs";

const Header = ({ text }: { text: string }) => (
  <Typography
    variant="h5"
    sx={{ lineHeight: 2.5, flex: 1, pt: 2, display: "block" }}
    color="textSecondary"
  >
    {text}
  </Typography>
);

export const BusinessUnitsHome = () => {
  const [dialogOpened, setDialogOpened] = useState(false);
  const { data:businessUnits  } = useGetAllBusinessUnitsQuery();
  const { data: businessUnitCounts } =
    useGetBusinessUnitCountPerApprovalStatusQuery();
  const navigate = useNavigate();
  return (
    <Box>
           <SetupMenu />
           <Box sx={{ display: "flex" }}>
        <PageHeader
          title={"Buisness Units"}
          icon={<BusinessCenterIcon sx={{ fontSize: 15, color: "#1976d2" }} />}
        />
        <Box sx={{ flex: 1 }}></Box>
        
        <Button
          variant="outlined"
          startIcon={<AddIcon />}
          onClick={() => {
            setDialogOpened(true);
            //navigate('/test')
          }}
          sx={{
            color: "#fff", // Text color
            borderColor: "#1976d2", // Border color
            backgroundColor: "#1976d2",
            "&:hover": {
              backgroundColor: "#1976d2", // Background color on hover
              color: "#fff", // Text color on hover
              borderColor: "#1976d2", // Border color on hover
            },
          }}
        >
          Add New Business Unit
        </Button>
      </Box>
      <Paper sx={{ p: 2, flex: 1 }}>
        <BusinessUnitListTabs counts={businessUnitCounts} />
        <Divider />
        <Outlet />
      </Paper>
      {dialogOpened && (
        <BusinessUnitDialog
          onClose={() => {
            setDialogOpened(false);
            //refetch();
          }}
           title="Add BusinesUnit"
        />
      )}
    </Box>
  );
};
