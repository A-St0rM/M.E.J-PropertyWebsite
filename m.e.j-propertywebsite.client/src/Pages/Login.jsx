import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Css/Login.css';
import Menu from '../Componets/Menu';

function Login() {
	const [username, setUsername] = useState('');
	const [password, setPassword] = useState('');
	const navigate = useNavigate();

	const handleSubmit = async (e) => {
		e.preventDefault();

		const response = await fetch('https://localhost:7230//api/login/login', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify({ UserName: username, Password: password }),
		});

		if (response.ok) {
			navigate('/admin');
		} else {
			alert('Invalid username or password');
		}
	};

	return (
		<div>
			<Menu />
			<div className="login-container">
				<h1>Login</h1>
				<form onSubmit={handleSubmit}>
					<label>
						Brugernavn:
						<input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)} />
					</label>
					<label>
						Adgangskode:
						<input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} />
					</label>
					<button type="submit">Login</button>
				</form>
			</div>
		</div>
	);
}

export default Login;
