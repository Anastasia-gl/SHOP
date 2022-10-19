import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import { Context } from "..";
import DeviceList from "../components/DeviceList";
import Typebar from "../components/Typebar";
import { fetchDevices, fetchTypes, fetchSortedDevice, fetchCountProduct } from "../http/deviceAPI";
import { BsSortUp } from 'react-icons/bs';
import Pages from "../components/Pages";


const Shop = observer(() => {

    const { device } = useContext(Context);

    // get types for typebar && list of devices with pages && set a selected type 
    useEffect(() => {
        fetchTypes().then(data => device.setTypes(data))
    }, [])

    useEffect(() => {
        fetchCountProduct().then(data=>device.setTotalCount(data))
        fetchDevices(device.page, 12).then(data => {device.setDevices(data)})
    }, [device.page])

    useEffect(() => {
        fetchDevices(device.selectedType.id).then(data => {
            device.setDevices(data)
        })
    }, [device.selectedType.id])

    return (
        <Container>
            <Row className="mt-2">
                <Col md={3}>
                    <Typebar />
                </Col>
                <Col md={1}>
                    <Button onClick={() =>
                        fetchSortedDevice(device.page, 12).then(data => { device.setDevices(data) })} variant={"outline-dark"}><BsSortUp /></Button>
                </Col>
                <Col md={8}>
                    <DeviceList />
                    {
                        device.active === true &&  <Pages />
                    }
                </Col>

            </Row>

        </Container>
    );
});

export default Shop;