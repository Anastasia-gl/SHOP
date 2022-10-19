import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Button, Card, Col, Container, Form, Image, ListGroup } from "react-bootstrap";
import { useParams } from "react-router-dom";
import { Context } from "..";
import { createBasket, fetchCharacterisric, fetchOneDevice } from "../http/deviceAPI";

const DevicePage = observer(() => {

    const { device } = useContext(Context);

    // get page by device id
    const { id } = useParams();

    //get patricular device
    const [devices, setDevice] = useState([]);

    //get characteristic according to device
    const [characteristic, setCharacteristic] = useState([]);

    useEffect(() => {
        fetchOneDevice(id).then(data => setDevice(data))
    }, [])

    useEffect(() => {
        fetchCharacterisric(id).then(data => setCharacteristic(data))
    }, [])

    return (
        <>
            <Container className=" d-flex mt-3">
                <Col md={4}>
                    <Image width={300} height={300} src={devices.photoUrl} />
                </Col>
                <Col md={5}>
                    <Form className="d-flex flex-column ">
                        <h2>{devices.name}</h2>
                        <p>{devices.decription}</p>
                    </Form>
                </Col>
                <Col md={3} >
                    <Card className="d-flex align-items-center justify-content-around" style={{ width: 300, height: 100 }}>
                        <h3>{devices.price} $</h3>
                        <Button onClick={(() =>{ createBasket(devices.id, device.basket.basketId)
                        })} variant={"outline-dark"}>Add To Basket</Button>
                    </Card>
                </Col>
            </Container>

            <Container className="mt-3">
                <Col md={5}>
                    <Card key={characteristic.characteristicId} className="mt-3" >
                        <Card.Body>
                            <ListGroup className="list-group-flush">
                                <ListGroup.Item style={{ fontWeight: 'bold' }}>Характеристика</ListGroup.Item>
                                <ListGroup.Item>Процесор: {characteristic.processorName}</ListGroup.Item>
                                <ListGroup.Item>Пам`ять: {characteristic.memory} ГБ</ListGroup.Item>
                                <ListGroup.Item>Діагональ екрану: {characteristic.screenDiagonal}</ListGroup.Item>
                            </ListGroup>
                        </Card.Body>
                    </Card>
                </Col>
            </Container>
        </>
    );
});

export default DevicePage;