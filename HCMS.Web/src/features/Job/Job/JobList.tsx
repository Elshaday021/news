import {
  Box,
  Button,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { Fragment, useState } from "react";
import { JobCatagory, JobDto } from "../../../app/api";

interface JobListProps {
  items?: JobDto[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const JobList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: JobListProps) => {
  const [selectedJobCatagory, setSelectedJobCatagory] = useState<JobCatagory>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell sx={{fontWeight: 'bold'}}>Business Unit</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Job Title</TableCell>
                     <TableCell sx={{fontWeight: 'bold'}}>Vacant</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(items || []).map((item) => (
                <Fragment key={item.id}>
                  <TableRow
                    hover={false}
                    key={item.id}
                    sx={
                      !hideWorkflowComment
                        ? {
                            cursor: "pointer",
                            "& > *": { borderBottom: "unset" },
                          }
                        : {}
                    }
                  >
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.businessUnit}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.jobTitle}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.vacant}
                    </TableCell>
                  </TableRow>
                </Fragment>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </Box>
  );
};
