import { Card, Col, Image } from "react-bootstrap";
import { FiMoreVertical } from 'react-icons/fi'
import { useNavigate } from "react-router-dom";
import { DEVICE_ROUTE } from "../utils/consts";

const DeviceItem = (props) => {

    const navigation = useNavigate();

    return (
        <>
            <Col md={3} className="mt-2" onClick={() => navigation(DEVICE_ROUTE + '/' + props.item.id)}>
                <Card style={{ width: 150, cursor: 'pointer' }} border={"light"}>
                    <Image width={150} height={150} src={props.item.photoUrl} />
                    <div className="mt-1" >
                        <div className="d-flex justify-content-between align-items-center">
                            <div>{props.item.name}</div>
                            <FiMoreVertical />
                        </div>
                        <div style={{ fontWeight: 'bold' }}>{props.item.price} $</div>
                    </div>
                </Card>
            </Col>
        </>
    )
}

export default DeviceItem;