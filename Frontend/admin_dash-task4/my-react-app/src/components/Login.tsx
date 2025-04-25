import React, { useState } from 'react';
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';

const Container = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f7f7f7;
`;

const Form = styled.form`
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    width: 300px;
    display: flex;
    flex-direction: column;
    gap: 15px;
`;

const Title = styled.h2`
    text-align: center;
    margin-bottom: 20px;
    color: #333;
`;

const Label = styled.label`
    font-size: 14px;
    color: #555;
`;

const Input = styled.input`
    padding: 10px;
    font-size: 16px;
    border-radius: 4px;
    border: 1px solid #ccc;
    margin-top: 5px;
    width: 100%;
`;

const Button = styled.button`
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
    &:hover {
        background-color: #0056b3;
    }
`;

const ErrorMessage = styled.p`
    color: red;
    font-size: 12px;
    text-align: center;
`;

function LoginForm() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
     
        if (username === '' || password === '') {
            setError('Username and Password are required.');
            return;
        }

        if (username === 'admin' && password === 'admin123') {
            navigate('/');
            setError(null);  
        } else {
            setError('Invalid Username or Password');
        }
    };

    return (
        <Container>
            <Form onSubmit={handleSubmit}>
                <Title>Admin Login</Title>
                
                <Label htmlFor="username">Username</Label>
                <Input 
                    type="text" 
                    id="username" 
                    value={username} 
                    onChange={(e) => setUsername(e.target.value)} 
                    required 
                />
                
                <Label htmlFor="password">Password</Label>
                <Input 
                    type="password" 
                    id="password" 
                    value={password} 
                    onChange={(e) => setPassword(e.target.value)} 
                    required 
                />
                
                {error && <ErrorMessage>{error}</ErrorMessage>}
                
                <Button type="submit">Login</Button>
            </Form>
        </Container>
    );
}

export default LoginForm;
