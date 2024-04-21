import React, { useEffect, useState } from 'react';
import { Button, TextField, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, InputLabel, Select, MenuItem, Box } from '@mui/material';

const formatDate = (dateStr) => {
    if (!dateStr) return '';

    const date = new Date(dateStr);
    return date.toISOString().split('T')[0];  // Correctly format the date to "yyyy-MM-dd"
};

const AddEditPetDialog = ({ open, onClose, onSave, pet: initialPet }) => {
    const [pet, setPet] = useState({
        name: '',
        species: '',
        breed: '',
        dateOfBirth: '', // Ensure this is initially empty or correctly formatted
        gender: '',
        color: '',
        weight: '',
        microchipID: '',
        vaccinationRecords: '',
        medicalHistory: '',
        specialNeeds: '',
        dietaryRequirements: '',
        behaviorNotes: ''
    });

    useEffect(() => {
        if (initialPet) {
            setPet({
                ...initialPet,
                dateOfBirth: formatDate(initialPet.dateOfBirth) // Format date when setting the initial pet
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
                behaviorNotes: ''
            });
        }
    }, [initialPet, open]);

    const handleChange = (event) => {
        const { name, value } = event.target;
        setPet(prevPet => ({ ...prevPet, [name]: value }));
    };

    const handleSave = () => {
        onSave({
            ...pet,
            dateOfBirth: formatDate(pet.dateOfBirth) // Ensure date is correctly formatted before saving
        });
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
            <DialogTitle>{initialPet ? 'Edit Pet' : 'Add New Pet'}</DialogTitle>
            <DialogContent>
                <Box component="form" noValidate autoComplete="off" sx={{ display: 'grid', gap: 2 }}>
                    <TextField
                        autoFocus
                        margin="dense"
                        name="name"
                        label="Name"
                        type="text"
                        fullWidth
                        value={pet.name}
                        onChange={handleChange}
                    />
                    <FormControl fullWidth>
                        <InputLabel id="species-label">Species</InputLabel>
                        <Select
                            labelId="species-label"
                            name="species"
                            value={pet.species}
                            label="Species"
                            onChange={handleChange}
                        >
                            <MenuItem value="Dog">Dog</MenuItem>
                            <MenuItem value="Cat">Cat</MenuItem>
                            <MenuItem value="Bird">Bird</MenuItem>
                            <MenuItem value="Reptile">Reptile</MenuItem>
                            <MenuItem value="Other">Other</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        margin="dense"
                        name="breed"
                        label="Breed"
                        type="text"
                        fullWidth
                        value={pet.breed}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="dateOfBirth"
                        label="Date of Birth"
                        type="date"
                        fullWidth
                        InputLabelProps={{
                            shrink: true,
                        }}
                        value={pet.dateOfBirth}
                        onChange={handleChange}
                    />
                    <FormControl fullWidth>
                        <InputLabel id="gender-label">Gender</InputLabel>
                        <Select
                            labelId="gender-label"
                            name="gender"
                            value={pet.gender}
                            label="Gender"
                            onChange={handleChange}
                        >
                            <MenuItem value="Male">Male</MenuItem>
                            <MenuItem value="Female">Female</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        margin="dense"
                        name="color"
                        label="Color"
                        type="text"
                        fullWidth
                        value={pet.color}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="weight"
                        label="Weight (kg)"
                        type="number"
                        fullWidth
                        value={pet.weight}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="microchipID"
                        label="Microchip ID"
                        type="text"
                        fullWidth
                        value={pet.microchipID}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="vaccinationRecords"
                        label="Vaccination Records"
                        type="text"
                        fullWidth
                        value={pet.vaccinationRecords}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="medicalHistory"
                        label="Medical History"
                        type="text"
                        fullWidth
                        value={pet.medicalHistory}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="specialNeeds"
                        label="Special Needs"
                        type="text"
                        fullWidth
                        value={pet.specialNeeds}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="dietaryRequirements"
                        label="Dietary Requirements"
                        type="text"
                        fullWidth
                        value={pet.dietaryRequirements}
                        onChange={handleChange}
                    />
                    <TextField
                        margin="dense"
                        name="behaviorNotes"
                        label="Behavior Notes"
                        type="text"
                        fullWidth
                        value={pet.behaviorNotes}
                        onChange={handleChange}
                    />
                </Box>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Cancel</Button>
                <Button onClick={handleSave} color="primary">{initialPet ? 'Update' : 'Add'}</Button>
            </DialogActions>
        </Dialog>
    );
};

export default AddEditPetDialog;