import React, { useState, useEffect } from 'react';
import { Container, Typography, Button, Box, List, ListItem, ListItemText, ListItemIcon, IconButton, Paper, Dialog, DialogActions, DialogTitle } from '@mui/material';
import { Link } from 'react-router-dom';
import AddEditPetDialog from './AddEditPetDialog';
import EditIcon from '@mui/icons-material/Edit';
import PawIcon from '@mui/icons-material/Pets';
import BlockIcon from '@mui/icons-material/Block';
import { styled } from '@mui/material/styles';
import { getPetDetails, addPet, updatePet } from '../services/PetService';
import LanguageSwitcher from '../tools/LanguageSwitcher';
import { useTranslation } from 'react-i18next';

const StyledPaper = styled(Paper)(({ theme }) => ({
    borderRadius: '15px',
    boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
    overflow: 'hidden',
    marginTop: theme.spacing(2),
}));

const PetInfoPage = () => {
    const [pets, setPets] = useState([]);
    const [isDialogOpen, setDialogOpen] = useState(false);
    const [currentPet, setCurrentPet] = useState(null);
    const [openConfirmDialog, setOpenConfirmDialog] = useState(false);
    const { t } = useTranslation();

    useEffect(() => {
        fetchPets();
    }, []);

    const fetchPets = async () => {
        try {
            const response = await getPetDetails();
            setPets(response.data);
        } catch (error) {
            console.error('Failed to fetch pets:', error);
        }
    };

    const handleSavePet = async (pet) => {
        try {
            if (currentPet) {
                await updatePet({ ...pet, id: currentPet.id });
            } else {
                await addPet(pet);
            }
            fetchPets();
        } catch (error) {
            console.error('Failed to save pet:', error);
        } finally {
            handleDialogClose();
        }
    };

    const openDialogToAdd = () => {
        setCurrentPet(null);
        setDialogOpen(true);
    };

    const openDialogToEdit = (pet) => {
        setCurrentPet(pet);
        setDialogOpen(true);
    };

    const handleDialogClose = () => {
        setDialogOpen(false);
    };

    const openConfirmDisableDialog = (pet) => {
        setCurrentPet(pet);
        setOpenConfirmDialog(true);
    };

    const closeConfirmDialog = () => {
        setOpenConfirmDialog(false);
    };

    const handleDisablePet = async (pet) => {
        try {
            const updatedPet = { ...pet, enabled: false };
            await updatePet(updatedPet);
            fetchPets();
            setOpenConfirmDialog(false);
        } catch (error) {
            console.error('Failed to disable pet:', error);
        }
    };

    return (
        <Box
            sx={{
                height: '100vh',
                backgroundImage: `url("/pictures/park.webp")`,
                backgroundSize: 'cover',
                backgroundPosition: 'center bottom',
                backgroundRepeat: 'no-repeat',
                backgroundAttachment: 'fixed',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center',
            }}
        >
            <LanguageSwitcher />
            <Container maxWidth="sm" sx={{ textAlign: 'center', mb: 4 }}>
                <Typography variant="h3" gutterBottom sx={{ fontFamily: "'Fredoka One', cursive", color: 'white', textShadow: '1px 1px 2px rgba(0, 0, 0, 0.7)', }}>
                    {t('info')}
                </Typography>
                <Button variant="contained" color="primary" onClick={openDialogToAdd} sx={{ mb: 2 }}>
                    {t('addNewPet')}
                </Button>
                <StyledPaper>
                    <List sx={{ width: '100%' }}>
                        {pets.map((pet) => (
                            <ListItem key={pet.id} sx={{ borderRadius: '10px', boxShadow: '0 2px 5px rgba(0, 0, 0, 0.1)', my: 1, '&:hover': { backgroundColor: 'rgba(255, 255, 255, 0.9)', }, }}>
                                <ListItemIcon>
                                    <PawIcon sx={{ color: '#A8A8A8' }} />
                                </ListItemIcon>
                                <ListItemText primary={pet.name} secondary={pet.type} primaryTypographyProps={{ style: { fontWeight: 'bold' } }} secondaryTypographyProps={{ style: { color: '#696969' } }} />
                                <IconButton edge="end" onClick={() => openDialogToEdit(pet)}>
                                    <EditIcon sx={{ color: '#355C7D' }} />
                                </IconButton>
                                <IconButton edge="end" onClick={() => openConfirmDisableDialog(pet)}>
                                    <BlockIcon sx={{ color: 'red' }} />
                                </IconButton>
                            </ListItem>
                        ))}
                    </List>
                </StyledPaper>
                <Button variant="contained" color="secondary" component={Link} to="/" sx={{ borderRadius: '20px', minWidth: '120px', minHeight: '40px', fontSize: '0.9rem', fontWeight: 'bold', mt: 4, backgroundColor: '#F67280', '&:hover': { backgroundColor: '#F8B195', }, }}>
                    {t('backToHome')}
                </Button>
            </Container>
            <AddEditPetDialog open={isDialogOpen} onClose={handleDialogClose} onSave={handleSavePet} pet={currentPet} />
            <Dialog
                open={openConfirmDialog}
                onClose={closeConfirmDialog}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">
                    {"Are you sure you want to disable this pet?"}
                </DialogTitle>
                <DialogActions>
                    <Button onClick={closeConfirmDialog}>No</Button>
                    <Button onClick={() => handleDisablePet(currentPet)} autoFocus>
                        Yes
                    </Button>
                </DialogActions>
            </Dialog>
        </Box>
    );
};

export default PetInfoPage;
