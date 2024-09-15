import React from 'react';

const AvatarCat = () => {
    return (
        <img
            src="/pictures/avatars/catAvatar.png"
            alt="Cat Avatar"
            style={{
                width: '100%',
                height: 'auto',
                borderRadius: '50%',
                objectFit: 'cover'
            }}
        />
    );
};

export default AvatarCat;