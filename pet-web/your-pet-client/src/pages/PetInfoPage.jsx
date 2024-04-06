import React, { useState } from 'react';
import { Container, Typography, Button, Box, List, ListItem, ListItemText, ListItemIcon, IconButton, Paper } from '@mui/material';
import { Link } from 'react-router-dom';
import AddPetDialog from './AddPetDialog'; // Путь к вашему компоненту диалогового окна для добавления/редактирования питомца
import EditIcon from '@mui/icons-material/Edit'; // Иконка для кнопки редактирования
import PawIcon from '@mui/icons-material/Pets'; // Иконка питомца
import { styled } from '@mui/material/styles';

// Тестовые данные питомцев
const initialPets = [
    { id: 1, name: "Charlie", type: "Dog" },
    { id: 2, name: "Max", type: "Cat" },
];

const StyledPaper = styled(Paper)(({ theme }) => ({
    borderRadius: '15px',
    boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
    overflow: 'hidden',
    marginTop: theme.spacing(2),
}));

const PetInfoPage = () => {
    const [pets, setPets] = useState(initialPets);
    const [isDialogOpen, setDialogOpen] = useState(false);
    const [currentPet, setCurrentPet] = useState(null); // Текущий питомец для редактирования

    const openDialogToAdd = () => {
        setCurrentPet(null); // Очищаем текущего питомца при добавлении нового
        setDialogOpen(true);
    };

    const openDialogToEdit = (pet) => {
        setCurrentPet(pet); // Устанавливаем текущего питомца для редактирования
        setDialogOpen(true);
    };

    const handleDialogClose = () => {
        setDialogOpen(false);
    };

    const handleSavePet = (pet) => {
        if (currentPet) {
            // Обновляем существующего питомца
            setPets(pets.map(p => p.id === currentPet.id ? { ...pet, id: currentPet.id } : p));
        } else {
            // Добавляем нового питомца
            setPets([...pets, { ...pet, id: Date.now() }]); // Используем timestamp в качестве уникального ID для примера
        }
        handleDialogClose();
    };

    return (
        <Box
            sx={{
                width: '100%',
                minHeight: '100vh',
                backgroundImage: `url("/pictures/field.webp")`,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center',
                pt: 4,
                px: 2,
            }}
        >
            <Container maxWidth="sm" sx={{ textAlign: 'center', mb: 4 }}>
                <Typography
                    variant="h3"
                    gutterBottom
                    sx={{
                        fontFamily: "'Fredoka One', cursive", // Замените на ваш предпочитаемый шрифт, если Fredoka One не используется
                        color: 'white', // Белый цвет текста для лучшей читаемости на темной подложке
                        textShadow: '1px 1px 2px rgba(0, 0, 0, 0.7)', // Тень текста для дополнительной читаемости
                    }}
                >
                    Information about Pets
                </Typography>
                <Button variant="contained" color="primary" onClick={openDialogToAdd} sx={{ mb: 2 }}>
                    Add New Pet
                </Button>
                <Paper elevation={3} sx={{ mt: 2, py: 2, borderRadius: 3 }}>
                    <List sx={{ width: '100%' }}>
                        {pets.map((pet) => (
                            <ListItem
                                key={pet.id}
                                sx={{
                                    borderRadius: '10px',
                                    boxShadow: '0 2px 5px rgba(0, 0, 0, 0.1)',
                                    my: 1,
                                    '&:hover': {
                                        backgroundColor: 'rgba(255, 255, 255, 0.9)',
                                    },
                                }}
                            >
                                <ListItemIcon>
                                    <PawIcon sx={{ color: '#A8A8A8' }} />
                                </ListItemIcon>
                                <ListItemText
                                    primary={pet.name}
                                    secondary={pet.type}
                                    primaryTypographyProps={{ style: { fontWeight: 'bold' } }}
                                    secondaryTypographyProps={{ style: { color: '#696969' } }}
                                />
                                <IconButton edge="end" onClick={() => openDialogToEdit(pet)}>
                                    <EditIcon sx={{ color: '#355C7D' }} />
                                </IconButton>
                            </ListItem>
                        ))}
                    </List>
                </Paper>
                <Button
                    variant="contained"
                    color="secondary"
                    component={Link}
                    to="/"
                    sx={{
                        borderRadius: '20px',
                        minWidth: '120px',
                        minHeight: '40px',
                        fontSize: '0.9rem',
                        fontWeight: 'bold',
                        mt: 4,
                        backgroundColor: '#F67280',
                        '&:hover': {
                            backgroundColor: '#F8B195',
                        },
                    }}
                >
                    Back to Home
                </Button>
            </Container>
            <AddPetDialog open={isDialogOpen} onClose={handleDialogClose} onSave={handleSavePet} pet={currentPet} />
        </Box>
    );
};

export default PetInfoPage;