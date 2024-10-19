import { emptySplitApi as api } from "./emptySplitApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    logins: build.mutation<LoginsApiResponse, LoginsApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/LoginUser`,
        method: "POST",
        body: queryArg.userLogin,
      }),
    }),
    registerUser: build.mutation<RegisterUserApiResponse, RegisterUserApiArg>({
      query: (queryArg) => ({
        url: `/api/Authentication/RegisterUser`,
        method: "POST",
        body: queryArg.userRegister,
        params: { role: queryArg.role },
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
  }),
  overrideExisting: false,
});
export { injectedRtkApi as HCMSApi };
export type LoginsApiResponse = /** status 200 Success */ NotifyResponse;
export type LoginsApiArg = {
  userLogin: UserLogin;
};
export type RegisterUserApiResponse = unknown;
export type RegisterUserApiArg = {
  role?: string;
  userRegister: UserRegister;
};
export type VerificationCodeApiResponse = unknown;
export type VerificationCodeApiArg = {
  verificationCode: VerificationCode;
};
export type CreateBusinessUnitApiResponse = /** status 200 Success */ number;
export type CreateBusinessUnitApiArg = {
  createBusinessUnitCommand: CreateBusinessUnitCommand;
};
export type NotifyResponse = {
  status?: string | null;
  message?: string | null;
};
export type UserLogin = {
  userEmail?: string | null;
  password?: string | null;
};
export type UserRegister = {
  userName?: string | null;
  userEmail?: string | null;
  password?: string | null;
};
export type VerificationCode = {
  code?: string | null;
};
export type CreateBusinessUnitCommand = {
  businessUnitID?: string | null;
  businessUnitName?: string | null;
  parentId?: number;
};
export const {
  useLoginsMutation,
  useRegisterUserMutation,
  useVerificationCodeMutation,
  useCreateBusinessUnitMutation,
} = injectedRtkApi;
