import {useFetchPersons} from "../api/personHooks.ts";
import ApiStatus from "./ApiStatus.tsx";


const PersonsTable = () => {
    const {data: persons, isSuccess, status, isError, error: apiError} = useFetchPersons();


    if (!isSuccess) {
        return (<ApiStatus status={status}/>)
    }

    return (
        <>
            <table className='table table-bordered'>
                <thead className={"table-light"}>
                <tr>
                    <th scope={"col"}>Namn</th>
                    <th scope={"col"}>Ålder</th>
                    <th scope={"col"}>Smeknamn</th>
                    <th scope={"col"}>Datum</th>
                </tr>
                </thead>
                <tbody>
                {persons &&
                    persons.map((person) => (
                        <tr
                            key={person.personId}
                            // onClick={() => nav(`/members/${member.memberId}`)}
                        >
                            <td>{person.name}</td>
                            <td>{person.age}</td>
                            <td>{person.nick}</td>
                            <td>{person.date}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    ) ; 
    

}

export default PersonsTable; 


    