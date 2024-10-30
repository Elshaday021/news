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
import { EmployeeDto } from "../../app/api/HCMSApi";

interface EmployeeListProps {
  items?: EmployeeDto[];
  hideWorkflowComment?: boolean;
  suppressActionColumn?: boolean;
}

export const EmployeeList = ({
  items = [],
  hideWorkflowComment,
  suppressActionColumn,
}: EmployeeListProps) => {
  const [selectedEmployee, setSelectedEmployee] = useState<EmployeeDto>();

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Business Unit</TableCell>
                <TableCell>Job Title</TableCell>
                <TableCell>Employee ID</TableCell>
                {/* {!suppressActionColumn && (
                  <TableCell align="center">Actions</TableCell>
                )} */}
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
                      {item.employeeName}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.businessUnit}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.jobTitle}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.employeeId}
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
