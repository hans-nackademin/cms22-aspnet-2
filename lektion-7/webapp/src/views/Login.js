import React, { useState } from 'react'

const Login = () => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('')

    const handleSubmit = async (e) => {
        e.preventDefault()
        setError('')


        const result = await fetch('https://localhost:7188/api/authentication/login', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        })
        
        if (result.status === 200) {
            const token = await result.text()
            localStorage.setItem('accessToken', token)

            window.location.replace('/')
        
        } 

        if (result.status === 400) {
            const data = await result.json()
            setError(data.title)
        }
         
        if (result.status === 401) {
            const data = await result.text()
            setError(data)
        } 

    }


    return (
        <div className="d-flex justify-content-center align-items-center vh-100">
            <form onSubmit={handleSubmit} className="card shadow col-11 col-lg-4" noValidate>
                <div className="card-body px-5 py-4">
                    <div className="mb-3 small text-danger text-center">
                        {error}
                    </div>  

                    <div className="mb-3">
                        <label className="form-label">E-mail</label>
                        <input value={email} onChange={(e) => setEmail(e.target.value)} type="email" className="form-control" />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Password</label>
                        <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" className="form-control" />
                    </div>
                    <div className="d-grid mt-4 mb-3">
                        <button className="btn btn-secondary py-2">SUBMIT</button>
                    </div>
                </div>
            </form>
        </div>
    )
}

export default Login