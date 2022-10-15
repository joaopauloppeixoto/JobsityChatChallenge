import { PageHeader, Typography } from 'antd';
import React, { useContext } from 'react';
import { SecurityContext } from '../../hooks';

import { Container } from './styles';

const Home: React.FC = () => {
  const { userLogged } = useContext(SecurityContext);
  
  return (
    <Container>
      <PageHeader
        ghost
        onBack={() => window.history.back()}
        title="Jobsity Chat"
        subTitle={`Welcome ${userLogged?.User}, select a chatroom:`}
      >
        
      </PageHeader>
    </Container>
  );
}

export default Home;