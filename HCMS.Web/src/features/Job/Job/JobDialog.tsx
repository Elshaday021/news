import { Box, Button, Dialog, DialogActions, DialogContent, Grid } from "@mui/material"
import { DialogHeader, FormSelectField, FormTextField } from "../../../components"
import { AddJobCommand, useAddJobMutation } from "../../../app/api"
import { Form, Formik } from "formik";
import { useCallback } from "react";
import { useNavigate } from "react-router-dom";
import { useBusinessUnit } from "../../BusinessUnit";
import { useJobTitle } from "../JobTitle/useJobTitle";

const initalValues ={
    jobTitleId:"1",
    businessUnitId:""
}
export const JobDialog =({onClose}:{onClose:()=>void} )=>{
    const [addNewJob]= useAddJobMutation();
    const{businessUnitLookups}=useBusinessUnit();
    const{jobTitlesLookups}=useJobTitle();
 
    const handleSubmit=useCallback(
        async(values:AddJobCommand) =>{
            addNewJob({
                addJobCommand:values
            })
            .unwrap()
            .then(onClose);
        },[addNewJob,onClose]
    )

    return(
  <Dialog 
        scroll="paper"
        open={true}
        >
        <Formik
        initialValues={initalValues}
        onSubmit={handleSubmit}
        >
    <Form>
    <DialogHeader title="Add New Job" onClose={onClose} />
    <DialogContent dividers={true}>
        <Grid container spacing={2}>
        <Grid item xs={12}>
        <Box sx={{ display: "flex", gap: 2 }}>
                <FormSelectField 
                name="jobTitleId"
                label="Job Title"
                type="number"
                options={jobTitlesLookups}
                />
                </Box>
                     </Grid>

                     <Grid item xs={12}>
                <FormSelectField
                name="businessUnitId"
                label="Business Unit"
                type="number"
                options={businessUnitLookups}
                />
            </Grid>
</Grid>
            </ DialogContent>
            <DialogActions>
                
            <Button color="primary" variant="outlined" type="submit">
                Save
              </Button>
              <Button onClick={onClose}>
                Cancel
              </Button>
            </DialogActions>

        </Form>
        </Formik>
        </Dialog>
    )
}