import React, { useEffect, useState } from 'react';
import { getPictures } from '../services/api';

// Component to display the list of uploaded pictures
export default function PictureList({ refreshKey }) {

    // State to store pictures retrieved from the backend
    const [pictures, setPictures] = useState([]);

    // useEffect hook to fetch pictures from the API whenever 'refreshKey' changes
    useEffect(() => {
        getPictures().then(res => setPictures(res.data));
    }, [refreshKey]);

    return (
        <div className="picture-list">
            <h2>Uploaded Pictures</h2>

            {/* Display message if no pictures are found */}
            {pictures.length === 0 ? (
                <p>No pictures found.</p>
            ) : (
                // Render table of pictures
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Picture Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* Map through the pictures array and display each one */}
                        {pictures.map((pic) => (
                            <tr key={pic.id}>
                                <td>{pic.id}</td>
                                <td>{pic.name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}
