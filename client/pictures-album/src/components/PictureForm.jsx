import React, { useState } from 'react';
import { addPicture } from '../services/api';

export default function PictureForm({ onPictureAdded }) {
    const [form, setForm] = useState({
        name: '',
        description: '',
        date: '',
        file: null
    });

    const [fileName, setFileName] = useState('');
    const [error, setError] = useState('');
    const [showConfirm, setShowConfirm] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    const handleChange = (e) => {
        setForm(prev => ({ ...prev, [e.target.name]: e.target.value }));
    };

    const handleFileChange = (e) => {
        const file = e.target.files[0];
        if (!file) return;

        if (!file.type.startsWith('image/')) {
            setError('Invalid file – only image files are allowed');
            setForm(prev => ({ ...prev, file: null }));
            setFileName('');
            return;
        }

        setForm(prev => ({ ...prev, file }));
        setFileName(file.name);
        setError('');
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        setError('');

        if (!form.name || !form.file) {
            if (!form.name) setError('Picture name is required');
            else setError('Image file is required');
            setIsLoading(false);
            return;
        }


        const formData = new FormData();
        formData.append('name', form.name);
        formData.append('description', form.description);
        formData.append('date', form.date);
        formData.append('file', form.file);

        try {
            await addPicture(formData);
            onPictureAdded();
            setForm({ name: '', description: '', date: '', file: null });
            setFileName('');
        } catch (err) {
            const message = err.response?.data;
            setError(typeof message === 'string' ? message : 'Upload failed');
        } finally {
            setIsLoading(false);
        }

    };

    const handleResetConfirm = () => {
        setForm({ name: '', description: '', date: '', file: null });
        setFileName('');
        setError('');
        setShowConfirm(false); // ⭐ close model
    };

    return (
        <>
            <form className="form-container" onSubmit={handleSubmit}>
                <h2>Add New Picture</h2>

                <div>
                    <label>Picture Name* (max 50 chars): </label>
                    <input name="name" maxLength="50" value={form.name} onChange={handleChange} />
                </div>

                <div>
                    <label>Date: </label>
                    <input name="date" type="datetime-local" value={form.date} onChange={handleChange} />
                </div>

                <div>
                    <label>Description (max 250 chars): </label>
                    <textarea name="description" maxLength="250" value={form.description} onChange={handleChange} />
                </div>

                <div className="file-upload">
                    <label htmlFor="fileInput" className="custom-file-button">
                        Picture Browser
                    </label>
                    <input
                        id="fileInput"
                        type="file"
                        accept="image/*"
                        onChange={handleFileChange}
                        style={{ display: 'none' }}
                    />
                    <span className="file-name">{fileName}</span>
                </div>

                {error && <p className="error">{error}</p>}

                <button type="submit" disabled={isLoading}>
                    {isLoading ? 'Uploading...' : 'Add Picture'}
                </button>
                <button type="button" onClick={() => setShowConfirm(true)}>Reset</button>
            </form>

            {/* ⭐ model */}
            {showConfirm && (
                <div className="modal-overlay">
                    <div className="modal">
                        <p>?Are you sure you want to reset the form</p>
                        <div className="modal-buttons">
                            <button onClick={() => setShowConfirm(false)}>Cancel</button>
                            <button onClick={handleResetConfirm}>Yes</button>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
}
