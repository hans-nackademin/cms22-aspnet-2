import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import { ProfileProvider } from './contexts/ProfileContext';
import { ProductProvider } from './contexts/ProductContext';
import { CartProvider } from './contexts/CartContext';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  // <React.StrictMode>
    
  <ProductProvider>
  <CartProvider>
  <ProfileProvider>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </ProfileProvider>
  </CartProvider>
  </ProductProvider>
  // </React.StrictMode>
);