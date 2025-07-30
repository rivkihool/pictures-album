import React, { useState } from 'react';
import PictureForm from './components/PictureForm';
import PictureList from './components/PictureList';

function App() {
  const [refreshKey, setRefreshKey] = useState(0);

  const handlePictureAdded = () => {
    setRefreshKey(prev => prev + 1);
  };

  return (
    <div className="container">
      <h1 className="page-title">Pictures Album</h1>
      <PictureList refreshKey={refreshKey} />
      <hr />
      <PictureForm onPictureAdded={handlePictureAdded} />
    </div>
  );
}

export default App;


