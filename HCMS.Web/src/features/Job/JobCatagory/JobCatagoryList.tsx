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
import { JobCatagory } from "../../../app/api";

interface JobCatagoryListProps {
  items?: JobCatagory[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const JobCatagoryList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: JobCatagoryListProps) => {
  const [selectedJobCatagory, setSelectedJobCatagory] = useState<JobCatagory>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Description</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(items || []).map((item) => (
                <Fragment key={item.value}>
                  <TableRow
                    hover={false}
                    key={item.value}
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
                      {item.name}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.description}
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
