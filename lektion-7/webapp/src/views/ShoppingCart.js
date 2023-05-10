import React, { useContext } from 'react'
import { ShoppingCartContext } from '../contexts/ShoppingCartContext'

const ShoppingCart = () => {
    const {state, dispatch} = useContext(ShoppingCartContext)

    return (
        <div>
            {
                state.items.map((item, index) => (
                    <div key={index}>
                        <div>{item.name} Quantity: {item.quanity}</div>
                        <div>
                            <button onClick={() => dispatch({ type: 'ADD_TO_CART', payload: item})} className="btn btn-outline-secondary">+</button>
                            <button onClick={() => dispatch({ type: 'REMOVE_FROM_CART', payload: item})} className="btn btn-outline-secondary">-</button>
                        </div>
                    </div>
                ))
            }
        </div>
    )
}

export default ShoppingCart