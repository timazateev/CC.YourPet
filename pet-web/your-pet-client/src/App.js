import React from 'react';
import { Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage'; // Убедитесь, что путь к файлу верный
import PetInfoPage from './pages/PetInfoPage';

function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/pet-info" element={<PetInfoPage />} />
    </Routes>
  );
}

export default App;
