import React, { Fragment } from 'react';
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from 'react-router-dom';
import { Z_PARTIAL_FLUSH } from 'zlib';
import { HotelGuestForm } from './components/HotelGuestForm';
import { LoginForm } from './components/LoginForm';
import { isAuthenticated } from './services/auth';

interface Props {}
interface State {}

export const AppRouter: React.FC<Props> = () => {
  return (
    <Router>
        <Routes>
            <Route path="/Login" element={<LoginForm />}/>
            <Route path="*" element={
                <RequireAuth>
                    <Routes>
                        <Route path="" element={<HotelGuestForm />} />
                    </Routes>
                </RequireAuth>
            }/>
        </Routes>
    </Router>
  );
}

const PrivateRoute = ({children, ...rest}: any) => {
    return (
        <Routes>
            <Route {...rest}>
                {isAuthenticated ? children : <Navigate to='/login' />}
            </Route>
        </Routes>
    );
  };

const RequireAuth = ({ children }: any) => {
  
    if(!isAuthenticated)
        return <Navigate to="login" />;

    return children;
}