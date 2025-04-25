import React, {useEffect, useState, useCallback} from 'react';
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';
import {User} from '../types/User.ts'


const Heading = styled.h2`
margin-top: 100px;
text-align: center;
`;

 export const Table = styled.table`
    width: 90%;
    margin-left: 75px;
    margin-bottom: 20px;
    border-collapse: collapse;
    th, td{
        padding: 10px;
        border: 2px solid black;
        border-radius: 5px; 
        text-align: center;
    }
`;

const Button= styled.button`
padding: 5px 10px;
background-color: #007bff;
color: white;
border: none;
cursor: pointer;
&:hover{
    background-color:rgb(135, 178, 224);
}
`;

function Home(){
    const [users, setUsers]=useState<User[]>([]);
    const navigate = useNavigate();

    useEffect(()=>{
        fetch('https://jsonplaceholder.typicode.com/users')
        .then((res)=>res.json())
        .then(setUsers);
    },[]);

    const navigateProfile=useCallback((id:number)=>{
        navigate(`/profile/${id}`);
    },[navigate]);

    return(
        <div>
            <Heading>User Details</Heading>
            <Table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Adress</th>
                        <th>Phone</th>
                        <th>Website</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user)=>(
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.name}</td>
                            <td>{user.email}</td>
                            <td>{user.address.street}, {user.address.city}</td>
                            <td>{user.phone}</td>
                            <td>{user.website}</td>
                            <td>
                                <Button onClick={()=> navigateProfile(user.id)}>View Profile</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>      
    );
}
export default Home;