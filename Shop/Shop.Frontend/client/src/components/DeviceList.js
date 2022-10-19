import { observer } from "mobx-react-lite";
import { useContext } from "react";
import { Row } from "react-bootstrap";
import { Context } from "..";
import DeviceItem from "./DeviceItem";

const DeviceList = observer(() => {

    const { device } = useContext(Context);

    return (
        <Row className="d-flex justify-content-around">
            {device.devices.map(item =>
                <DeviceItem key={item.id} item={item} />
            )}
        </Row>
    );
});

export default DeviceList;
