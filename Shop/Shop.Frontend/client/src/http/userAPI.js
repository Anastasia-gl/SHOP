import { $authHost, $host } from "./index";
import jwt_decode from "jwt-decode";
import axios from "axios";
import { json } from "react-router-dom";
import Cookies from 'js-cookie'

export const registration = async (registerUser) => {
  const data = await fetch('http://localhost:7213/Auth/register-user', {
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include',
    body: JSON.stringify(registerUser)
  })

  return data
}

export const login = async (loginUser) => {
  const data = await fetch('http://localhost:7213/Auth/login-user', {
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include',
    body: JSON.stringify(loginUser)
  })

  return data
}

export const getUser = async () => {
  const data = await fetch('http://localhost:7213/Auth/get-user', {
    method: "GET",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include'
  })
  const response = data.json();

  return response;
}

export const logout = async () => {
 const data = await fetch('http://localhost:7213/Auth/logout-user', {
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include'
  })

  const response = await data.json();
  
  return response
}

export const getJwt = async () => {
  const data = await fetch('http://localhost:7213/Auth/get-jwt', {
    method: "GET",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include'
  })
  const response = await data.json();

  return response;
}


export const getCheckedFlag = async (jwt) => {
  const data = await fetch(`http://localhost:7213/Auth/check-token/${jwt}`, {
    method: "GET",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    credentials: 'include'
  })
  const response = data.json();

  return response;
}

