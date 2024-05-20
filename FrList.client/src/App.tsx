import {useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import PersonsIndex from "./components/PersonsIndex.tsx";

function App() {
    const [count, setCount] = useState(0)

    return (
        <>


            <div className="container mt-5">
                <PersonsIndex></PersonsIndex>
            </div>


        </>
    )
}

export default App

