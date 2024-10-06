import { useAuthenticatedAxios } from '../auth/AuthenticationTokenManager';
import { useAuth0 } from '@auth0/auth0-react'; // Import Auth0 to access the user ID

export const usePetService = () => {
    const apiClient = useAuthenticatedAxios();
    const { user } = useAuth0();

    const registerUser = async () => {
        const api = await apiClient;
        const registerPayload = {
            auth0Id: user.sub,
            fullName: user.name || '',
            email: user.email || '',
        };

        return api.post('/AppUser/register', registerPayload);
    };

    const getPetDetails = async () => {
        const api = await apiClient;

        return api.get(`/Pet`);
    };

    const addPet = async (petData) => {
        const api = await apiClient;
        return api.post(`/Pet`, petData);
    };

    const updatePet = async (petData) => {
        const api = await apiClient;
        return api.put(`/Pet`, petData);
    };

    return { registerUser, getPetDetails, addPet, updatePet };
};
