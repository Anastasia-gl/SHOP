import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Button, Card, Container, Form, FormLabel } from "react-bootstrap";
import { NavLink, useLocation, useNavigate } from "react-router-dom";
import { Context } from "..";
import { fetchGetJwt } from "../http/deviceAPI";
import { login, getUser, getJwt, getCheckedFlag } from "../http/userAPI";
import { REGISTRATION_ROUTE, LOGIN_ROUTE, SHOP_ROUTE } from '../utils/consts'

const Auth = observer(() => {

    // set a navigation
    const navigate = useNavigate();

    //set id of a logged user
    const { user } = useContext(Context);

    //check location
    const location = useLocation();
    const isLogin = location.pathname === LOGIN_ROUTE;

    //set credential 
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    //create an object of a logged user
    const loginUser = { email: email, password: password }

    //sign in
    const signIn = async () => {
        try {
            const data = await login(loginUser);
            const userId = await getUser();

            user.setUser(userId)
            if (data.status === 200) {
                const jwt = await getJwt();
                const flag = await getCheckedFlag(jwt);
                user.setIsAuth(flag);
                navigate(SHOP_ROUTE);
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
                    <Form.Control className="mt-2" placeholder="Enter email" value={email} onChange={e => setEmail(e.target.value)} />
                    <Form.Control className="mt-2" placeholder="Enter password" value={password} onChange={e => setPassword(e.target.value)} type="password" />

                    <Button className="mt-3" variant={"outline-dark"} onClick={signIn}>{isLogin ? 'Login' : 'Register'}</Button>
                    {isLogin ? <div className="mt-3 m-auto">If you are not registered <NavLink to={REGISTRATION_ROUTE}> Registration</NavLink></div>
                        :
                        <div className="mt-3 m-auto">Have already registered?<NavLink to={LOGIN_ROUTE}> Login</NavLink></div>}
                </Form>
            </Card>
        </Container>
    );
});

export default Auth;