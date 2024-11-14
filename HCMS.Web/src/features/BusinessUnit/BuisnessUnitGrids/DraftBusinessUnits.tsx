import {
  Avatar,
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
import CircularProgress from "@mui/material/CircularProgress";
import { Fragment, useState } from "react";
import { BusinessUnitDto, useGetAllBuisnessUnitListsQuery, useGetAllBusinessUnitsQuery, useGetBusinessUnitCountPerApprovalStatusQuery, useGetBusinessUnitJobListQuery } from "../../../app/api";
import { ApprovalStatus } from "../../../app/api/enums";
import { BusinessUnitDialog } from "../BusinessUnitDialog";
import { RequestApprovalButton } from "../RequestApprovalButton";
import { ApproveOrRejectRequestButton } from "../ApproveOrRejectRequestButton";

export const DraftBusinessUnits = () => {
  const [pagination, setPagination] = useState<{
    pageNumber: number;
    pageSize?: number;
  }>({
    pageNumber: 0,
    pageSize: 10,
  });
  const { data: counts, isLoading: isCountsLoading } =
    useGetBusinessUnitCountPerApprovalStatusQuery();
  const { data:items, isLoading: isListLoading } = useGetAllBuisnessUnitListsQuery({
    pageNumber: pagination.pageNumber + 1,
    pageSize: pagination.pageSize,
    status: ApprovalStatus.Draft,
  });
  const [selectedBusinessUnit, setSelectedBusinessUnit] =
    useState<BusinessUnitDto>();
  const isLoading = isCountsLoading || isListLoading;

  return (
    <Box>
      <Paper>
        <TableContainer>
          <Table size="medium">
            <TableHead>
              <TableRow>
                <TableCell sx={{fontWeight: 'bold'}}>Name</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}>Parent BusinessUnit</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}> BusinessUnit ID</TableCell>
                <TableCell sx={{fontWeight: 'bold'}}> BusinessUnit Type</TableCell>
                <TableCell align="center">Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(items?.items || []).map((item )  => (
                <Fragment key={item.id}>
                  <TableRow
                    hover={false}
                    key={item.id}
                  >
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.name}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.parentBusinessUnit?.name}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.businessUnitID}
                    </TableCell>
                    <TableCell sx={{ verticalAlign: "top", width: 200 }}>
                      {item.type}
                    </TableCell>
                    <TableCell>
                    <Box
                            sx={{
                              display: "flex",
                              justifyContent: "center",
                              gap: 1,
                            }}>
                    {item.id && (
                              <>
                                {item.approvalStatus ===
                                  ApprovalStatus.Draft && (
                                  <RequestApprovalButton id={item.id} />
                                )}
                                {item.approvalStatus ===
                                  ApprovalStatus.Submitted && (
                                  <ApproveOrRejectRequestButton id={item.id} />
                                )}
                              </>
                            )}
                            {item.approvalStatus===(ApprovalStatus.Draft||ApprovalStatus.Rejected)&&( 
                    <Button
                                size="small"
                                onClick={() => setSelectedBusinessUnit(item)}
                              >
                                Edit
                              </Button>
                            )}
                              </Box>
                              </TableCell>
                  </TableRow>
                </Fragment>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
      
      {selectedBusinessUnit && (
        <BusinessUnitDialog
        businessUnit={selectedBusinessUnit}
        onClose={() => {
          setSelectedBusinessUnit(undefined);
        }}
             title="Edit BusinesUnit"
        />
      )}
           
    </Box>
  );
};
