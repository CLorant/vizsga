import axios from 'axios';
import React, { useState, useEffect, useCallback } from 'react';
import { NavLink, useParams } from 'react-router-dom';

export default function SinglePage() {
  const [flag, setFlag] = useState([]);
  const [fetchPending, setFetchPending] = useState();
  const params = useParams();
  
  const getFlag = useCallback(async () => {
    await axios
      .get(`https://localhost:5001/Product/${params.id}`)
      .then(response => setFlag(response.data))
      .catch(error => console.log(error.message))
      .finally(() => setFetchPending(false));
  }, [params.id]);

  useEffect(() => {
    getFlag();
  }, [getFlag]);

  return (
    <div>
      {fetchPending || flag.id ? (
        <div className='spinner-border text-success' />
      ) : (
        <div className='mt-5 pt-5 text-secondary text-center'>
          <div className='card d-inline-block m-1 p-2' key={flag.Id}>
            <b className='fs-2'>{flag.Name}</b>
            <div className='card-body'>
              <img src={flag.Flagimg} alt={flag.Name} height="440" width="960" className='img-fluid pb-3' style={{ objectFit: 'cover' }} />
              <div className='d-flex justify-content-around bg-success text-light rounded pt-3 fs-5'>
                <p><b>{flag.Price}</b> Ft</p>
                <p><b>{flag.Qty}</b> db</p>
              </div>
            </div>
          </div>
          <NavLink to="/" role='button' className='btn btn-lg btn-secondary mt-2'>Vissza</NavLink>
        </div>
      )}
    </div>
  );
}