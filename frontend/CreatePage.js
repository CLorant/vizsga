import axios from 'axios';
import React from 'react';
import { useNavigate } from 'react-router-dom';

export default function CreatePage() {
  const navigate = useNavigate();
  const createFlag = async(event) => {
    event.preventDefault();
    await axios
      .post(`https://localhost:5001/Product`, {
        Name: event.target.elements.Name.value,
        Price: event.target.elements.Price.value,
        Qty: event.target.elements.Qty.value,
        Flagimg: event.target.elements.Flagimg.value,
      })
      .then(() => navigate("/"))
      .catch(error => console.log(error.message));
  };

  return (
    <form className='mt-5 pt-5 p-5 content bg-whitesmoke fw-bold fs-5' onSubmit={createFlag}>
      <div className="form-group row pb-3">
        <label className="col-sm-3 col-form-label">Termék neve:</label>
        <div className="col-sm-9">
          <input type="text" name="Name" className="form-control" />
        </div>
      </div>
      <div className="form-group row pb-3">
        <label className="col-sm-3 col-form-label">Ár:</label>
        <div className="col-sm-9">
          <input type="number" name="Price" className="form-control" />
        </div>
      </div>
      <div className="form-group row pb-3">
        <label className="col-sm-3 col-form-label">Darab:</label>
        <div className="col-sm-9">
          <input type="number" name="Qty" className="form-control" />
        </div>
      </div>
      <div className="form-group row pb-3">
        <label className="col-sm-3 col-form-label">Kép URL-je:</label>
        <div className="col-sm-9">
          <input type="text" name="Flagimg" className="form-control" placeholder='../img/orszag.jpg'/>
        </div>
      </div>
      <div className='pt-5 text-center'>
        <button type="submit" className="btn btn-lg btn-success">
          Küldés
        </button>
      </div>
    </form>
  );
}