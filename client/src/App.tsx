import React from 'react';
import './App.css';

import { ToastContainer } from 'react-toastify';

import Dashboard from './components/Dashboard';

function App() {
  return (
      <div className='App'>
          <Dashboard />
          <ToastContainer />
      </div>
  );
}

export default App;
