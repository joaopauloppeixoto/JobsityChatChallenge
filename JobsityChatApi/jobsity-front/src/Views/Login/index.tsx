import React, { useContext, useState } from "react";

import { useStateCached } from "../../utils";
import * as S from "./styles";
import { SecurityContext } from "../../hooks";
import { Button, Input, PageHeader } from "antd";

const Login: React.FC = () => {
  const [email, setEmail] = useStateCached<string>("user-login");
  const [password, setPassword] = useState<string | undefined>();
  const { login } = useContext(SecurityContext);

  const clearInputs = () => {
    setEmail("");
    setPassword("");
  };

  return (
    <S.Container>
      <PageHeader
        ghost
        // onBack={() => window.history.back()}
        title="Login"
      >
        <Input placeholder="Email"
          title=""
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <Input
          placeholder="Password"
          value={password}
          type="password"
          onChange={(e) => setPassword(e.target.value)}
        />
        <S.PageFooter>
          <Button type="link" href="#/Register">New account</Button>
          <Button type="primary" onClick={() => login(email!, password!)}>Login</Button>
        </S.PageFooter>
      </PageHeader>
    </S.Container>
  );
};

export default Login;
