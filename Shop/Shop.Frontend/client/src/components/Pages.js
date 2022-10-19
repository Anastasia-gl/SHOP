import { observer } from "mobx-react-lite";
import { useContext } from "react";
import { Pagination } from "react-bootstrap";
import { Context } from "..";

const Pages = observer(() => {

    const { device } = useContext(Context);
    const pagesCount = Math.ceil(device.totalCount / 8)
    const pages = []

    for(let i = 0; i < pagesCount-1; i++){
       pages.push(i+1);
    }

    return (
        <Pagination className="mt-5 d-flex justify-content-center align-items-center">
            {pages.map(page =>
                <Pagination.Item
                key={page}
                active={device.page === page}
                onClick={()=> device.setPage(page)}
                >{page}</Pagination.Item>
            )}
        </Pagination>
    )

})

export default Pages;