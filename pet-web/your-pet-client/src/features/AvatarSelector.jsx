import React, { useState, useEffect } from 'react';
import { IconButton, Box } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import ArrowForwardIcon from '@mui/icons-material/ArrowForward';
import AvatarCat from './AvatarCat';
import AvatarDog from './AvatarDog';
import AvatarDog2 from './AvatarDog2';
import AvatarDog3 from './AvatarDog3';

const avatars = [
    { component: <AvatarCat />, path: '/pictures/avatars/catAvatar.png' },
    { component: <AvatarDog />, path: '/pictures/avatars/dogAvatar.png' },
    { component: <AvatarDog2 />, path: '/pictures/avatars/dogAvatar2.png' },
    { component: <AvatarDog3 />, path: '/pictures/avatars/dogAvatar3.png' },
];

const AvatarSelector = ({ selectedAvatar, setSelectedAvatar, avatarKey }) => {
    const [currentIndex, setCurrentIndex] = useState(null); // Инициализируем как null

    // Инициализация индекса при изменении avatarKey
    useEffect(() => {
        const initialIndex = avatars.findIndex(avatar => avatar.path === avatarKey);
        if (initialIndex !== -1) {
            setCurrentIndex(initialIndex); // Устанавливаем индекс для avatarKey
            setSelectedAvatar(avatarKey);  // Устанавливаем avatarKey
        } else {
            setCurrentIndex(0); // Если avatarKey пустой, сбрасываем индекс
            setSelectedAvatar(avatars[0].path); // По умолчанию выбираем первый аватар
        }
    }, [avatarKey, setSelectedAvatar]);

    const handlePrevious = () => {
        setCurrentIndex((prevIndex) => (prevIndex === 0 ? avatars.length - 1 : prevIndex - 1));
    };

    const handleNext = () => {
        setCurrentIndex((prevIndex) => (prevIndex === avatars.length - 1 ? 0 : prevIndex + 1));
    };

    // Обновление selectedAvatar при изменении currentIndex
    useEffect(() => {
        if (currentIndex !== null) {
            setSelectedAvatar(avatars[currentIndex].path);
        }
    }, [currentIndex, setSelectedAvatar]);

    // Проверка на null, чтобы не рендерить, пока currentIndex не определён
    if (currentIndex === null) {
        return null; // Либо можно вернуть спиннер или заглушку
    }

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
