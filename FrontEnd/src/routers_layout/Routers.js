import React, { useEffect } from "react";
import { Routes, Route, useNavigate  } from "react-router-dom";
import NotFound from "../pages/NotFound";
import Login from "../pages/IdentityPages/LogIn";
import Register from "../pages/IdentityPages/Register";
import ForgotPassword from "../pages/IdentityPages/ForgotPassword";
import ResetPassword from "../pages/IdentityPages/ResetPassword";

const Routers = () => {
  const navigate = useNavigate();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [navigate]);

  return (
    <Routes>   
      <Route path="*" element={<NotFound />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/forgot-password" element={<ForgotPassword />} />
      <Route path="/ResetPassword/:email/:token" element={<ResetPassword />} />
    </Routes>
  );
};

export default Routers;