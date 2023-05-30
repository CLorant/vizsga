import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';

export function ListPage() {
  const[flags, setFlag] = useState([]);
  const[fetchPending, setFetchPending] = useState(true);
  
  const getFlagList = async() => {
    await axios
      .get("https://localhost:5001/Product")
      .then(response => setFlag(response.data))
      .catch(error => console.log(error.message))
      .finally(() => setFetchPending(false));
  };

  useEffect(() => {
    getFlagList();
  }, []);

  return (
    <div className='mt-5 pt-5 text-center text-secondary'>
      { fetchPending ? (
        <div className='spinner-border text-success' />
      ) : (
        <div>
          <h2 className='mb-5 fs-1 fw-bold'>Zászlók</h2>
          {flags.map(z => (
            <div className='card col-lg-3 d-inline-block m-1 pt-2' key={z.Id}>
              <b className='fs-5'>{ z.Name }</b>
              <div className='card-body'>
                <NavLink to={`/flag/${z.Id}`}>
                  <img src={z.Flagimg} alt={z.Name} height="220" width="480" className='img-fluid pb-3'/>
                </NavLink>
              </div>
              <div className='d-flex justify-content-around bg-success text-light rounded pt-3'>
                <p><b>{ z.Price }</b> Ft</p>
                <p><b>{ z.Qty }</b> db</p>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}