import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';
import { useMemo } from 'react';

const API_BASE_URL = 'https://localhost:44379';

export const useAuthenticatedAxios = () => {
    const { getAccessTokenSilently } = useAuth0();

    const apiClient = useMemo(() => {
        const createClient = async () => {
            const token = await getAccessTokenSilently();

            return axios.create({
                baseURL: API_BASE_URL,
                headers: {
                    Authorization: `Bearer ${token}`,
                    'Content-Type': 'application/json',
                },
            });
        };

        return createClient();
    }, [getAccessTokenSilently]);

    return apiClient;
};
