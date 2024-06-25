import React, { useState } from "react";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import keycloak from "./Keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Nav from "./components/Nav";
import WelcomePage from "./pages/Homepage";
import SecuredPage from "./pages/Securedpage";
import PrivateRoute from "./helpers/PrivateRoute";
import './App.css';

function App() {
  const [token, setToken] = useState("")

  return (
    <div>
      <ReactKeycloakProvider authClient={keycloak}>
        <Nav setToken={setToken} />
        <BrowserRouter>
          <Routes>
            <Route exact path="/" element={<WelcomePage token={token} />} />
            <Route
              path="/secured"
              element={
                <PrivateRoute>
                  <SecuredPage />
                </PrivateRoute>
              }
            />
          </Routes>
        </BrowserRouter>
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;