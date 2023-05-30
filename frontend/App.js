import { BrowserRouter, Routes, Route, NavLink } from 'react-router-dom';
import { ListPage } from './ListPage';
import { SinglePage } from './SinglePage';
import { CreatePage } from './CreatePage';

export function App() {
  return (
    <BrowserRouter>
      <nav className='navbar navbar-expand-sm navbar-dark bg-dark fixed-top'>
        <div className='container-fluid'>
          <button className='navbar-toggler' data-bs-toggle="collapse"
            data-bs-target=".navbar-collapse">
            <span className='navbar-toggler-icon'></span>
          </button>
          <div className="collapse navbar-collapse">
            <ul className="navbar-nav fw-bold">
              <li className="nav-item">
                <NavLink to={'/'} className="nav-link">Zászlók</NavLink>
              </li>
              <li className="nav-item">
                <NavLink to={'/new-flag'} className="nav-link">Új zászló</NavLink>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <Routes>
        <Route path='/' element={<ListPage />} />
        <Route path='/flag/:id' element={<SinglePage />} />
        <Route path='/new-flag' element={<CreatePage />} />
      </Routes>
    </BrowserRouter>
  );
}