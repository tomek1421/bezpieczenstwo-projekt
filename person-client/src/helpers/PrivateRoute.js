import { useKeycloak } from "@react-keycloak/web";

const PrivateRoute = ({ children }) => {
 const { keycloak } = useKeycloak();

 const isLoggedIn = keycloak.authenticated;

 return isLoggedIn && keycloak.hasResourceRole("admin", "api-client") ? children : <h1>not authenticated to visit secured page</h1>;
};

export default PrivateRoute;