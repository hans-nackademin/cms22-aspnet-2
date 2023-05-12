import { createContext, useContext, useState } from "react"

const ProductContext = createContext();
export const useProductContext = () => {
    return useContext(ProductContext)
}

export const ProductProvider = ({children}) => {
    const [products, setProducts] = useState([])

    const getProducts = async () => {
        const result = await fetch('https://localhost:7009/api/products')
        // console.log(await result.json())
        setProducts(await result.json())
    }

    return <ProductContext.Provider value={ { products, getProducts } }>
        {children}
    </ProductContext.Provider>
}
