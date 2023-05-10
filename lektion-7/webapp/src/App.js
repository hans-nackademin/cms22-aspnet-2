import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './views/Login';
import Home from './views/Home';
import Products from './views/Products';
import { ShoppingCartProvider } from './contexts/ShoppingCartContext';
import ShoppingCart from './views/ShoppingCart';

function App() {
  // let token = localStorage.getItem('accessToken')
  // if (token == null)
  //   window.location.replace('/login')


  return (
    <div className="bg-body-tertiary">
      <ShoppingCartProvider>
        <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/products" element={<Products />} />
          <Route path="/cart" element={<ShoppingCart />} />
        </Routes>
        </BrowserRouter>
      </ShoppingCartProvider>
    </div>
  );
}

export default App;
