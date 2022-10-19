import { observer } from 'mobx-react-lite';
import { useContext } from 'react';
import { Route, Routes } from 'react-router-dom'
import { Context } from '..';
import { authRoutes, publicRoutes } from '../routes';

const AppRouter = observer(() => {

    const { user } = useContext(Context);

    return (
        <Routes>
            {user.isAuth === true && authRoutes.map(({ path, Component }) =>
                <Route key={path} path={path} exact element={Component} />
            )}

            {publicRoutes.map(({ path, Component }) =>
                <Route key={path} path={path} exact element={Component} />
            )}
        </Routes>
    );
});

export default AppRouter;