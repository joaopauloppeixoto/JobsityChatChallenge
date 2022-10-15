import { AxiosResponse } from "axios";

export interface Routes {
  auth: {
    post: (
      params: NewUserViewModel
    ) => Promise<AxiosResponse<UserViewModel, any>>;
  };
  chatroom: {
    get: (
      params: never
    ) => Promise<AxiosResponse<Array<ChatroomViewModel>, any>>;
  };
}

export interface ChatroomViewModel {
  title: string;
}

export interface UserViewModel {
  email: string;
  nickname: string;
  token: string;
}

export interface AuthViewModel {
  email: string;
  password: string;
}

export interface NewUserViewModel extends AuthViewModel {
  userName: string;
}