import React, {createContext, useReducer} from 'react';

export const ShoppingCartContext = createContext()

const initState = {
    items: []
}

const reducer = (state, action) => {
    let currentItems = [...state.items]
    let item

    switch (action.type) {
        case 'ADD_TO_CART':
            item = currentItems.find(i => i.id === action.payload.id)

            if (item)
                item.quantity++;
            else
                action.payload.quantity = 1;
                currentItems.push(action.payload)
            
            return { currentItems: currentItems }

        case 'REMOVE_FROM_CART':
            item = currentItems.find(i => i.id === action.payload.id)

            if (item.quantity > 1)
                item.quantity--
            else
            currentItems.filter(i => i.id !== action.payload.id)
        
            return { currentItems: currentItems }

        default:
            return state
    }
}

export const ShoppingCartProvider =({children}) => {
    const [state, dispatch] = useReducer(reducer, initState)

    return (
        <ShoppingCartContext.Provider value={{ state, dispatch}}>
            {children}
        </ShoppingCartContext.Provider>
    )
}
