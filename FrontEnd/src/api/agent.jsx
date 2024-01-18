import axios from 'axios';
axios.defaults.baseURL= 'https://localhost:7201/api/';
const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url,body) => axios.post(url,body).then(responseBody),
    put: (url,body) => axios.put(url,body).then(responseBody),
    delete: (url) => axios.delete(url).then(responseBody),
};

const Identity = {
    login: (credentials) => requests.post('Identity/login', credentials),
    register: (user) => requests.post('Identity/register', user),
    forgot: (userEmail) => requests.get(`Identity/ForgotPassword?email=${userEmail}`),
    reset: (user) => requests.post('Identity/ResetPassword', user),
    changePassword: (passwordData) => requests.post('Identity/ChangePassword', passwordData),
};

const User = {
    getUserById: (userId) => requests.get(`UserManagment/GetUserById/${userId}`),
};


const agent = {
    Identity,
    User,
}

export default agent;
