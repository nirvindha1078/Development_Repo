import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import styled from 'styled-components';
import { User } from '../types/User';

const ProfileStyle = styled.div`
  width: 80%;
  margin-top: 50px;
  margin-left: 270px;
  padding: 10px 20px 20px 40px;
  border: 2px solid black;
  background-color: white;
`;

const Para = styled.p`
  font-weight: bold;
  font-size: 20px;
  margin-left: 550px;
`;

function Profile() {
  const { id } = useParams<{ id: string }>();
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    setLoading(true);
    fetch(`https://jsonplaceholder.typicode.com/users/${id}`)
      .then((res) => res.json())
      .then((data) => {
        if (data && data.id) {
          setUser(data);
        } else {
          setUser(null); 
        }
        setLoading(false);
      })
      .catch(() => {
        setUser(null); 
        setLoading(false);
      });
  }, [id]);

  if (loading) return <Para>Loading...</Para>;
  if (!user) return <Para>User Not Found</Para>;

  return (
    <ProfileStyle>
      <h1>{user.name}</h1>
      <p><strong>Email: </strong>{user.email}</p>
      <p><strong>Address: </strong>{user.address.street}, {user.address.city}</p>
      <p><strong>Phone: </strong>{user.phone}</p>
      <p><strong>Website: </strong>{user.website}</p>
    </ProfileStyle>
  );
}

export default Profile;
