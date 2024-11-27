import { Box, Button } from "@mui/material"
import { JobDialog } from "./JobDialog"
import { useState } from "react";
import { PageHeader } from "../../../components/PageHeader";
import WorkIcon from "@mui/icons-material/Work";
import AddIcon from "@mui/icons-material/Add";
import { JobList } from "./JobList";
import { useGetAllJobListQuery } from "../../../app/api";
import SetupMenu from "../SetupMenu";

export const JobHome = ()=>{
    const[dialogOpened, setDialogOpened]=useState(false);
    const { data } = useGetAllJobListQuery();
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
        >
          Add New Job
        </Button>
                    {dialogOpened && (
                <JobDialog 
                onClose={()=>{setDialogOpened(false)
                  window.location.reload();
                }
              }
                
                />)}

</Box>
<Box>
        <JobList items={data} />
      </Box>
        </Box>
    )
}