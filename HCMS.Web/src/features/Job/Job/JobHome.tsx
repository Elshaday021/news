import { Box, Button } from "@mui/material"
import { JobDialog } from "./JobDialog"
import { useState } from "react";
import SetupMenu from "../SetupMenu";
import { PageHeader } from "../../../components/PageHeader";
import WorkIcon from "@mui/icons-material/Work";
import AddIcon from "@mui/icons-material/Add";

export const JobHome = ()=>{
    const[dialogOpened, setDialogOpened]=useState(false);
    return(
<Box>
      <SetupMenu />
      <Box sx={{ display: "flex" }}>
      <PageHeader
          title={"Job List"}
          icon={<WorkIcon sx={{ fontSize: 15, color: "#1976d2" }} />}
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
          //    disabled={!permissions.canCreateOrUpdateAllocation}
        >
          Add New Job
        </Button>
                    {dialogOpened && (
                <JobDialog 
                onClose={()=>{setDialogOpened(false)}}
                />)}

</Box>
        </Box>
    )
}