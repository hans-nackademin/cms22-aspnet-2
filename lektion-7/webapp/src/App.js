import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './views/Login';
import Home from './views/Home';

function App() {
  // let token = localStorage.getItem('accessToken')
  // if (token == null)
  //   window.location.replace('/login')


  return (
    <div className="bg-body-tertiary">
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
