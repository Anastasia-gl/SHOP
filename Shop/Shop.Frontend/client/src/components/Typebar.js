import { observer } from "mobx-react-lite";
import { useContext, useEffect } from "react";
import { ListGroup } from "react-bootstrap";
import { Context } from "..";
import { fetchCountType, fetchFilterDevice } from "../http/deviceAPI";

const Typebar = observer(() => {
    
    const { device } = useContext(Context);

    return (
        <ListGroup>
            {device.types.map(type =>
                <ListGroup.Item style={{ cursor: 'pointer' }}
                    active={type.typeId === device.filter.typeId}
                    onClick={(() => {
                        device.setFilter(type)
                        fetchFilterDevice(type.typeName).then(data => { device.setDevices(data) })
                        device.setActive(false)
                    }
                    )} key={type.id}>{type.typeName}
                </ListGroup.Item>
            )}
        </ListGroup>
    )
})

export default Typebar;