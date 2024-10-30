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
import { JobGrade } from "../../../app/api";

interface JobGradeListProps {
  items?: JobGrade[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const JobGradeList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: JobGradeListProps) => {
  const [selectedJobGrade, setSelectedJobGrade] = useState<JobGrade>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Description</TableCell>

                {/* {!suppressActionColumn && (
                  <TableCell align="center">Actions</TableCell>
                )} */}
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

                    {/* <TableCell
                      sx={{
                        whiteSpace: "normal",
                        wordWrap: "break-word",
                        verticalAlign: "top",
                      }}
                    >

                    </TableCell>
               */}
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
