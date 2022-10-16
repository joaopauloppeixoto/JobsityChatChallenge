import axios, { AxiosInstance, AxiosResponse } from "axios";
import { API_CHAT } from "../../../config";
import { Get, Put, Post, Delete } from "./genericRoutes";
import * as T from "./types";

class ConferenceApi {
  public instance: AxiosInstance;
  public chatRoutes: T.Routes;

  constructor(token: string) {
    this.instance = axios.create({
      baseURL: API_CHAT,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    this.chatRoutes = {
      auth: {
        post: new Post<T.NewUserViewModel, never>(
          "auth",
          this.instance
        ).post,
      },
      chatroom: {
        get: new Get<void, Array<T.ChatroomViewModel>>(
          "chatroom",
          this.instance
        ).get,
      },
    };
  }
}

export default ConferenceApi;
