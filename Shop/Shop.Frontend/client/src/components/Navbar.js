import { useContext, useEffect } from "react";
import { Context } from "..";
import { Navbar, Container, Nav } from 'react-bootstrap'
import { NavLink, useNavigate } from "react-router-dom";
import { ADMIN_ROUTE, BASKET_ROUTE, HISTORY_ROUTE, LOGIN_ROUTE, REGISTRATION_ROUTE, SHOP_ROUTE } from '../utils/consts'
import { observer } from "mobx-react-lite";
import { SiElectron } from 'react-icons/si';
import { fetchDevices } from "../http/deviceAPI";
import { logout } from "../http/userAPI";
import { MdDialerSip } from "react-icons/md";

const NavBar = observer(() => {

    const { user, device } = useContext(Context);
    const navigate = useNavigate();

    const click = async () => {
        const flag = await logout();
        navigate(LOGIN_ROUTE)
        user.setIsAuth(flag);
        user.setUser(null)
    }

    return (
        <>
            <Navbar bg="dark" variant="dark" style={{ display: 'block' }}>
                <Container>
                    <NavLink onClick={(() => {
                        fetchDevices(device.page, 12).then(data => device.setDevices(data))
                        device.setActive(true);
                    })} style={{ color: 'white', textDecorationLine: 'none' }} to={SHOP_ROUTE}>
                        <div className="d-flex align-items-center">
                            <SiElectron className="me-2" /> Electro
                            <Nav
                                activeKey="/home"
                                onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}>
                                <Nav.Item style={{ marginLeft: 10 }}>
                                    <Nav.Link onClick={() => {
                                        if (user.isAuth === true) {
                                            navigate(BASKET_ROUTE)
                                        } else {
                                            navigate(LOGIN_ROUTE)
                                        }
                                    }}>Basket</Nav.Link>
                                </Nav.Item>
                                {user.isAuth === true &&
                                    <Nav.Item style={{ marginLeft: 10 }}>
                                        <Nav.Link onClick={() => {
                                            if (user.isAuth === true) {
                                                navigate(HISTORY_ROUTE)
                                            } else {
                                                navigate(LOGIN_ROUTE)
                                            }
                                        }}>History</Nav.Link>
                                    </Nav.Item>
                                }
                            </Nav>
                        </div>
                    </NavLink>
                    {user.isAuth === true ?
                        <Nav className="ml-auto" >
                            <Nav.Item>
                                <Nav.Link onClick={click}>Logout</Nav.Link>
                            </Nav.Item>
                        </Nav>
                        :
                        <Nav className="ml-auto"  >
                            <Nav.Item>
                                <Nav.Link onClick={() => navigate(REGISTRATION_ROUTE)}>Register</Nav.Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Nav.Link onClick={() => navigate(LOGIN_ROUTE)}>Login</Nav.Link>
                            </Nav.Item>
                        </Nav>
                    }
                </Container>
            </Navbar>
        </>
    );
});

export default NavBar;