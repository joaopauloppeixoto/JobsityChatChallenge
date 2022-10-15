import { createContext } from "react";
import { UserLogged } from "./provider";

export interface ISecurityContext {
  login: (user: string, password: string) => void;
  logout: () => void;
  isLogged: () => boolean;
  userLogged: UserLogged | undefined;
}

export default createContext<ISecurityContext>({} as ISecurityContext);
