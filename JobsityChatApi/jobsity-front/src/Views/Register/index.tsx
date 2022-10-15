import React, { useContext, useState } from "react";

import * as S from "./styles";
import { SecurityContext } from "../../hooks";
import { Button, Input, PageHeader } from "antd";

const Register: React.FC = () => {
  const [email, setEmail] = useState<string>("");
  const [nickname, setNickname] = useState<string>("");
  const [password, setPassword] = useState<string | undefined>("");
  const [repeatPassword, setRepeatPassword] = useState<string | undefined>("");
  const { login } = useContext(SecurityContext);

  const clearInputs = () => {
    setEmail("");
    setPassword("");
  };

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
          <Button type="primary">Submit</Button>
        </S.PageFooter>
      </PageHeader>
    </S.Container>
  );
};

export default Register;
