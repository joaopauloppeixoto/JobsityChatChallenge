import { AxiosResponse } from "axios";

export interface Routes {
  chatroom: {
    get: (
      params: never
    ) => Promise<AxiosResponse<Array<ChatroomViewModel>, any>>;
    };
}

export interface ChatroomViewModel {
  title: string;
}
