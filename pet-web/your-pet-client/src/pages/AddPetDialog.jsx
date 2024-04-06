import React, { useState } from 'react';
import { Button, TextField, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, InputLabel, Select, MenuItem } from '@mui/material';


const AddPetDialog = ({ open, onClose, onSave }) => {
    const [pet, setPet] = useState({
        name: '',
        species: '', // Это поле будет использоваться для типа животного
        // Добавьте другие поля согласно вашей модели
    });

    const handleChange = (event) => {
        const { name, value } = event.target;
        setPet(prevPet => ({ ...prevPet, [name]: value }));
    };

    const handleSave = () => {
        onSave(pet);
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Add New Pet</DialogTitle>
            <DialogContent>
                <TextField
                    autoFocus
                    margin="dense"
                    name="name"
                    label="Name"
                    type="text"
                    fullWidth
                    variant="outlined"
                    value={pet.name}
                    onChange={handleChange}
                />
                <FormControl fullWidth margin="dense">
                    <InputLabel id="species-select-label">Species</InputLabel>
                    <Select
                        labelId="species-select-label"
                        id="species-select"
                        value={pet.species}
                        label="Species"
                        onChange={handleChange}
                        name="species"
                    >
                        <MenuItem value="Dog">Dog</MenuItem>
                        <MenuItem value="Cat">Cat</MenuItem>
                        <MenuItem value="Bird">Bird</MenuItem>
                        <MenuItem value="Reptile">Reptile</MenuItem>
                        <MenuItem value="Other">Other</MenuItem>
                    </Select>
                </FormControl>
                {/* Добавьте другие поля ввода */}
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="primary">Cancel</Button>
                <Button onClick={handleSave} color="primary">Save</Button>
            </DialogActions>
        </Dialog>
    );
};

export default AddPetDialog;