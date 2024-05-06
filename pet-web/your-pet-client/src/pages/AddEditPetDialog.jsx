import React, { useEffect, useState } from 'react';
import { Button, TextField, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, InputLabel, Select, MenuItem, Box } from '@mui/material';
import { useTranslation } from 'react-i18next';

const formatDate = (dateStr) => {
    if (!dateStr) return '';
    const date = new Date(dateStr);
    return date.toISOString().split('T')[0];  // Correctly format the date to "yyyy-MM-dd"
};

const AddEditPetDialog = ({ open, onClose, onSave, pet: initialPet }) => {
    const { t } = useTranslation();
    const [pet, setPet] = useState({
        name: '',
        species: '',
        breed: '',
        dateOfBirth: '',
        gender: '',
        color: '',
        weight: '',
        microchipID: '',
        vaccinationRecords: '',
        medicalHistory: '',
        specialNeeds: '',
        dietaryRequirements: '',
        behaviorNotes: '',
        enabled: true  // Assuming enabled is a boolean, defaulting to true for new entries
    });

    useEffect(() => {
        if (initialPet) {
            setPet({
                ...initialPet,
                dateOfBirth: formatDate(initialPet.dateOfBirth)
            });
        } else {
            setPet({
                name: '',
                species: '',
                breed: '',
                dateOfBirth: '',
                gender: '',
                color: '',
                weight: '',
                microchipID: '',
                vaccinationRecords: '',
                medicalHistory: '',
                specialNeeds: '',
                dietaryRequirements: '',
                behaviorNotes: '',
                enabled: true
            });
        }
    }, [initialPet, open]);

    const handleChange = (event) => {
        const { name, value, checked, type } = event.target;
        setPet(prevPet => ({ ...prevPet, [name]: type === 'checkbox' ? checked : value }));
    };

    const handleSave = () => {
        onSave({
            ...pet,
            dateOfBirth: formatDate(pet.dateOfBirth)
        });
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
            <DialogTitle>{initialPet ? t('editPet') : t('addNewPetDialog')}</DialogTitle>
            <DialogContent>
                <Box component="form" noValidate autoComplete="off" sx={{ display: 'grid', gap: 2 }}>
                    <TextField
                        autoFocus
                        margin="dense"
                        name="name"
                        label={t('name')}
                        type="text"
                        fullWidth
                        value={pet.name}
                        onChange={handleChange}
                    />
                    <FormControl fullWidth>
                        <InputLabel id="species-label">{t('species')}</InputLabel>
                        <Select
                            labelId="species-label"
                            name="species"
                            value={pet.species}
                            label={t('species')}
                            onChange={handleChange}
                        >
                            <MenuItem value="Dog">{t('Dog')}</MenuItem>
                            <MenuItem value="Cat">{t('Cat')}</MenuItem>
                            <MenuItem value="Bird">{t('Bird')}</MenuItem>
                            <MenuItem value="Reptile">{t('Reptile')}</MenuItem>
                            <MenuItem value="Other">{t('Other')}</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        margin="dense"
                        name="breed"
                        label={t('breed')}
                        type="text"
                        fullWidth
                        value={pet.breed}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="dateOfBirth"
                        label={t('dateOfBirth')}
                        type="date"
                        fullWidth
                        InputLabelProps={{
                            shrink: true,
                        }}
                        value={pet.dateOfBirth}
                        onChange={handleChange}
                    />
                    <FormControl fullWidth>
                        <InputLabel id="gender-label">{t('gender')}</InputLabel>
                        <Select
                            labelId="gender-label"
                            name="gender"
                            value={pet.gender}
                            label={t('gender')}
                            onChange={handleChange}
                        >
                            <MenuItem value="Male">{t('Male')}</MenuItem>
                            <MenuItem value="Female">{t('Female')}</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        margin="dense"
                        name="color"
                        label={t('color')}
                        type="text"
                        fullWidth
                        value={pet.color}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="weight"
                        label={t('weight')}
                        type="number"
                        fullWidth
                        value={pet.weight}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="microchipID"
                        label={t('microchipID')}
                        type="text"
                        fullWidth
                        value={pet.microchipID}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="vaccinationRecords"
                        label={t('vaccinationRecords')}
                        type="text"
                        fullWidth
                        value={pet.vaccinationRecords}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="medicalHistory"
                        label={t('medicalHistory')}
                        type="text"
                        fullWidth
                        value={pet.medicalHistory}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="specialNeeds"
                        label={t('specialNeeds')}
                        type="text"
                        fullWidth
                        value={pet.specialNeeds}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="dietaryRequirements"
                        label={t('dietaryRequirements')}
                        type="text"
                        fullWidth
                        value={pet.dietaryRequirements}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="behaviorNotes"
                        label={t('behaviorNotes')}
                        type="text"
                        fullWidth
                        value={pet.behaviorNotes}
                        onChange={handleChange}
                    />
                </Box>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">{t('cancel')}</Button>
                <Button onClick={handleSave} color="primary">{initialPet ? t('update') : t('add')}</Button>
            </DialogActions>
        </Dialog>
    );
};

export default AddEditPetDialog;
