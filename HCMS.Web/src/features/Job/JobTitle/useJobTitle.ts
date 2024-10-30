import { useMemo } from "react";
import { SelectOption } from "../../../types";
import { useGetAllLookupsQuery } from "../../../app/api/HCMSApi";

export const useJobTitle = () => {
  const { data } = useGetAllLookupsQuery();

  const { JobTitlesLookups, jobTitles } = useMemo(() => {
    const JobTitlesLookups = (data?.jobTitles || []).map<SelectOption>(
      ({ id, title, description }) => ({
        label: title || description || "",
        value: id,
      })
    );

    return { JobTitlesLookups, jobTitles: data?.jobTitles || [] };
  }, [data]);
  return {
    jobTitles,
    JobTitlesLookups,
  };
};
