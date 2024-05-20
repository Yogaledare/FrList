import PersonsTable from "./PersonsTable.tsx";
import CreatePersonForm from "./CreatePersonForm.tsx";


const PersonsIndex = () => {

    return (
        <>
            <div className={"justify-content-center d-flex"}>

                <div className="col-8">
                <h1>Personalregister</h1>


                    {/*<div className={"my-5 d-flex justify-content-center"}>*/}
                    <div className={"my-5"}>
                        <CreatePersonForm></CreatePersonForm>
                    </div>
                    <div className={"my-5"}>
                        <PersonsTable></PersonsTable>
                    </div>
                </div>
            </div>
        </>

    )

}

export default PersonsIndex; 
