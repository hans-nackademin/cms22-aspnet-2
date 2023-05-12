import React from 'react'
import { FacebookLoginButton, GoogleLoginButton } from 'react-social-login-buttons'
import { LoginSocialFacebook, LoginSocialGoogle } from 'reactjs-social-login'
import { useProfileContext } from '../contexts/ProfileContext'

const Login = () => {
  const {response, getResponse, handleResponse} = useProfileContext()


  return (
    <div className="container mt-5">
      <div>
        <LoginSocialFacebook appId="213572378085274" 
        onResolve={(res) => { 
          handleResponse(res)
          window.location.replace('/profile')
        }} 
        onReject={(error) => {
          console.log(error)
        }}>
          <FacebookLoginButton />
        </LoginSocialFacebook>
      </div>
      <div>
        <LoginSocialGoogle client_id="1052416593218-sld0dua6i9rah8re1bbqtr4saqceak7p.apps.googleusercontent.com"
          scope="openid profile"
          onResolve={(res) => {
            handleResponse(res)
            window.location.replace('/profile')
          }}
          onReject={(error) => {
            console.log(error)
          }}
          >
          <GoogleLoginButton />
        </LoginSocialGoogle>
      </div>
    </div>
  )
}

export default Login