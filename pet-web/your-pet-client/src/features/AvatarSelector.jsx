import React, { useState, useEffect } from 'react';
import { IconButton, Box } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import ArrowForwardIcon from '@mui/icons-material/ArrowForward';
import AvatarCat from './AvatarCat';
import AvatarDog from './AvatarDog';

const avatars = [
    { type: 'Cat', component: <AvatarCat /> },
    { type: 'Dog', component: <AvatarDog /> },
];

const AvatarSelector = ({ selectedAvatar, setSelectedAvatar }) => {
    const [currentIndex, setCurrentIndex] = useState(0);

    const handlePrevious = () => {
        setCurrentIndex((prevIndex) => (prevIndex === 0 ? avatars.length - 1 : prevIndex - 1));
    };

    const handleNext = () => {
        setCurrentIndex((prevIndex) => (prevIndex === avatars.length - 1 ? 0 : prevIndex + 1));
    };

    useEffect(() => {
        setSelectedAvatar(avatars[currentIndex].type);
    }, [currentIndex, setSelectedAvatar]);

    return (
        <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center', marginBottom: 2 }}>
            <IconButton onClick={handlePrevious}>
                <ArrowBackIcon />
            </IconButton>
            <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center', width: '200px', height: '200px' }}>
                {avatars[currentIndex].component}
            </Box>
            <IconButton onClick={handleNext}>
                <ArrowForwardIcon />
            </IconButton>
        </Box>
    );
};

export default AvatarSelector;
