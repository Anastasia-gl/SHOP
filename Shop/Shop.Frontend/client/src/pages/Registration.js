import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Button, Card, Container, Form, FormLabel } from "react-bootstrap";
import { NavLink, useLocation, useNavigate } from "react-router-dom";
import { Context } from "..";
import { registration, login, getUser } from "../http/userAPI";
import { REGISTRATION_ROUTE, LOGIN_ROUTE, SHOP_ROUTE } from '../utils/consts'

const Registration = observer(() => {

    // set a navigation
    const navigate = useNavigate();

    //set id of a logged user
    const { user } = useContext(Context);

    //check location
    const location = useLocation();
    const isLogin = location.pathname === LOGIN_ROUTE;

    //set credential
    const [name, setName] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    //create an object of a logged user
    const loginUser = { name: name, email: email, password: password }

    //sign in
    const register = async (e) => {
        try {
            const data = await registration(loginUser);

            const userId = await getUser();
            user.setUser(userId)

            if (data.status === 200) {
                user.setIsAuth(false);
                navigate(LOGIN_ROUTE);
            }
        }
        catch {
            alert('Error')
        }
    }

    return (
        <Container className="d-flex justify-content-center align-items-center"
            style={{ height: window.innerHeight - 54 }} >
            <Card style={{ width: 600 }} className="p-5">
                <h2 className="m-auto">{isLogin ? 'Authoriation' : 'Registration'}</h2>
                <Form className="d-flex flex-column">
                    <Form.Control className="mt-2" placeholder="Enter name" value={name} onChange={e => setName(e.target.value)} />
                    <Form.Control className="mt-2" placeholder="Enter email" value={email} onChange={e => setEmail(e.target.value)} />
                    <Form.Control className="mt-2" placeholder="Enter password" value={password} onChange={e => setPassword(e.target.value)} type="password" />

                    <Button className="mt-3" variant={"outline-dark"} onClick={register}>{isLogin ? 'Login' : 'Register'}</Button>
                    {isLogin ? <div className="mt-3 m-auto">If you are not registered <NavLink to={REGISTRATION_ROUTE}> Registration</NavLink></div>
                        :
                        <div className="mt-3 m-auto">Have already registered?<NavLink to={LOGIN_ROUTE}> Login</NavLink></div>}
                </Form>
            </Card>
        </Container>
    );
});

export default Registration;