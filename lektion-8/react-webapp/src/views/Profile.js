import React, { useEffect } from 'react'
import { useProfileContext } from '../contexts/ProfileContext'


const Profile = () => {
  const {profile, provider, getProfile, getProvider} = useProfileContext()
  let imageUrl


  useEffect(() => {
    getProfile()
    getProvider()
    imageUrl = profile.picture
    console.log(imageUrl)
  }, [])

  return (
    <div>

      <div>{profile.name}</div>
    </div>
  )
}

export default Profile