import { Form, Formik } from "formik";
import { useCallback, useEffect, useState } from "react";
import { DialogHeader, FormSelectField, FormTextField } from "../../components";
import { useBusinessUnit } from "./useBusinessUnits";
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
  CreateBusinessUnitCommand,
  useCreateBusinessUnitMutation,
  useUpdateBusinessUnitMutation,
} from "../../app/api/HCMSApi";
import { useBusinessUnitType } from "./useBusinessUnitType";

const emptyBusinessUnitData = {
  businessUnitName: "",
  parentId: "",
} as any;
export const BusinessUnitDialog = ({
  onClose,
  title,
  businessUnit,
}: {
  onClose: () => void;
  title: string;
  businessUnit?: BusinessUnitDto;
}) => {
  const [businessUnitData, setBusinessUnit] = useState<BusinessUnitDto>();

  const [addBusinessUnit] = useCreateBusinessUnitMutation();
  const [updateBusinessUnit] = useUpdateBusinessUnitMutation();
  const { businessUnitLookups } = useBusinessUnit();
  const { businessUnitTypeLookups } = useBusinessUnitType();

  useEffect(() => {
    setBusinessUnit({
      ...emptyBusinessUnitData,
      ...businessUnit,
    });
  }, [businessUnit]);

  const handleSubmit = useCallback(
    (values: BusinessUnitDto) => {
      (businessUnit?.id
        ? updateBusinessUnit({
            updateBusinessUnitCommand: values,
          })
        : addBusinessUnit({
            createBusinessUnitCommand: values,
          })
      )
        .unwrap()
        .then(() => {
          onClose();
          window.location.reload();
        });
    },
    [onClose, addBusinessUnit]
  );
  return (
    <Dialog
      scroll={"paper"}
      disableEscapeKeyDown={true}
      maxWidth={"md"}
      open={true}
    >
      {!!businessUnitData && (
        <Formik
          initialValues={businessUnitData as any}
          enableReinitialize={true}
          onSubmit={handleSubmit}
          //validationSchema={validationSchema}
          validateOnChange={true}
        >
          <Form>
            <DialogHeader title={title} onClose={onClose} />
            <DialogContent dividers={true}>
              <Grid container spacing={2}>
                {/* {errors && (
                  <Grid item xs={12}>
                    <Errors errors={errors as any} />
                  </Grid>
                )} */}

                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormTextField
                      name="name"
                      label="Business Unit Name"
                      type="text"
                    />
                    <FormSelectField
                      name="type"
                      label="Business Unit Type "
                      type="number"
                      options={businessUnitTypeLookups}
                    />
                  </Box>
                </Grid>
                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormSelectField
                      name="parentId"
                      label="Parent Business Unit"
                      type="number"
                      options={businessUnitLookups}
                    />
                    <FormTextField
                      name="staffStrength"
                      label="Staff Strength"
                      type="text"
                    />
                  </Box>
                </Grid>

                <Grid item xs={12}>
                  <Box sx={{ display: "flex", gap: 2 }}>
                    <FormTextField
                      name="areaCode"
                      label="Business Unit Area Code"
                      type="text"
                    />

                    <FormTextField
                      name="address"
                      label="Business Unit Address"
                      type="text"
                    />
                  </Box>
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
