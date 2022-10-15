import { Typography } from 'antd';
import React from 'react';

import { Container } from './styles';

const Home: React.FC = () => {
  return (
    <Container>
      <Typography.Title level={1}>
        Jobsity Chat
      </Typography.Title>
    </Container>
  );
}

export default Home;