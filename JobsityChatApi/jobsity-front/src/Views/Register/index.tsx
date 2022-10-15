import React, { useContext, useState } from "react";

import * as S from "./styles";
import { ServicesContext } from "../../hooks";
import { Button, Input, PageHeader } from "antd";
import axios from "axios";

const Register: React.FC = () => {
  const [email, setEmail] = useState<string>("");
  const [nickname, setNickname] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [repeatPassword, setRepeatPassword] = useState<string>("");
  const { globalAlertError, routes } = useContext(ServicesContext);

  const register = () => {
    if (!email) {
      globalAlertError("Email can't be empty.");
      return;
    }
    if (!nickname) {
      globalAlertError("Nickname can't be empty.");
      return;
    }
    if (!password && !repeatPassword) {
      globalAlertError("Password can't be empty.");
      return;
    }
    if (password !== repeatPassword) {
      globalAlertError("The passwords are not equal.");
      return;
    }
    routes.auth.post({
      email: email,
      password: password,
      userName: nickname,
    }).then(() => {
      alert("User registered successfully!");
    }).catch(() => {
      globalAlertError("Something get wrong.");
    })

  }

  return (
    <S.Container>
      <PageHeader
        ghost
        onBack={() => window.history.back()}
        title="Register"
      >
        <Input placeholder="Email"
          title=""
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <Input placeholder="Nickname"
          title=""
          value={nickname}
          onChange={(e) => setNickname(e.target.value)}
        />
        <Input
          placeholder="Password"
          value={password}
          type="password"
          onChange={(e) => setPassword(e.target.value)}
        />
        <Input
          placeholder="Repeat Password"
          value={repeatPassword}
          type="password"
          onChange={(e) => setRepeatPassword(e.target.value)}
        />
        <S.PageFooter>
          <Button type="link" href="#/Login">Login</Button>
          <Button type="primary" onClick={register}>Submit</Button>
        </S.PageFooter>
      </PageHeader>
    </S.Container>
  );
};

export default Register;
