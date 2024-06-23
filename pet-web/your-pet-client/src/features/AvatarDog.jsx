import React from 'react';

const AvatarDog = () => {
    return (
        <img
            src="/pictures/avatars/dogAvatar.webp"
            alt="Dog Avatar"
            style={{
                width: '100%',
                height: 'auto',
                borderRadius: '50%',
                objectFit: 'cover'
            }}
        />
    );
};

export default AvatarDog;