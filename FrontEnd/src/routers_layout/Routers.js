import React, { useEffect } from "react";
import { Routes, Route, useNavigate  } from "react-router-dom";
import NotFound from "../pages/NotFound";
import Login from "../pages/IdentityPages/LogIn";
import Register from "../pages/IdentityPages/Register";
import ForgotPassword from "../pages/IdentityPages/ForgotPassword";
import ResetPassword from "../pages/IdentityPages/ResetPassword";
import MyTeams from "../pages/TeamPages/MyTeams";
import TeamDetails from "../pages/TeamPages/TeamDetails";
import AddTeam from "../pages/TeamPages/AddTeam"; 
import AllTeams from "../pages/TeamPages/AllTeams";
import AddTournament from "../pages/TournamentPages/AddTournament";
import TournamentDetails from "../pages/TournamentPages/TournamentDetails";
import TournamentsList from "../pages/TournamentPages/TournamentsList";
import TournamentsByUser from "../pages/TournamentPages/TournamentsByUser";

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
      <Route path="/my-teams" element={<MyTeams />} />
      <Route path="/teams/:teamId" element={<TeamDetails />} />
      <Route path="/add-team" element={<AddTeam />} />
      <Route path="/all-teams" element={<AllTeams />} />
      <Route path="/my-tournaments" element={<TournamentsByUser />} />
      <Route path="/tournaments" element={<TournamentsList />} />
      <Route path="/add-tournament" element={<AddTournament />} />
      <Route path="/tournament/:tournamentId" element={<TournamentDetails />} />
    </Routes>
  );
};

export default Routers;