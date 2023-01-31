const tokenKey = "@User";

export const isAuthenticated = () => localStorage.getItem(tokenKey) != null;
export const getToken = (): string => localStorage.getItem(tokenKey);
export const login = (token: string): void => localStorage.setItem(tokenKey, token);
export const logout = (): void => localStorage.removeItem(tokenKey);