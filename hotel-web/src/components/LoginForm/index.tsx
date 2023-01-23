import { Container } from "react-bootstrap"
import { api } from "../../services/api";
import { useState, FormEvent } from "react";
import { StyledFormGroup, StyledLoginForm } from "./styles";

interface LoginFormData{
    email: string;
    password: string;
}

export const LoginForm = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const loginForm = async (e: FormEvent) => {
        e.preventDefault();

        const userFormData = {
            name: email,
            password
        }

        console.log(userFormData)
        const {data} = await api.post("/users/create", userFormData);

        console.log(data)
    }

    return(
        <Container>
            <StyledLoginForm onSubmit={loginForm}>
                <StyledFormGroup>
                    <label>Email Address</label>
                    <input type="email" value={email} placeholder="name@example.com" onChange={e => setEmail(e.target.value)}/>
                </StyledFormGroup>
                <StyledFormGroup>
                    <label>Password</label>
                    <input type="email" value={password} placeholder="name@example.com" onChange={e => setPassword(e.target.value)}/>
                </StyledFormGroup>
                <StyledFormGroup>
                    <button type="submit">Send</button>
                </StyledFormGroup>
            </StyledLoginForm>
        </Container>
    )
}