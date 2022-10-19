import { observer } from "mobx-react-lite";
import { useContext, useEffect } from "react";
import { Card, Col, Container, ListGroup, Row } from "react-bootstrap";
import { Context } from "..";
import { fetchHistory } from "../http/deviceAPI";


const HistoryPage = observer(() => {

    const { device } = useContext(Context);

    useEffect(() => {
        fetchHistory(device.basket.basketId).then(data => device.setHistory(data))
    }, [device.history.length])

    return (
        <>
            {
                device.history.length != 0 ?
                    <Container className="d-flex mt-3  ">
                        <Row >
                            {
                                device.history.map((item) =>

                                    <Col key={item.historyId} md={6}>
                                        <Card
                                            variant='Light'
                                            style={{ width: '18rem' }}
                                            className="mb-2"
                                        >
                                            <Card.Header>Номер замовлення: {item.historyId}</Card.Header>
                                            <Card.Body>
                                                <ListGroup>
                                                <ListGroup.Item>{item.orderDate} </ListGroup.Item>
                                                <ListGroup.Item>Замовник: {item.firstName} {item.lastName} </ListGroup.Item>
                                                <ListGroup.Item>Телефон: {item.telephone} </ListGroup.Item>
                                                <ListGroup.Item>Адреса: {item.address}</ListGroup.Item>
                                                <ListGroup.Item>Статус: сплачено</ListGroup.Item>
                                                </ListGroup>
                                            </Card.Body>
                                        </Card>
                                    </Col>
                                )
                            }
                        </Row>
                    </Container>
                    :
                    <span className="d-flex mt-3 justify-content-center align-items-center">
                        <h5>There are no orders yet</h5>
                    </span>
            }
        </>
    );
});

export default HistoryPage;