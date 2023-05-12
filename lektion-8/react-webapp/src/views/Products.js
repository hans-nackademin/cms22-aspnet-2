import React, { useEffect } from 'react'
import { useProductContext } from '../contexts/ProductContext'
import { useCartContext } from '../contexts/CartContext'

const Products = () => {
    const {products, getProducts} = useProductContext()
    const {items, addItem, removeItem} = useCartContext()

    useEffect(() => {
        getProducts()
        console.log(items)
    }, [items])


    return (
        <div className="container mt-5">
            <div className="mb-5">
                <h1>CART</h1>
                {
                    items.length === 0 
                    ? <div>Cart is Empty</div>
                    : items.map(item => (
                        <div key={item.id}>
                            <div>{item.quantity} x {item.name}</div>
                            <div>
                                <button onClick={() => addItem(item)}>+</button>
                                <button onClick={() => removeItem(item)}>-</button>
                            </div>
                        </div>
                    ))
                }
            </div>


            <div>
                <h1>Products</h1>
                {
                    products.map(product => (
                        <div key={product.id} className="mb-5">
                            <div>{product.name}</div>
                            <div><button onClick={() => addItem(product)}>ADD TO CART</button></div>
                        </div>
                    ))
                }
            </div>
        </div>
    )
}

export default Products