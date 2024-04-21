import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Typography, Button, Box } from '@mui/material';
import PawIcon from '../assets/paw-icon.svg'; // Путь к вашему SVG файлу

const HomePage = () => {
    return (
        <Box
            sx={{
                height: '100vh',
                backgroundImage: 'url("/pictures/welcome.webp")',
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
            }}
        >
            <Container maxWidth="lg">
                <Box
                    textAlign="center"
                    bgcolor="rgba(255, 255, 255, 0.8)"
                    p={4}
                    borderRadius={3}
                    sx={{
                        boxShadow: '0 3px 5px rgba(0, 0, 0, 0.2)', // Добавляем тень для лучшей видимости
                    }}
                >
                    <Typography
                        variant="h4"
                        gutterBottom
                        sx={{
                            fontFamily: "'Roboto', sans-serif",
                            fontWeight: 'bold',
                            color: '#34495e', // Тёмно-синий цвет текста
                            padding: '20px',
                            backgroundColor: 'rgba(255, 255, 255, 0.7)', // Слегка прозрачный фон для текста
                            borderRadius: '10px', // Скругление углов текстового блока
                        }}
                    >
                        Welcome to the Your Pet
                    </Typography>
                    <Button
                        variant="contained"
                        component={Link}
                        to="/pet-info"
                        sx={{
                            borderRadius: '50%', // Круглая форма кнопки
                            minWidth: '80px', // Минимальная ширина для круглой формы
                            minHeight: '80px', // Минимальная высота для круглой формы
                            backgroundColor: 'pink', // Розовый цвет кнопки
                            '&:hover': {
                                backgroundColor: 'lightpink', // Цвет при наведении
                            },
                            backgroundImage: `url(${PawIcon})`, // Иконка лапы
                            backgroundRepeat: 'no-repeat',
                            backgroundPosition: 'center',
                            backgroundSize: '50%', // Размер иконки лапы
                        }}
                    />
                </Box>
            </Container>
        </Box>
    );
};

export default HomePage;