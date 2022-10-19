import { useContext, useEffect } from "react";
import { Button, Card, Col, Container, Row } from "react-bootstrap";
import { Context } from "..";
import { createHistory, deleteBasket, fetchBasket, fetchItemFromBasket, fetchListProductBasket } from "../http/deviceAPI";
import { MdDeleteForever } from 'react-icons/md';
import { observer } from "mobx-react-lite";
import { useNavigate } from "react-router-dom";
import { DEVICE_ROUTE, ORDER_ROUTE } from "../utils/consts";
import ConfirmOrder from "./ConfirmOrder";

const Basket = observer(() => {

    const { device, user } = useContext(Context);
    const navigate = useNavigate();


    const getFinalPrice = () => {
        let sum = 0;
        device.productBasket.map((product) => {
            console.log(sum);
            sum += product.totalPrice;
        })
        return sum;
    }

    useEffect(() => {
        fetchListProductBasket(device.basket.basketId).then(data => device.setProductBasket(data))
        console.log(device.productBasket);
    }, [device.productBasket])


    useEffect(() => {
        fetchBasket(user.user).then(data => device.setBasket(data))
    }, [])


    useEffect(() => {
        fetchItemFromBasket(device.basket.basketId).then(data => device.setItemBasket(data))
    }, [device.basket.basketId, device.itemBasket])

    return (
        <>
            <Container>
                {
                    device.itemBasket.map((item) =>
                        <Card className="mt-3" style={{ maxWidth: window }}> <Row className="g-0">
                            <Col md={2}>
                                <Card.Img className="mt-2" onClick={() => navigate(DEVICE_ROUTE + '/' + item.id)} src={item.photoUrl} />
                            </Col>
                            <Col md={8}>
                                <Card.Body onClick={() => navigate(DEVICE_ROUTE + '/' + item.id)}>
                                    <Card.Title>{item.name}</Card.Title>
                                    <Card.Text>
                                        {item.decription}
                                    </Card.Text>
                                </Card.Body>
                            </Col>
                            <Col md={2} className="mt-3">
                                <Card.Title>{item.price} $</Card.Title>
                                <Button
                                    onClick={(() => {
                                        deleteBasket(item.id, device.basket.basketId)
                                    })}
                                    className="center center" variant="outline-danger" style={{ marginLeft: 10 }}><MdDeleteForever /></Button>
                            </Col>
                        </Row>
                        </Card>
                    )
                }
                {
                    device.itemBasket.length != 0 ? < Button onClick={(() => {
                     navigate(ORDER_ROUTE);
                     device.setPrice(getFinalPrice());
                    })} className="mt-3" style={{ float: 'right' }} variant="outline-success">Cплатити: {getFinalPrice()} $</Button>
                        : <span className="d-flex mt-3 justify-content-center align-items-center">
                            <h5>The basket is empty</h5>
                        </span>
                }

            </Container>
        </>
    );
});

export default Basket;