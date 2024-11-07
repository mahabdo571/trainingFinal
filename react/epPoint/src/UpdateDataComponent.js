import axios from 'axios';
import React, { useState, useEffect } from 'react';

const UpdateDataComponent = ({ productData, onSuccess, onError }) => {
  const [isLoading, setIsLoading] = useState(false);

  const updateData = async () => {
    setIsLoading(true);
    try {
      const response = await axios.put(`https://localhost:7186/api/Products/${productData.productID}`, productData);
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

  return (
    <div>
      {isLoading && <div>Loading...</div>}
    </div>
  );
};

export default UpdateDataComponent;
