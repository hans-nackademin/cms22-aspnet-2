import { createContext, useContext, useState } from "react"

const CartContext = createContext();
export const useCartContext = () => {
    return useContext(CartContext)
}

const initalState = {
    items: [],
    totalQuantity: 0,
    totalAmount: 0
}

export const CartProvider = ({children}) => {
    const [items, setItems] = useState(initalState.items)

    const addItem = (product) => {
        let _item = items.find(item => item.id === product.id)        
        if (_item)
            setItems(items.map(item => 
                item.id === _item.id 
                ? {...item, quantity: item.quantity + 1} 
                : item
            ))
        else
            setItems([...items, {id: product.id, name: product.name, quantity: 1}])
    }

    const removeItem = (product) => {
        let _item = items.find(item => item.id === product.id)

        if (_item.quantity > 1)
            setItems(items.map(item => 
                item.id === _item.id 
                ? {...item, quantity: item.quantity - 1} 
                : item
            ))
        else {
            const itemList = items.filter(item => item.id !== _item.id)
            console.log(itemList)
            setItems(itemList)   
        }
            
             
    }

    return <CartContext.Provider value={ { items, addItem, removeItem } }>
        {children}
    </CartContext.Provider>
}
