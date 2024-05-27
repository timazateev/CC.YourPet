import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Typography, Button, Box } from '@mui/material';
import PawIcon from '../assets/paw-icon.svg';
import { useTranslation } from 'react-i18next';
import LanguageSwitcher from '../tools/LanguageSwitcher';
import AuthenticationButton from '../auth/AuthenticationButton';

const HomePage = () => {
    const { t } = useTranslation();

    return (
        <Box
            sx={{
                height: '100vh',
                backgroundImage: 'url("/pictures/welcome.webp")',
                backgroundSize: 'cover',
                backgroundPosition: 'center bottom',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
            }}
        >
            <LanguageSwitcher />
            <Container maxWidth="lg">
                <Box
                    textAlign="center"
                    bgcolor="rgba(255, 255, 255, 0.8)"
                    p={4}
                    borderRadius={3}
                    sx={{
                        boxShadow: '0 3px 5px rgba(0, 0, 0, 0.2)',
                    }}
                >
                    <Typography
                        variant="h4"
                        gutterBottom
                        sx={{
                            fontFamily: "'Roboto', sans-serif",
                            fontWeight: 'bold',
                            color: '#34495e',
                            padding: '20px',
                            backgroundColor: 'rgba(255, 255, 255, 0.7)',
                            borderRadius: '10px',
                        }}
                    >
                        {t('welcome')}
                    </Typography>
                    <AuthenticationButton />
                    <Button
                        variant="contained"
                        component={Link}
                        to="/pet-info"
                        sx={{
                            borderRadius: '50%',
                            minWidth: '80px',
                            minHeight: '80px',
                            backgroundColor: 'pink',
                            '&:hover': {
                                backgroundColor: 'lightpink',
                            },
                            backgroundImage: `url(${PawIcon})`,
                            backgroundRepeat: 'no-repeat',
                            backgroundPosition: 'center',
                            backgroundSize: '50%',
                            marginTop: '20px',
                        }}
                    />
                </Box>
            </Container>
        </Box>
    );
};

export default HomePage;
