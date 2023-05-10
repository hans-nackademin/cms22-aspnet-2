import React, {useEffect} from 'react'

const Home = () => {
  useEffect(() => {
    
    getData()
  
  }, [])
  
  const getData = async () => {
    const result = await fetch('https://localhost:7188/api/users', {
      headers: {
        'Authorization': `bearer ${localStorage.getItem('accessToken')}`
      }
    })
    const data = await result.json()

    console.log(data)
  }


  return (
    <div>Home</div>
  )
}

export default Home