import {createContext, useState, FC, useReducer} from 'react'

interface EmployeeContextProps {

}

// function reducer(state, action){
    
// }


export const EmployeeContext = createContext<{} | null>({});

// const [state, dispatch] = useReducer(reducer, 0)


export const EmployeeContextProvider: FC = ({children}) => {
        return (
            <EmployeeContext.Provider value={{}}>

            </EmployeeContext.Provider>
        );
}

