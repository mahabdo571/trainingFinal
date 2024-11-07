import React from "react";
import { Grid } from "@mui/material";
import { useState, useEffect } from 'react';
function ProductList() {
  const [inputValue, setInputValue] = useState('');
  const [items, setItems] = useState([]);
  const [currentItem, setCurrentItem] = useState(null);

  useEffect(() => {
    // استرجاع البيانات من localStorage عند تحميل الصفحة
    const savedItems = JSON.parse(localStorage.getItem('items')) || [];
    setItems(savedItems);

    // استرجاع العنصر المختار من sessionStorage عند تحميل الصفحة
    const savedCurrentItem = sessionStorage.getItem('currentItem');
    if (savedCurrentItem) {
      setCurrentItem(savedCurrentItem);
    }
  }, []);

  useEffect(() => {
    // حفظ البيانات في localStorage عند تحديث القائمة
    localStorage.setItem('items', JSON.stringify(items));
  }, [items]);

  useEffect(() => {
    // حفظ العنصر المختار في sessionStorage عند تحديثه
    if (currentItem) {
      sessionStorage.setItem('currentItem', currentItem);
    } else {
      sessionStorage.removeItem('currentItem');
    }
  }, [currentItem]);

  const handleAdd = () => {
    if (inputValue.trim() !== '') {
      setItems([...items, inputValue.trim()]);
      setInputValue('');
    }
  };

  const handleDelete = (e, itemToDelete) => {
    e.stopPropagation(); // منع تفعيل حدث الاختيار عند النقر على زر الحذف
    const updatedItems = items.filter(item => item !== itemToDelete);
    setItems(updatedItems);
    if (currentItem === itemToDelete) {
      setCurrentItem(null);
      sessionStorage.removeItem('currentItem'); // إزالة العنصر المختار من sessionStorage
    }
  };

  const handleSelect = (item) => {
    setCurrentItem(item);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>إدارة النصوص</h1>
      <input
        type="text"
        value={inputValue}
        onChange={(e) => setInputValue(e.target.value)}
      />
      <button onClick={handleAdd}>إضافة</button>
      <ul>
        {items.map((item, index) => (
          <li key={index} onClick={() => handleSelect(item)}>
            {item}
            <button onClick={(e) => handleDelete(e, item)} style={{ marginLeft: '10px' }}>
              حذف
            </button>
          </li>
        ))}
      </ul>
      {currentItem && (
        <div>
          <h2>العنصر المختار الحالي:</h2>
          <p>{currentItem}</p>
        </div>
      )}
    </div>
  );
};

export default ProductList;



