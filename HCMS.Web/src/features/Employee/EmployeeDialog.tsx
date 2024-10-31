import { Form, Formik } from "formik";
import { useCallback, useEffect, useState } from "react";
import { DialogHeader, FormSelectField, FormTextField } from "../../components";
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  Grid,
} from "@mui/material";
import {
  BusinessUnitDto,
  CreateEmployeeProfileCommand,
  EmployeeDto,
  useCreateBusinessUnitMutation,
  useCreateEmployeeProfileMutation,
} from "../../app/api/HCMSApi";
import { useBusinessUnit } from "../BusinessUnit/useBusinessUnits";
import { useJobTitle } from "../Job/JobTitle/useJobTitle";

const emptyEmployeeData = {
  employeeName: "",
  employeeID: "",
} as any;
export const EmployeeDialog = ({ onClose }: { onClose: () => void }) => {
  // const [open, setOpen] = useState(false);
  const [EmployeeData, setEmployee] = useState<EmployeeDto>();
  const [addEmployee] = useCreateEmployeeProfileMutation();
  const { businessUnitLookups } = useBusinessUnit();
  const { jobTitlesLookups } = useJobTitle();
  useEffect(() => {
    setEmployee({
      ...emptyEmployeeData,
      ...EmployeeData,
    });
  }, [emptyEmployeeData, EmployeeData]);

  const handleSubmit = useCallback(
    (values: CreateEmployeeProfileCommand) => {
      addEmployee({
        createEmployeeProfileCommand: values,
      })
        .unwrap()
        .then(onClose);
    },
    [onClose, addEmployee]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!EmployeeData && (
        <Formik
          initialValues={EmployeeData}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title="Add Employee" onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <FormTextField
                    name="employeeName"
                    label="Employee Full Name"
                    type="text"
                  />
                </Grid>
                <Grid item xs={12}>
                  <Grid item xs={12}>
                    <Box sx={{ display: "flex", gap: 2 }}>
                      <FormSelectField
                        name="businessUnitId"
                        label="Business Unit"
                        type="number"
                        options={businessUnitLookups}
                      />
                    </Box>
                  </Grid>
                  <Grid item xs={12}>
                    <Box sx={{ display: "flex", gap: 2 }}>
                      <FormSelectField
                        name="jobId"
                        label="Job Title"
                        type="number"
                        options={jobTitlesLookups}
                      />
                    </Box>
                  </Grid>
                  <Grid item xs={12}>
                    <FormTextField
                      name="employeeID"
                      label="EmployeeID"
                      type="text"
                    />
                  </Grid>
                </Grid>
              </Grid>
            </DialogContent>
            <DialogActions sx={{ p: 2 }}>
              <Button onClick={onClose}>Cancel</Button>
              <Button color="primary" variant="outlined" type="submit">
                Save
              </Button>
            </DialogActions>
          </Form>
        </Formik>
      )}
    </Dialog>
  );
};
