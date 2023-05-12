import { createContext, useContext, useState } from "react"

const ProfileContext = createContext();

export const useProfileContext = () => {
    return useContext(ProfileContext)
}

export const ProfileProvider = ({children}) => {
    const [profile, setProfile] = useState({})
    const [provider, setProvider] = useState({})

    const handleResponse = (res) => {
        sessionStorage.setItem('profile', JSON.stringify(res.data))
        sessionStorage.setItem('provider', JSON.stringify(res.provider))
    }

    const getProfile = () => {
        setProfile(JSON.parse(sessionStorage.getItem('profile')))
    }
    const getProvider = () => {
        setProvider(JSON.parse(sessionStorage.getItem('provider')))
    }

    return <ProfileContext.Provider value={ { handleResponse, getProfile, getProvider, profile, provider } }>
        {children}
    </ProfileContext.Provider>
}
