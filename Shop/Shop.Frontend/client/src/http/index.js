import axios from "axios";

const $host = axios.create({
    baseURL: 'http://localhost:7213'
})

export {
    $host
}