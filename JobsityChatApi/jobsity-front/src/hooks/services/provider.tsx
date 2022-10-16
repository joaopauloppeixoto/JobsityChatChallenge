import React, { useEffect, useState } from "react";

import ServicesContext from "./context";
import ChatClient from "./ChatClient";

import Swal from "sweetalert2";
import { useStateCached } from "../../utils";
import { UserLogged } from "../security/provider";
import { AxiosInstance } from "axios";
import { Container } from "./styles";

const ServicesProvider: React.FC<{
  children?: React.ReactNode;
}> = ({ children }: any) => {
  const [isOffline, setOffline] = useState<boolean>(!window.navigator.onLine);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [userLogged] = useStateCached<UserLogged>("user-logged");
  const [conferenceApi, setConferenceApi] = useState<ChatClient>(
    new ChatClient(userLogged ? userLogged.Token : "")
  );
  const [notificationListActive, setNotificationListActive] =
    useState<boolean>(false);
  const [date, setDate] = useState<Date | null>(null);
  const [statusLegend, setStatusLegend] = useState<string>("");

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
        if (!error.response) {
          // globalAlertError(
          //   "Verifique a sua conexão com a internet antes de realizar essa ação."
          // );
        } else {
          const code = error.response.status;
          const response = error.response.data;
          const originalRequest = error.config;

          if (code === 500) {
            globalAlertError(
              `Um erro não tratado ocorreu no servidor, por favor entre em contato com o desenvolvimento.`,
              () => { },
              `${response.Title}`
            );
          }

          if (code === 403) {
            globalAlertError(
              `${response.Title}`,
              () => { },
              `${response.Detail}`
            );
          }

          if (code === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
          }

          if (code === 400) {
            globalAlertError(
              "Verifique se os valores inseridos estão corretos.",
              () => { },
              "400 Bad request. Algum valor enviado para o servidor não está de acordo com o que o servidor espera."
            );
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
    if (conferenceApi) return apiInterceptors(conferenceApi.instance);
  }, [conferenceApi]);

  const globalAlertError = (
    message: string,
    callback?: () => void,
    moreInfo?: string
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

  useEffect(() => {
    window.addEventListener("online", () => {
      setOffline(false);
    });

    window.addEventListener("offline", () => {
      setOffline(true);
    });
  }, []);

  const setAuthToken = (token: string) => {
    setConferenceApi(new ChatClient(token));
  };

  return (
    <ServicesContext.Provider
      value={{
        routes: conferenceApi?.chatRoutes,
        isLoading,
        setAuthToken: setAuthToken,
        setIsLoading: setIsLoading,
        globalAlertError,
      }}
    >
      <Container>
        {children}
      </Container>
    </ServicesContext.Provider>
  );
};

export default ServicesProvider;
