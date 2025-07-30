import React, { useEffect, useState } from 'react';
import { getPictures } from '../services/api';

export default function PictureList({ refreshKey }) {
    const [pictures, setPictures] = useState([]);

    useEffect(() => {
        getPictures().then(res => setPictures(res.data));
    }, [refreshKey]);

    return (
        <div className="picture-list">
            <h2>Uploaded Pictures</h2>
            {pictures.length === 0 ? (
                <p>No pictures found.</p>
            ) : (
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Picture Name</th>
                        </tr>
                    </thead>
                    <tbody>
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
