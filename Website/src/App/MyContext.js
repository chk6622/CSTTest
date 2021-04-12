import React, { useReducer, createContext } from 'react';
import './App.css';
import AppReducer from './AppReducer';



export const AppContext = createContext({});

const InitState = {
    FullName: '',
    PhoneNumber: '',
    Email: '',
    VerificationCode: '',
}

const MyContext = props => {

    const [userInformation, dispatch] = useReducer(AppReducer, InitState);

    return (
        <AppContext.Provider value={{ userInformation, dispatch }}>
            {props.children}
        </AppContext.Provider>
    )
}

export default MyContext;



