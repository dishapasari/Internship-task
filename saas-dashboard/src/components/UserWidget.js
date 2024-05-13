import React, { useState, useEffect } from 'react';
import axios from 'axios';

const UserWidget = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async () => {
            const response = await axios.get('http://localhost:5205/user');
            setUsers(response.data);
        };
        fetchUsers();
    }, []);

    return (
        <div>
            <h2>User List</h2>
            <ul>
                {users.map(user => (
                    <li key={user.username}>{user.username}</li>
                ))}
            </ul>
        </div>
    );
};

export default UserWidget;
