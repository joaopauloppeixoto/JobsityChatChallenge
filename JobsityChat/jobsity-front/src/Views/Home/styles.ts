import styled from 'styled-components';

export const Container = styled.div`
  padding: 10px;
`;

export const Messages = styled.div`
  height: calc(100vh - 140px);
  overflow-x: hidden;
  overflow-y: auto;
  padding: 10px 0;
`;

export const Message = styled.div`
  text-overflow: ellipsis;
  word-wrap: break-word;
  max-width: 600px;
`;
