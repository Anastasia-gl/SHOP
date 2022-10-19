import Auth from "./pages/Auth"
import Basket from "./pages/Basket"
import ConfirmOrder from "./pages/ConfirmOrder"
import DevicePage from "./pages/DevicePage"
import HistoryPage from "./pages/HistoryPage"
import Registration from "./pages/Registration"
import Shop from "./pages/Shop"
import { BASKET_ROUTE, DEVICE_ROUTE, HISTORY_ROUTE, LOGIN_ROUTE, ORDER_ROUTE, REGISTRATION_ROUTE, SHOP_ROUTE } from "./utils/consts"

export const authRoutes = [
    {
        path: BASKET_ROUTE,
        Component: <Basket />
    },
    {
        path: HISTORY_ROUTE,
        Component: <HistoryPage />
    },
    {
        path: ORDER_ROUTE,
        Component: <ConfirmOrder />
    }
]

export const publicRoutes = [
    {
        path: SHOP_ROUTE,
        Component: <Shop />
    },
    {
        path: LOGIN_ROUTE,
        Component: <Auth />
    },
    {
        path: REGISTRATION_ROUTE,
        Component: <Registration />
    },
    {
        path: DEVICE_ROUTE + '/:id',
        Component: <DevicePage />
    }
]