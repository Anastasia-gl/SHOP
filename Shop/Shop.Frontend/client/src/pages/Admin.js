import { useState } from "react";
import { Button, Container } from "react-bootstrap";
import CreateType from "../components/models/CreateType";
import { AiOutlineClose } from 'react-icons/ai';
import CreateDevice from "../components/models/CreateDevice";

const Admin = () => {

    const [isActiveType, setIsActiveType] = useState(false);
    const [isActiveDevice, setIsActiveDevice] = useState(false);

    return (
        <Container className="d-flex flex-column">

            <Button active={isActiveType} onClick={() => setIsActiveType(true)} variant={"outline-dark"} className="mt-4">Add Type</Button>
            {
                isActiveType &&
                <div>
                    <div className="mt-2 center center" style={{ marginLeft: "12px" }} >
                        <Button onClick={() => setIsActiveType(false)} variant={"outline-danger"}><AiOutlineClose /></Button>
                    </div>
                    <CreateType />
                </div>
            }

            <Button active={isActiveDevice} onClick={() => setIsActiveDevice(true)} variant={"outline-dark"} className="mt-4">Add Device</Button>
            {
                isActiveDevice &&
                <div>
                    <div className="mt-2 center center" style={{ marginLeft: "12px" }} >
                        <Button onClick={() => setIsActiveDevice(false)} variant={"outline-danger"}><AiOutlineClose /></Button>
                    </div>
                    <CreateDevice />
                </div>
            }
        </Container>
    );
};

export default Admin;