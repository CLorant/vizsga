import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min.js';

/*
src mappa tartalma
public mappába egy img mappát ha kéri a feladat

npx create-react-app NAME
npm i react-router-dom
npm i bootstrap
npm i axios
*/

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <App />
);

reportWebVitals();