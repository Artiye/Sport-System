import React, { Fragment, useState } from "react";
import Header from "../components/Header";
import Footer from "../components/Footer";
import Routers from "./Routers";
import { UserContext } from '../pages/IdentityPages/UserContext';
import { isUserLoggedIn } from '../components/IdentityComponents/isUserLoggedIn';
import { ToastContainer } from 'react-toastify';
import "../styles/layout.css";

const Layout = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(isUserLoggedIn());
  const value = { isLoggedIn, setIsLoggedIn };

  return (
    <UserContext.Provider value={value}>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="dark"
      />     

      <Fragment>
        <div className="main-content">
          <Header />
          <Routers />
        </div>     
        <Footer />
      </Fragment>
    </UserContext.Provider>
  );
};

export default Layout;
