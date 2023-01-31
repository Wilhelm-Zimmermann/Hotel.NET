import { Container } from "react-bootstrap"
import { api } from "../../services/api";
import { useState, FormEvent } from "react";
import { StyledFormGroup, StyledLoginForm } from "./styles";
import { LoginResult } from "../../utils/GenericResult";
import { login } from "../../services/auth";

interface LoginFormData{
    name: string;
    password: string;
}

export const LoginForm = () => {
    const [name, setName] = useState("");
    const [password, setPassword] = useState("");

    const loginForm = async (e: FormEvent) => {
        e.preventDefault();

        const userFormData: LoginFormData = {
            name,
            password
        }

        const {data} = await api.post<LoginResult>("/users/login", userFormData);
        const {token} = data.data;
        
        login(token);
    }

    return(
        <Container>
            <StyledLoginForm onSubmit={loginForm}>
                <StyledFormGroup>
                    <label>Email Address</label>
                    <input type="text" value={name} placeholder="username" onChange={e => setName(e.target.value)}/>
                </StyledFormGroup>
                <StyledFormGroup>
                    <label>Password</label>
                    <input type="text" value={password}  onChange={e => setPassword(e.target.value)}/>
                </StyledFormGroup>
                <StyledFormGroup>
                    <button type="submit">Send</button>
                </StyledFormGroup>
            </StyledLoginForm>
        </Container>
    )
}