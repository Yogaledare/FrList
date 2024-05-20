import {useState} from "react";
import {useCreateMember} from "../api/personHooks.ts";


const CreatePersonForm = () => {
    const resetForm = () => {
        setPerson({
            name: '',
            age: '',
            nick: '',
            date: ''
        });
    }
    
    const {mutate, isError, error} = useCreateMember(resetForm);

    const [person, setPerson] = useState({
        name: '',
        age: '',
        nick: '',
        date: ''
    })

    const errors = error?.response?.data.errors;

    const handleInputChange = (e) => {
        const {name, value} = e.target;
        setPerson(prev => ({
            ...prev,
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const submissionData = {
            ...person,
            age: parseInt(person.age, 10),
            date: person.date
        };
        mutate(submissionData);
    };


    const ValidationErrorDisplay = ({errors}) => {
        return (
            <div className="text-danger ms-2">
                {errors.join(', ')}
            </div>
        );
    };


    return (
        <>
            <div className="card">
                <div className={"card-body"}>
                    <div className={"card-title mb-4"}>
                        <h5>Skapa ny</h5>
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="col-9">
                            <div className="row mb-2">
                                <div className="col-md-3">
                                    <label htmlFor="name" className="col-form-label">Namn</label>
                                </div>
                                <div className="col-md-9">
                                    <input
                                        type="text"
                                        className="form-control"
                                        name="name"
                                        value={person.name}
                                        onChange={handleInputChange}
                                    />
                                    {errors?.Name && <ValidationErrorDisplay errors={errors.Name}/>}
                                </div>

                            </div>
                            <div className="row mb-2">
                                <div className="col-md-3">
                                    <label htmlFor="age" className="col-form-label">Ålder</label>
                                </div>
                                <div className="col-md-9">
                                    <input
                                        type="number"
                                        className="form-control"
                                        name="age"
                                        value={person.age}
                                        onChange={handleInputChange}
                                    />
                                    {errors?.Age && <ValidationErrorDisplay errors={errors.Age}/>}
                                </div>
                            </div>
                            <div className="row mb-2">
                                <div className="col-md-3">
                                    <label htmlFor="nick" className="col-form-label">Smeknamn</label>
                                </div>
                                <div className="col-md-9">
                                    <input
                                        type="text"
                                        className="form-control"
                                        name="nick"
                                        value={person.nick}
                                        onChange={handleInputChange}
                                    />
                                    {errors?.Nick && <ValidationErrorDisplay errors={errors.Nick}/>}
                                </div>
                            </div>
                            <div className="row mb-2">
                                <div className="col-md-3">
                                    <label htmlFor="date" className="col-form-label">Datum</label>
                                </div>
                                <div className="col-md-9">
                                    <input
                                        type="date"
                                        className="form-control"
                                        name="date"
                                        value={person.date}
                                        onChange={handleInputChange}
                                    />
                                    {errors?.Date && <ValidationErrorDisplay errors={errors.Date}/>}
                                </div>
                            </div>
                        </div>
                        <div className={"d-flex justify-content-end"}>
                            <button type="submit" className="btn btn-primary mt-3">Spara</button>
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
        ;
}


export default CreatePersonForm; 