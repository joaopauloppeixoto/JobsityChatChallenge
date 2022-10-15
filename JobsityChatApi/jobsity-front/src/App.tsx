import Home from './Views/Home';
import { HashRouter as Router, Routes, Route } from "react-router-dom";
import SecurityProvider from './hooks/security/provider';
import ServicesProvider from './hooks/services/provider';
import { Login, Register } from './Views';

function App() {
  return (
    <ServicesProvider>
      <Router>
        <SecurityProvider>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/Register" element={<Register />} />
          </Routes>
        </SecurityProvider>
      </Router>
    </ServicesProvider>
  );
}

export default App;
