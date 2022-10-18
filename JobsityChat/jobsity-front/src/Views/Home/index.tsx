import { Input, PageHeader, Select, Typography } from 'antd';
import React, { useContext, useEffect, useState } from 'react';
import { SecurityContext, ServicesContext } from '../../hooks';
import { ChatroomViewModel, MessageViewModel } from '../../hooks/services/ChatClient/types';
import { useStateCached } from '../../utils';

import { Container, Message, Messages } from './styles';

const { Option, OptGroup } = Select;

const Home: React.FC = () => {
  const { userLogged } = useContext(SecurityContext);
  const { routes, globalAlertError, isLoading } = useContext(ServicesContext);
  const [message, setMessage] = useState<string>("");
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

  const sendMessage = () => {
    setMessage("");
    if (selectedChatroom && message) {
      routes.message.post({
        chatroomTitle: selectedChatroom,
        content: message
      });
    }
  }

  useEffect(() => {
    let interval: NodeJS.Timer;
    setMessages([]);
    interval = setInterval(() => {
      if (selectedChatroom) {
        getMessages();
      }
    }, 1000);

    return () => {
      clearTimeout(interval);
    }
  }, [selectedChatroom]);

  useEffect(() => {
    getChatrooms();
  }, []);

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
        <Messages>
          {messages && messages.map((m, index) => {
            return (
              <Message key={index}>
                {`${m.sender.nickname} says: ${m.content}`}
              </Message>
            );
          })}
        </Messages>
        <form
          onSubmit={(e) => {
            e.preventDefault();
            if (message) {
              sendMessage();
            }
          }}
        >
          <Input
            placeholder="Write a message..."
            title=""
            value={message}
            onChange={(e) => setMessage(e.target.value)}
          />
        </form>
      </PageHeader>
    </Container>
  );
}

export default Home;