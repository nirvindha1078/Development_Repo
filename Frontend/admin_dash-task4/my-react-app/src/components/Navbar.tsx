import React from 'react';
import { NavLink } from 'react-router-dom';
import styled from 'styled-components';

const NavStyle = styled.nav`
    display: flex;
    align-items: centre;
    justify-content: space-around;
    background-color: #007bff;
    padding: 10px;
    padding-bottom: 10px;
    margin-top: 20px;
    margin-left: 90px;
    margin-right: 20px;
    border-radius: 5px;
    width: 85%; 
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    z-index: 1000;
    height: 50px;
    box-sizing: border-box;
    a{
        color: white;
        font-size: 18px;
        &.active{
            color: black;
        }
    }
`;

function Navbar(){
    return(
        <NavStyle>
            <NavLink to="/" >Home</NavLink>
            <NavLink to="/profilequery">Profile</NavLink>
            <NavLink to="/settings">Settings</NavLink>
        </NavStyle>
    );
}

export default Navbar;