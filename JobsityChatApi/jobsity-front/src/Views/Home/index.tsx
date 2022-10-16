import { PageHeader, Select, Typography } from 'antd';
import React, { useContext, useEffect, useState } from 'react';
import { SecurityContext, ServicesContext } from '../../hooks';
import { ChatroomViewModel, MessageViewModel } from '../../hooks/services/ChatClient/types';
import { useStateCached } from '../../utils';

import { Container } from './styles';

const { Option, OptGroup } = Select;

const Home: React.FC = () => {
  const { userLogged } = useContext(SecurityContext);
  const { routes, globalAlertError } = useContext(ServicesContext);
  const [messages, setMessages] = useState<Array<MessageViewModel>>([]);
  const [chatrooms, setChatrooms] = useState<Array<ChatroomViewModel>>([]);
  const [selectedChatroom, setSelectedChatroom] = useStateCached<string>("SelectedChatroom");

  const getChatrooms = () => {
    routes.chatroom.get()
      .then((result) => {
        setChatrooms(result.data);
      })
      .catch(() => {
        globalAlertError("Something get wrong!");
      });
  }

  const getMessages = () => {
    if (selectedChatroom) {
      routes.message.get(selectedChatroom)
        .then((result) => {
          setMessages(result?.data);
        })
        .catch(() => {
          globalAlertError("Something get wrong!");
        });
    }
  }

  useEffect(() => {
    if (!chatrooms.length){
      getChatrooms();
    }
  }, []);
  
  useEffect(() => {
    if (selectedChatroom){
      getMessages();
    }
  }, [selectedChatroom]);

  return (
    <Container>
      <PageHeader
        ghost
        onBack={() => window.history.back()}
        title="Jobsity Chat"
        subTitle={`Welcome ${userLogged?.User}, select a chatroom:`}
        extra={chatrooms.length > 0 &&
          <Select
            defaultValue={selectedChatroom ? selectedChatroom : chatrooms[0].title}
            style={{ width: 200 }}
            onChange={setSelectedChatroom}
          >
            {chatrooms.map((c, index) => {
              return (<Option key={index} value={c.title}>{c.title}</Option>);
            })}
          </Select>
        }
      >
        {messages && messages.map((m, index) => {
          return <div>{`${m.sender.nickname} says: ${m.content}`}</div>
        })}
      </PageHeader>
    </Container>
  );
}

export default Home;