import { Route, Routes } from 'react-router-dom';
import './App.css';
import Login from './views/Login';
import Profile from './views/Profile';
import Products from './views/Products';

function App() {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/profile" element={<Profile />} />
      <Route path="/products" element={<Products />} />
    </Routes>
  );
}

export default App;
