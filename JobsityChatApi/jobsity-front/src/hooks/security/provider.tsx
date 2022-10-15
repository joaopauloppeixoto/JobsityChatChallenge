import React, { useContext, useEffect } from "react";
import SecurityContext from "./context";

import { useStateCached } from "../../utils";
import axios from "axios";
import { Login } from "../../Views";
import ServicesContext from "../services/context";
import { API_CHAT } from "../../config";
import { Navigate } from "react-router-dom";

export interface UserLogged {
  User: string;
  Token: string;
}

const SecurityProvider: React.FC<{
  children?: React.ReactNode;
}> = ({ children }) => {
  const [userLogged, setUserLogged, clearUserLogged] =
    useStateCached<UserLogged>("user-logged");
  const { setAuthToken, setIsLoading, globalAlertError } =
    useContext(ServicesContext);

  const isLogged = () => {
    if (userLogged) {
      return true;
    }
    return false;
  };

  const login = (user: string, password: string) => {
    const data = {
      email: user,
      password: password,
    };

    if (!user || !password) {
      globalAlertError(
        "Email and password can't be null."
      );
      return;
    }

    axios
      .post<{
        token: string;
        email: string;
        nickname: string;
      }>(`${API_CHAT}/Auth/login`, JSON.stringify(data))
      .then((result) => {
        setUserLogged({
          Token: result.data.token,
          User: result.data.nickname,
        });
        setAuthToken(result.data.token);
        alert("Successful login.");
      })
      .catch((error) =>
        globalAlertError(
          "Invalid Email or Password."
        )
      )
      .finally(() => setIsLoading(false));
  };

  const logout = () => {
    clearUserLogged();
  };

  useEffect(() => {
    if (!isLogged()) clearUserLogged();
  }, []);

  return (
    <SecurityContext.Provider
      value={{
        login,
        logout,
        isLogged,
        userLogged,
      }}
    >
      {(!userLogged && window.location.hash !== "#/Login" && window.location.hash !== "#/Register") ? <Navigate to={"/Login"} /> : children}
    </SecurityContext.Provider>
  );
};

export default SecurityProvider;
