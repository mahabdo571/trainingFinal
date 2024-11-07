import axios from "axios";
import React, { useState, useEffect } from "react";
import moment from 'moment';

const AddDataCompo = ({ productData, onSuccess, onError }) => {
  const [isLoading, setIsLoading] = useState(false);

  const updateData = async () => {
    setIsLoading(true);
    try {
 
      
      const response = await axios.post(`https://localhost:7186/api/Products`,{...productData,
        lastUpdated:moment().format('YYYY-MM-DDTHH:mm:ss[Z]'),
        dateCreated:moment().format('YYYY-MM-DDTHH:mm:ss[Z]')});
      setIsLoading(false);
  
      onSuccess(response.data);
    } catch (error) {
      setIsLoading(false);
      onError(error);
    }
  };

  useEffect(() => {
    if (productData) {
      updateData();
    }
  }, [productData]);

  return <div>{isLoading && <div>Loading...</div>}</div>;
};

export default AddDataCompo;
