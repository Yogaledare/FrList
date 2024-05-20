import {useMutation, useQuery, useQueryClient} from "react-query";
import axios, {AxiosError, AxiosResponse} from "axios";
import config from "../config.ts";
import {Person, PersonCreate} from "../types/person.ts"
import MemberValidationProblem from "../types/problem.ts";

const useFetchPersons = () => {
    return useQuery<Person[], AxiosError>(['persons'], async () => {
        const response = await axios.get(`${config.baseApiUrl}/persons`);
        return response.data;
    })
}


const useCreateMember = (onSuccessCallback: () => void) => {
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<MemberValidationProblem>, PersonCreate>(
        (p) => axios.post(`${config.baseApiUrl}/persons`, p),
        {
            onSuccess: async () => {
                await queryClient.invalidateQueries('persons');
                onSuccessCallback(); 
            }
        }
    )
}


export {useFetchPersons, useCreateMember}