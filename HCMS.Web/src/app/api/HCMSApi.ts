import { emptySplitApi as api } from "./emptySplitApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    login: build.mutation<LoginApiResponse, LoginApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/login`,
        method: "POST",
        body: queryArg.userLogin,
        params: { returnUrl: queryArg.returnUrl },
      }),
    }),
    registerUser: build.mutation<RegisterUserApiResponse, RegisterUserApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/RegisterUser`,
        method: "POST",
        body: queryArg.userRegisterDto,
      }),
    }),
    verificationCode: build.mutation<
      VerificationCodeApiResponse,
      VerificationCodeApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Authentication/verification-code`,
        method: "POST",
        body: queryArg.verificationCode,
      }),
    }),
    getAllBusinessUnits: build.query<
      GetAllBusinessUnitsApiResponse,
      GetAllBusinessUnitsApiArg
    >({
      query: () => ({ url: `/api/BusinessUnit/all` }),
    }),
    getAllBuisnessUnitLists: build.query<
      GetAllBuisnessUnitListsApiResponse,
      GetAllBuisnessUnitListsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/allBusinessUnit`,
        params: {
          status: queryArg.status,
          pageNumber: queryArg.pageNumber,
          pageSize: queryArg.pageSize,
        },
      }),
    }),
    approveBusinessUnit: build.mutation<
      ApproveBusinessUnitApiResponse,
      ApproveBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/approve`,
        method: "POST",
        body: queryArg.approveBusinessUnitCommand,
      }),
    }),
    getBusinessUnitCountPerApprovalStatus: build.query<
      GetBusinessUnitCountPerApprovalStatusApiResponse,
      GetBusinessUnitCountPerApprovalStatusApiArg
    >({
      query: () => ({ url: `/api/BusinessUnit/counts` }),
    }),
    createBusinessUnit: build.mutation<
      CreateBusinessUnitApiResponse,
      CreateBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/CreateBusinessUnit`,
        method: "POST",
        body: queryArg.createBusinessUnitCommand,
      }),
    }),
    rejectBusinessUnit: build.mutation<
      RejectBusinessUnitApiResponse,
      RejectBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/Reject`,
        method: "POST",
        body: queryArg.rejectBusinessUnitCommand,
      }),
    }),
    submitBusinessUnit: build.mutation<
      SubmitBusinessUnitApiResponse,
      SubmitBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/submit`,
        method: "POST",
        body: queryArg.submitBusinessUnitCommand,
      }),
    }),
    updateBusinessUnit: build.mutation<
      UpdateBusinessUnitApiResponse,
      UpdateBusinessUnitApiArg
    >({
      query: (queryArg) => ({
        url: `/api/BusinessUnit/update`,
        method: "POST",
        body: queryArg.updateBusinessUnitCommand,
      }),
    }),
    createEmployeeProfile: build.mutation<
      CreateEmployeeProfileApiResponse,
      CreateEmployeeProfileApiArg
    >({
      query: (queryArg) => ({
        url: `/api/EmployeeProfile/add`,
        method: "POST",
        body: queryArg.createEmployeeProfileCommand,
      }),
    }),
    getAllEmployees: build.query<
      GetAllEmployeesApiResponse,
      GetAllEmployeesApiArg
    >({
      query: () => ({ url: `/api/EmployeeProfile/all` }),
    }),
    addJob: build.mutation<AddJobApiResponse, AddJobApiArg>({
      query: (queryArg) => ({
        url: `/api/Job/AddJob`,
        method: "POST",
        body: queryArg.addJobCommand,
      }),
    }),
    addJobCatagory: build.mutation<
      AddJobCatagoryApiResponse,
      AddJobCatagoryApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Job/AddJobCatagory`,
        method: "POST",
        body: queryArg.addJobCatagoryCommand,
      }),
    }),
    addJobGrade: build.mutation<AddJobGradeApiResponse, AddJobGradeApiArg>({
      query: (queryArg) => ({
        url: `/api/Job/AddJobGrade`,
        method: "POST",
        body: queryArg.addJobGradeCommand,
      }),
    }),
    addJobTitle: build.mutation<AddJobTitleApiResponse, AddJobTitleApiArg>({
      query: (queryArg) => ({
        url: `/api/Job/AddJobTitle`,
        method: "POST",
        body: queryArg.addJobTitleCommand,
      }),
    }),
    getAllJobCatagory: build.query<
      GetAllJobCatagoryApiResponse,
      GetAllJobCatagoryApiArg
    >({
      query: () => ({ url: `/api/Job/allJobCatagory` }),
    }),
    getAllJobGrade: build.query<
      GetAllJobGradeApiResponse,
      GetAllJobGradeApiArg
    >({
      query: () => ({ url: `/api/Job/allJobGrades` }),
    }),
    getAllJobList: build.query<GetAllJobListApiResponse, GetAllJobListApiArg>({
      query: () => ({ url: `/api/Job/AllJobList` }),
    }),
    getAllJobTitle: build.query<
      GetAllJobTitleApiResponse,
      GetAllJobTitleApiArg
    >({
      query: () => ({ url: `/api/Job/allJobTitles` }),
    }),
    getBusinessUnitJobList: build.query<
      GetBusinessUnitJobListApiResponse,
      GetBusinessUnitJobListApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Job/BusinessUnitJobList`,
        params: { businessUnitId: queryArg.businessUnitId },
      }),
    }),
    getAllLookups: build.query<GetAllLookupsApiResponse, GetAllLookupsApiArg>({
      query: () => ({ url: `/api/Lookup/all` }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as HCMSApi };
export type LoginApiResponse = /** status 200 Success */ LoginRes;
export type LoginApiArg = {
  returnUrl?: string;
  userLogin: UserLogin;
};
export type RegisterUserApiResponse = unknown;
export type RegisterUserApiArg = {
  userRegisterDto: UserRegisterDto;
};
export type VerificationCodeApiResponse = /** status 200 Success */ void;
export type VerificationCodeApiArg = {
  verificationCode: VerificationCode;
};
export type GetAllBusinessUnitsApiResponse =
  /** status 200 Success */ BusinessUnitLists;
export type GetAllBusinessUnitsApiArg = void;
export type GetAllBuisnessUnitListsApiResponse =
  /** status 200 Success */ BusinessUnitSearchResult;
export type GetAllBuisnessUnitListsApiArg = {
  status?: ApprovalStatus;
  pageNumber?: number;
  pageSize?: number;
};
export type ApproveBusinessUnitApiResponse = /** status 200 Success */ number;
export type ApproveBusinessUnitApiArg = {
  approveBusinessUnitCommand: ApproveBusinessUnitCommand;
};
export type GetBusinessUnitCountPerApprovalStatusApiResponse =
  /** status 200 Success */ BusinessUnitCountsByStatus;
export type GetBusinessUnitCountPerApprovalStatusApiArg = void;
export type CreateBusinessUnitApiResponse = /** status 200 Success */ number;
export type CreateBusinessUnitApiArg = {
  createBusinessUnitCommand: CreateBusinessUnitCommand;
};
export type RejectBusinessUnitApiResponse = /** status 200 Success */ number;
export type RejectBusinessUnitApiArg = {
  rejectBusinessUnitCommand: RejectBusinessUnitCommand;
};
export type SubmitBusinessUnitApiResponse = /** status 200 Success */ number;
export type SubmitBusinessUnitApiArg = {
  submitBusinessUnitCommand: SubmitBusinessUnitCommand;
};
export type UpdateBusinessUnitApiResponse = /** status 200 Success */ number;
export type UpdateBusinessUnitApiArg = {
  updateBusinessUnitCommand: UpdateBusinessUnitCommand;
};
export type CreateEmployeeProfileApiResponse = /** status 200 Success */ number;
export type CreateEmployeeProfileApiArg = {
  createEmployeeProfileCommand: CreateEmployeeProfileCommand;
};
export type GetAllEmployeesApiResponse =
  /** status 200 Success */ EmployeeDto[];
export type GetAllEmployeesApiArg = void;
export type AddJobApiResponse = /** status 200 Success */ number;
export type AddJobApiArg = {
  addJobCommand: AddJobCommand;
};
export type AddJobCatagoryApiResponse = /** status 200 Success */ number;
export type AddJobCatagoryApiArg = {
  addJobCatagoryCommand: AddJobCatagoryCommand;
};
export type AddJobGradeApiResponse = /** status 200 Success */ string;
export type AddJobGradeApiArg = {
  addJobGradeCommand: AddJobGradeCommand;
};
export type AddJobTitleApiResponse = /** status 200 Success */ number;
export type AddJobTitleApiArg = {
  addJobTitleCommand: AddJobTitleCommand;
};
export type GetAllJobCatagoryApiResponse =
  /** status 200 Success */ JobCatagory[];
export type GetAllJobCatagoryApiArg = void;
export type GetAllJobGradeApiResponse = /** status 200 Success */ JobGrade[];
export type GetAllJobGradeApiArg = void;
export type GetAllJobListApiResponse = /** status 200 Success */ JobDto[];
export type GetAllJobListApiArg = void;
export type GetAllJobTitleApiResponse = /** status 200 Success */ JobTitleDto[];
export type GetAllJobTitleApiArg = void;
export type GetBusinessUnitJobListApiResponse =
  /** status 200 Success */ JobDto[];
export type GetBusinessUnitJobListApiArg = {
  businessUnitId?: number;
};
export type GetAllLookupsApiResponse = /** status 200 Success */ LookupDto;
export type GetAllLookupsApiArg = void;
export type LoginRes = {
  isSuccess?: boolean;
  needVerification?: boolean | null;
  isLockedOut?: boolean | null;
};
export type ProblemDetails = {
  type?: string | null;
  title?: string | null;
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
};
export type UserLogin = {
  userEmail?: string | null;
  password?: string | null;
};
export type UserRegisterDto = {
  email?: string | null;
  firstName?: string | null;
  middleName?: string | null;
  lastName?: string | null;
  branchId?: number;
  roles?: string[] | null;
};
export type VerificationCode = {
  code?: string | null;
};
export type BusinessUnitTypeEnum = 1 | 2 | 3 | 4 | 5;
export type ApprovalStatus = 1 | 2 | 3 | 4;
export type BusinessUnitDto = {
  id?: number;
  businessUnitID?: string | null;
  name?: string | null;
  parentBusinessUnitName?: string | null;
  parentId?: number;
  businessUnitTypeName?: string | null;
  type?: BusinessUnitTypeEnum;
  areaCode?: string | null;
  address?: string | null;
  staffStrength?: number | null;
  approvalStatus?: ApprovalStatus;
};
export type BusinessUnitLists = {
  approved?: BusinessUnitDto[] | null;
  submitted?: BusinessUnitDto[] | null;
  rejected?: BusinessUnitDto[] | null;
  draft?: BusinessUnitDto[] | null;
};
export type BusinessUnitSearchResult = {
  items?: BusinessUnitDto[] | null;
  totalCount?: number;
};
export type ApproveBusinessUnitCommand = {
  id?: number;
};
export type BusinessUnitCountsByStatus = {
  approved?: number;
  approvalRequests?: number;
  rejected?: number;
  drafts?: number;
};
export type CreateBusinessUnitCommand = {
  name?: string | null;
  parentId?: number;
  type?: BusinessUnitTypeEnum;
  areaCode?: string | null;
  address?: string | null;
  staffStrength?: number | null;
};
export type RejectBusinessUnitCommand = {
  id?: number;
};
export type SubmitBusinessUnitCommand = {
  id?: number;
};
export type UpdateBusinessUnitCommand = {
  id?: number;
  name?: string | null;
  parentId?: number;
  type?: BusinessUnitTypeEnum;
  areaCode?: string | null;
  address?: string | null;
  staffStrength?: number | null;
};
export type Gender = 1 | 2;
export type MartialStatus = 1 | 2 | 3 | 4;
export type CreateEmployeeProfileCommand = {
  name?: string | null;
  businessUnitID?: number;
  jobId?: number;
  birthDate?: string;
  employementDate?: string;
  gender?: Gender;
  martialStatus?: MartialStatus;
};
export type EmployeeDto = {
  id?: number;
  employeeId?: number;
  employeeName?: string | null;
  businessUnit?: string | null;
  jobTitle?: string | null;
  birthDate?: string;
  employementDate?: string;
  gender?: Gender;
  martialStatus?: MartialStatus;
};
export type AddJobCommand = {
  jobTitleID?: number;
  businessunitId?: number;
};
export type AddJobCatagoryCommand = {
  name?: string | null;
  description?: string | null;
};
export type AddJobGradeCommand = {
  name?: string | null;
  description?: string | null;
};
export type JobCatagoryEnum = 1 | 2 | 3 | 4;
export type JobGradeEnum = 1 | 2 | 3 | 4 | 5;
export type AddJobTitleCommand = {
  id?: number;
  title?: string | null;
  description?: string | null;
  jobCatagoryId?: JobCatagoryEnum;
  jobGradeId?: JobGradeEnum;
};
export type JobCatagory = {
  value?: JobCatagoryEnum;
  name?: string | null;
  description?: string | null;
};
export type JobGrade = {
  value?: JobGradeEnum;
  name?: string | null;
  description?: string | null;
};
export type JobDto = {
  id?: number;
  jobTitle?: string | null;
  businessUnit?: string | null;
  businessUnitId?: number | null;
  vacant?: string | null;
  isVacant?: boolean;
};
export type JobTitleDto = {
  id?: number;
  title?: string | null;
  description?: string | null;
  jobCatagory?: string | null;
  jobGrade?: string | null;
};
export type BusinessUnitType = {
  value?: BusinessUnitTypeEnum;
  name?: string | null;
  description?: string | null;
};
export type LookupDto = {
  jobTitles?: JobTitleDto[] | null;
  jobCatagories?: JobCatagory[] | null;
  jobGrades?: JobGrade[] | null;
  businessUnits?: BusinessUnitLists;
  businessUnitTypes?: BusinessUnitType[] | null;
};
export const {
  useLoginMutation,
  useRegisterUserMutation,
  useVerificationCodeMutation,
  useGetAllBusinessUnitsQuery,
  useLazyGetAllBusinessUnitsQuery,
  useGetAllBuisnessUnitListsQuery,
  useLazyGetAllBuisnessUnitListsQuery,
  useApproveBusinessUnitMutation,
  useGetBusinessUnitCountPerApprovalStatusQuery,
  useLazyGetBusinessUnitCountPerApprovalStatusQuery,
  useCreateBusinessUnitMutation,
  useRejectBusinessUnitMutation,
  useSubmitBusinessUnitMutation,
  useUpdateBusinessUnitMutation,
  useCreateEmployeeProfileMutation,
  useGetAllEmployeesQuery,
  useLazyGetAllEmployeesQuery,
  useAddJobMutation,
  useAddJobCatagoryMutation,
  useAddJobGradeMutation,
  useAddJobTitleMutation,
  useGetAllJobCatagoryQuery,
  useLazyGetAllJobCatagoryQuery,
  useGetAllJobGradeQuery,
  useLazyGetAllJobGradeQuery,
  useGetAllJobListQuery,
  useLazyGetAllJobListQuery,
  useGetAllJobTitleQuery,
  useLazyGetAllJobTitleQuery,
  useGetBusinessUnitJobListQuery,
  useLazyGetBusinessUnitJobListQuery,
  useGetAllLookupsQuery,
  useLazyGetAllLookupsQuery,
} = injectedRtkApi;
