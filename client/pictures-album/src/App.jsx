import React, { useState } from 'react';
import PictureForm from './components/PictureForm';
import PictureList from './components/PictureList';

function App() {

  // State to trigger refresh of the picture list after a new picture is added
  const [refreshKey, setRefreshKey] = useState(0);

  // Callback function to increment the refresh key when a picture is added
  const handlePictureAdded = () => {
    setRefreshKey(prev => prev + 1);
  };

  return (
    <div className="container">

      {/* Page title */}
      <h1 className="page-title">Pictures Album</h1>

      {/* Component to display the list of uploaded pictures */}
      <PictureList refreshKey={refreshKey} />
      <hr />

      {/* Component containing the upload form; calls handlePictureAdded on success */}
      <PictureForm onPictureAdded={handlePictureAdded} />
    </div>
  );
}

export default App;


