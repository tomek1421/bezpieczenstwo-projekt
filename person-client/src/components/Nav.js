import React, { useState } from "react";
import { useKeycloak } from "@react-keycloak/web";
import axios from 'axios';

const Nav = () => {
  const { keycloak } = useKeycloak();

  const [posts, setPosts] = useState([]);
  const [error, setError] = useState("");
  
  const headers = {
    'Authorization': `Bearer ${keycloak.token}`,
    'Content-Type': 'application/json'
  };

  function handlePosts() {
    axios.get("http://localhost:4001/people", {headers: headers})
    .then(msg => {setPosts(msg.data); setError("")})
    .catch(err => {console.log(err); setError("- not authenticated to get people")});
  }

  return (
    <div className="nav">
      <div className="top-0 w-full flex flex-wrap">
        <section className="x-auto">
          <nav className="flex justify-between bg-gray-200 text-blue-800 w-screen">
            <div className="px-5 xl:px-12 py-6 flex w-full items-center">
              <h1 className="text-3xl font-bold font-heading">
                Keycloak React AUTH.
              </h1>
              <ul className="hidden md:flex px-4 mx-auto font-semibold font-heading space-x-12">
                <li>
                  <a className="hover:text-blue-800" href="/">
                    Home
                  </a>
                </li>
                <li>
                  <a className="hover:text-blue-800" href="/secured">
                    Admin panel
                  </a>
                </li>
              </ul>
              <div className="hidden xl:flex items-center space-x-5">
                <div className="hover:text-gray-200">
                  {!keycloak.authenticated && (
                    <button
                      type="button"
                      className="text-blue-800"
                      onClick={() => keycloak.login()}
                    >
                      Login
                    </button>
                  )}

                  {!!keycloak.authenticated && (
                    <button
                      type="button"
                      className="text-blue-800"
                      onClick={() => keycloak.logout()}
                    >
                      Logout ({keycloak.tokenParsed.preferred_username})
                    </button>
                  )}
                    < br/>
                    <div className="field">
                      <span style={{fontWeight: 700}}>role: </span>
                      { keycloak.hasResourceRole("admin", "api-client") ? "admin" : keycloak.hasResourceRole("user", "api-client") ? "user" : "not authenticated" }
                    </div>
                    < br/>
                    <button onClick={ handlePosts } >show people</button>
                    {error}
                    {
                      posts.map(post => {
                        return (
                          <div className="field" >
                            <div><span style={{fontWeight: 700}}>id: </span>{post.id}</div>
                            <div><span style={{fontWeight: 700}}>name: </span> {post.name}</div>
                            {keycloak.hasResourceRole("admin", "api-client") && <div><span style={{fontWeight: 700}}>age: </span> {post.age}</div>}
                          </div>
                        )
                      })
                    }
                </div>
              </div>
            </div>
          </nav>
        </section>
      </div>
    </div>
  );
};

export default Nav;