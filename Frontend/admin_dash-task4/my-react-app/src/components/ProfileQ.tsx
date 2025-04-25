import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom';
import { User } from '../types/User';
import { Table } from './Home';
import styled from 'styled-components';

function ProfileQ(){
    const Container = styled.div`
    justify-content: center;
    align-items: center;
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    margin-left: 300px;
    height: 300px;
    width: 600px;
    `;

    const Input = styled.input`
        padding: 10px;
        font-size: 16px;
        border-radius: 4px;
        border: 1px solid #ccc;
        margin-top: 10px;
        margin-left: 140px;
        width: 50%;
        justify-content: center;
    `;

    const Button = styled.button`
        padding: 10px;
        background-color: #007bff;
        color: white;
        width: 200px;
        margin-top: 20px;
        margin-left: 200px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        font-size: 16px;
        &:hover {
            background-color: #0056b3;
        }
    `;

    const Heading =styled.h2`
        color: black;
        font-weight: bold;
        text-align: center;
    `;
    const [userId, setUserId]=useState('');
    const navigate= useNavigate();

    const handleUser=()=>{
        if(userId){
            navigate(`/profile/${userId}`);
        }else{
            alert("Plese enter valid id");
        }
    };


    return(
        <Container>
            <Heading>Enter User ID to View Profile</Heading>
            <Input
                type="text" 
                value={userId} 
                onChange={(e) => setUserId(e.target.value)} 
                required 
                placeholder="User ID"
            />
            <br/>
            <Button onClick={handleUser}>Enter</Button>
        </Container>
    );
}
export default ProfileQ;