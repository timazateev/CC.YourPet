import React, { useEffect } from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import { Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import PetInfoPage from './pages/PetInfoPage';
import { usePetService } from './services/PetService';

const ProtectedRoute = ({ component: Component }) => {
  const { isAuthenticated, loginWithRedirect, isLoading } = useAuth0();

  useEffect(() => {
    if (!isLoading && !isAuthenticated) {
      loginWithRedirect();
    }
  }, [isAuthenticated, isLoading, loginWithRedirect]);

  return isAuthenticated ? <Component /> : null;
};

function App() {
  const { isAuthenticated } = useAuth0();
  const { registerUser } = usePetService();

  useEffect(() => {
    if (isAuthenticated && registerUser) {
      registerUser()
        .then(() => console.log('User registered in API'))
        .catch(err => console.error('Error during registration in API: ', err));
    }
  }, [isAuthenticated, registerUser]);

  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/pet-info" element={<ProtectedRoute component={PetInfoPage} />} />
    </Routes>
  );
}

export default App;
