import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';
import { useMemo } from 'react';

const API_BASE_URL = 'https://localhost:44379';

export const useAuthenticatedAxios = () => {
    const { getAccessTokenSilently } = useAuth0();

    const apiClient = useMemo(async () => {
        const token = await getAccessTokenSilently();
        console.log("Auth Token: ", token);

        return axios.create({
            baseURL: API_BASE_URL,
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
        });
    }, [getAccessTokenSilently]);

    return apiClient;
};
