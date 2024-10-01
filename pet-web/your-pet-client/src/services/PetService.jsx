import { useAuthenticatedAxios } from '../auth/AuthenticationTokenManager';
import { useAuth0 } from '@auth0/auth0-react'; // Import Auth0 to access the user ID

// Custom hook for Pet service functions
export const usePetService = () => {
    const apiClient = useAuthenticatedAxios(); // Calling the hook inside a valid custom hook
    const { user } = useAuth0(); // Get the Auth0 user object

    // Get only pets belonging to the authenticated user
    const getPetDetails = async () => {
        const api = await apiClient;
        const userId = user.sub; // Use the Auth0 user ID (sub field)
        return api.get(`/Pet/${userId}`); // Assuming the API has this endpoint for user-specific pets
    };

    const addPet = async (petData) => {
        const api = await apiClient;
        const userId = user.sub; // Get the user's ID to associate the pet
        return api.post(`/Pet`, { ...petData, userId }); // Send userId with the request body
    };

    const updatePet = async (petData) => {
        const api = await apiClient;
        return api.put(`/Pet`, petData);
    };

    return { getPetDetails, addPet, updatePet };
};
