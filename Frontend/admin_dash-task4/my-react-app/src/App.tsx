import React  from "react";
import { BrowserRouter as Router, Routes, Route} from "react-router-dom";
import Navbar from './components/Navbar';
import Home from './components/Home';
import Profile from './components/Profile';
import Settings from './components/Settings';
import ProfileQ from "./components/ProfileQ";

function App(){
    return(
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<Home/>}/>
                <Route path="/profilequery" element={<ProfileQ/>}/>
                <Route path="/profile/:id" element={<Profile/>}/>
                <Route path="/settings" element={<Settings/>}/>
            </Routes>
        </Router>
    );
}

export default App;