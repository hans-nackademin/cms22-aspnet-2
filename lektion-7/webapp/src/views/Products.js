import React, { useState, useEffect, useContext } from 'react'
import { ShoppingCartContext } from '../contexts/ShoppingCartContext'

const Products = () => {
    const {dispatch} = useContext(ShoppingCartContext)
    const [products, setProducts] = useState([])
    
    const getProducts = async () => {
        const result = await fetch('https://localhost:7188/api/products')
        const data = await result.json()
        setProducts(data)
    }
    
    useEffect(() => {
        getProducts()
    }, [])
    
    return (
        <div>
            {
                products.map(product => (
                    <div key={product.id}>
                        <div>{product.id} {product.name}</div>
                        <button onClick={() => dispatch({ type: 'ADD_TO_CART', payload: product})} className="btn btn-success">ADD TO CART</button>
                    </div>
                ))
            }
        </div>
    )
}

export default Products