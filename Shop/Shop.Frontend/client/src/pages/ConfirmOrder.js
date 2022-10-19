import { useContext, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { Context } from "..";
import { createHistory } from "../http/deviceAPI";
import { SHOP_ROUTE } from "../utils/consts";

const ConfirmOrder = () => {
const {device} = useContext(Context);
const navigation = useNavigate();

const [firstName, setfirstName] = useState('')
const [lastName, setLastName] = useState('')
const [telephone, setTelephone] = useState('')
const [address, setAddress] = useState('')

const historyDto = {firstName: firstName, lastName: lastName, telephone: telephone, address: address}

    return (

        <Container className="d-flex mt-3 justify-content-center align-items-center" >
        <Form className="d-flex flex-column" style={{width: 400}}>         
            <Form.Control className="mt-2" placeholder="Enter first name"  value={firstName} onChange={e => setfirstName(e.target.value)}/>
            <Form.Control className="mt-2" placeholder="Enter last name" value={lastName} onChange={e => setLastName(e.target.value)} />
            <Form.Control className="mt-2" placeholder="Enter telephone"  value={telephone} onChange={e => setTelephone(e.target.value)} />
            <Form.Control className="mt-2" placeholder="Enter address"  value={address} onChange={e => setAddress(e.target.value)}/>
            <p className="mt-2" style={{marginLeft: 300, fontFamily:'inherit'}}>Price: {device.price}$</p>
            <Button onClick={(()=> {
                createHistory(device.basket.basketId, historyDto)
                alert("Successful")
                navigation(SHOP_ROUTE);
            })} className="mt-3" variant={"outline-dark"} >Оформити замовлення</Button>
        </Form>
                
        </Container>
    )

}

export default ConfirmOrder;