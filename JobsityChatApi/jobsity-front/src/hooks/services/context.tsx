import React, { Dispatch, SetStateAction } from "react";
import { Routes } from "./ChatClient/types";

export interface IServicesContext {
  routes: Routes;
  setAuthToken: (token: string) => void;
  isLoading: boolean;
  setIsLoading: Dispatch<SetStateAction<boolean>>;
  globalSuccess: (message: string) => void;
  globalAlertError: (message: string) => void;
}

export default React.createContext<IServicesContext>({} as IServicesContext);
