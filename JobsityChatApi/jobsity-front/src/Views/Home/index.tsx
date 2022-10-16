import { PageHeader, Typography } from 'antd';
import React, { useContext, useEffect, useState } from 'react';
import { SecurityContext, ServicesContext } from '../../hooks';
import { ChatroomViewModel } from '../../hooks/services/ChatClient/types';

import { Container } from './styles';

const Home: React.FC = () => {
  const { userLogged } = useContext(SecurityContext);
  const { routes, globalAlertError } = useContext(ServicesContext);
  const [chatrooms, setChatrooms] = useState<Array<ChatroomViewModel>>([]);

  useEffect(() => {
    routes.chatroom.get()
      .then((result) => {
        setChatrooms(result.data);
      })
      .catch(() => {
        globalAlertError("Something get wrong!");
      })
  }, []);

  return (
    <Container>
      <PageHeader
        ghost
        onBack={() => window.history.back()}
        title="Jobsity Chat"
        subTitle={`Welcome ${userLogged?.User}, select a chatroom:`}
      >
        {chatrooms.map((c) => {
          return (<div>{c.title}</div>);
        })}
      </PageHeader>
    </Container>
  );
}

export default Home;