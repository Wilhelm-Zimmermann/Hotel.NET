import styled from "styled-components";

export const StyledLoginForm = styled.form`
    position: absolute;
    top:0;
    bottom: 0;
    left: 0;
    right: 0;
    margin: auto;
    width: 41rem;
    height: 30rem;
    display: flex;
    justify-content: space-around;
    flex-direction: column;
    align-items:center;
    border: 1px solid black;
    padding: 2rem;
`;

export const StyledFormGroup = styled.div`
    width: 100%;

    label {
        width: 23%;
    }

    input {
        width: 70%;
        height: 3rem;
        padding-left: 1rem;
        border-radius: 0.3rem;
    }
`
