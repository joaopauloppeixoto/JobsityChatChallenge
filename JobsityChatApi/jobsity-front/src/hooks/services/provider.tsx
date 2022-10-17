import React, { useEffect, useState } from "react";

import ServicesContext from "./context";
import ChatClient from "./ChatClient";

import Swal from "sweetalert2";
import { useStateCached } from "../../utils";
import { UserLogged } from "../security/provider";
import { AxiosInstance } from "axios";
import { Container } from "./styles";
import { Button } from "antd";

const ServicesProvider: React.FC<{
  children?: React.ReactNode;
}> = ({ children }: any) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [userLogged] = useStateCached<UserLogged>("user-logged");
  const [chatApi, setChatApi] = useState<ChatClient>(
    new ChatClient(userLogged ? userLogged.Token : "")
  );

  const apiInterceptors = (instance: AxiosInstance) => {
    let requestNumber = instance.interceptors.request.use((req) => {
      setIsLoading(true);
      return req;
    });

    let responseNumber = instance.interceptors.response.use(
      (res) => {
        setIsLoading(false);
        return res;
      },
      (error) => {
        setIsLoading(false);
        if (error.response) {
          const code = error.response.status;
          const response = error.response.data;
          const originalRequest = error.config;

          if (code === 500) {
            globalAlertError(
              `Something get wrong!!`,
              () => { }
            );
          }

          if (code === 403) {
            globalAlertError(
              `${response.Title}`,
              () => { }
            );
          }

          if (code === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
          }

          return Promise.reject(error);
        }
      }
    );

    return () => {
      instance.interceptors.request.eject(requestNumber);
      instance.interceptors.response.eject(responseNumber);
    };
  };

  useEffect(() => {
    if (chatApi) return apiInterceptors(chatApi.instance);
  }, [chatApi]);

  const globalSuccess = (
    message: string,
    callback?: () => void
  ) => {
    Swal.fire({
      title: "Success!",
      html: message,
      icon: "success",
      showConfirmButton: false,
      position: "top-end",
      toast: true,
      willClose: () => {
        if (callback) callback();
      },
    });
  };

  const globalAlertError = (
    message: string,
    callback?: () => void
  ) => {
    Swal.fire({
      title: "Error!",
      html: message,
      icon: "error",
      showConfirmButton: false,
      background: "rgba(0,0,0,.9)",
      color: "#fff",
      position: "center",
      willClose: () => {
        if (callback) callback();
      },
    });
  };

  const setAuthToken = (token: string) => {
    setChatApi(new ChatClient(token));
  };

  return (
    <ServicesContext.Provider
      value={{
        routes: chatApi?.chatRoutes,
        isLoading,
        setAuthToken: setAuthToken,
        setIsLoading: setIsLoading,
        globalAlertError,
        globalSuccess,
      }}
    >
      <Container>
        {children}
      </Container>
    </ServicesContext.Provider>
  );
};

export default ServicesProvider;
