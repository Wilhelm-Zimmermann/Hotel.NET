export interface GenericResult {
    message: string;
    success: boolean;
    data: object;
}

export interface LoginResult {
    message: string;
    success: boolean;
    data: {token: string};
}