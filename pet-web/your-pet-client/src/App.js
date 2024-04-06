// В файле App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import HomePage from './pages/HomePage'; // Убедитесь, что путь к файлу верный
import PetInfoPage from './pages/PetInfoPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/pet-info" element={<PetInfoPage />} />
      </Routes>
    </Router>
  );
}

export default App;