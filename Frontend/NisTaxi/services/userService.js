import axios from "axios";

export function getUserById(userId, setUser) {
    axios.get('https://fe9b-77-243-22-101.ngrok.io/api/Driver/' + 1)
    .then((response) => {
        setUser(response.data);
    })
    .catch((error) => {
        console.log(error);
    });
}