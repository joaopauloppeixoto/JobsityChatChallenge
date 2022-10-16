import { AxiosResponse } from "axios";

export interface Routes {
  auth: {
    post: (
      params: NewUserViewModel
    ) => Promise<AxiosResponse<UserViewModel, any>>;
  };
  chatroom: {
    get: () => Promise<AxiosResponse<Array<ChatroomViewModel>, any>>;
  };
  message: {
    get: (
      chatroomTitle: string
    ) => Promise<AxiosResponse<Array<MessageViewModel>, any>>;
    post: (
      message: NewMessageViewModel
    ) => Promise<AxiosResponse<void, any>>;
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

export interface MessageViewModel {
  content: string;
  sender: SenderViewModel;
  createdOn: string;
}

export interface SenderViewModel {
  nickname: string;
}

export interface NewMessageViewModel {
  content: string;
  chatroomTitle: string;
}