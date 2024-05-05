import React, { useState } from 'react';
import { Button, Menu, MenuItem } from '@mui/material';
import LanguageIcon from '@mui/icons-material/Language'; // Иконка языка
import { useTranslation } from 'react-i18next';

const LanguageSwitcher = () => {
    const { i18n } = useTranslation();
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    const changeLanguage = (language) => {
        i18n.changeLanguage(language);
        handleClose();
    };

    return (
        <div style={{ position: 'absolute', top: 20, right: 20 }}>
            <Button
                aria-controls="language-menu"
                aria-haspopup="true"
                aria-expanded={open ? 'true' : undefined}
                onClick={handleClick}
                sx={{
                    minWidth: 40, minHeight: 40, borderRadius: '50%',
                    backgroundColor: '#fff', // Можете выбрать цвет фона кнопки
                    '&:hover': {
                        backgroundColor: '#f0f0f0',
                    }
                }}
            >
                <LanguageIcon /> {/* Иконка флага или языка */}
            </Button>
            <Menu
                id="language-menu"
                anchorEl={anchorEl}
                keepMounted
                open={open}
                onClose={handleClose}
            >
                <MenuItem onClick={() => changeLanguage('en')}>English</MenuItem>
                <MenuItem onClick={() => changeLanguage('ru')}>Русский</MenuItem>
                {/* Добавьте другие языки здесь */}
            </Menu>
        </div>
    );
};

export default LanguageSwitcher;
