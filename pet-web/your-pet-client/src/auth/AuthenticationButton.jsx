import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import { Button } from '@mui/material';

const AuthenticationButton = () => {
    const { loginWithRedirect, logout, isAuthenticated } = useAuth0();

    return (
        <div>
            {isAuthenticated ? (
                <Button
                    variant="contained"
                    color="secondary"
                    onClick={() => logout({ returnTo: window.location.origin })}
                >
                    Log out
                </Button>
            ) : (
                <Button
                    variant="contained"
                    color="primary"
                    onClick={() => loginWithRedirect()}
                >
                    Log in
                </Button>
            )}
        </div>
    );
};

export default AuthenticationButton;
