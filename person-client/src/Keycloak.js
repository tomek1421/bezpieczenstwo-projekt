import Keycloak from "keycloak-js";
const keycloak = new Keycloak({
 url: "http://localhost:8080",
 realm: "Test",
 clientId: "frontend-client",
});

export default keycloak;