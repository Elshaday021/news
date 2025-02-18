import { Box, Button } from "@mui/material";
import { useCallback, useMemo, useState } from "react";
import { removeEmptyFields } from "../../utils";
import { WorkflowActionDialog } from "../../components/workflow";
import { useSubmitBusinessUnitMutation } from "../../app/api";

export const RequestApprovalButton = ({ id }: { id: number }) => {
  const [dialogOpened, setDialogOpened] = useState(false);
  const [submit, { error: submitError, reset: submitReset }] =
    useSubmitBusinessUnitMutation();

  const onDialogClose = useCallback(() => {
    submitReset();
    setDialogOpened(false);
    window.location.reload();
  }, [submitReset]);

  const handleSubmit = useCallback(
    (comment: string) => {
      submit({
        submitBusinessUnitCommand: removeEmptyFields({
          id,
          comment,
        }),
      })
        .unwrap()
        .then(onDialogClose)
        .catch(() => {});
    },
    [id, onDialogClose, submit]
  );

  const errors = useMemo(
    () => (submitError as any)?.data?.errors,
    [submitError]
  );

  return (
    <Box>
      <Button
        onClick={() => {
          setDialogOpened(true);
        }}
        size="small"
      >
        Submit for Approval
      </Button>

      {dialogOpened && (
        <WorkflowActionDialog
          title="Submit Approval Request"
          onClose={onDialogClose}
          onSubmit={handleSubmit}
          errors={errors}
        />
      )}
    </Box>
  );
};
