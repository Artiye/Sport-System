import React, { useEffect, useState } from "react";
import { Container, Row } from "reactstrap";
import agent from "../../api/agent";
import LinkForCreate from "../../components/LinkForCreate";
import TournamentItem from "../../components/TournementComponents/TournamentItem";
import PaginationComponent from "../../components/PaginationComponent";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const TournamentsByUser = () => {
  const [tournaments, setTournaments] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [page, setPage] = useState(1);
  const [perPage] = useState(4);
  const userId = localStorage.getItem("userId");
  const navigate = useNavigate();
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (!isLoggedIn) {
      navigate("/login");
    }
  }, [isLoggedIn, navigate]);

  const fetchTournaments = async () => {
    try {
      const response = await agent.Tournament.getTournamentsByUserId(userId);
      console.log("API Response:", response);
      setTournaments(response);
      setLoading(false);
    } catch (error) {
      console.error("API Error:", error);
      setError(error);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchTournaments();
  }, [userId]);

  const totalPages = Math.ceil(tournaments.length / perPage);
  const startIndex = (page - 1) * perPage;
  const endIndex = page * perPage;
  const displayedTournaments = tournaments.slice(startIndex, endIndex);

  const handlePageChange = (newPage) => {
    setPage(newPage);
    window.scrollTo(0,0);
  };

  if (error) {
    console.error('API Error:', error);
    return <div>Error: {error.message}</div>;
  }
  
  if (loading) {
    console.log('Loading...');
    return <div>Loading...</div>;
  }

  return (
    <>
      <section className="pb-5 pt-5">
        <Container style={{ width: "75%", paddingBottom:"40px"}}>
          <LinkForCreate title={"Create a new Tournament"} link={"/add-Tournament"} />
          <Row>
            {displayedTournaments && displayedTournaments.length > 0 ? (
              displayedTournaments.map((tournament) => (
                <TournamentItem key={tournament.id} tournament={tournament} />
              ))
            ) : (
              <div style={{textAlign:"center", margin:"60px 0px 125.5px 0px"}}>No tournaments available.</div>
            )}
          </Row>

        </Container>
        <PaginationComponent
          page={page}
          totalPages={totalPages}
          handlePageChange={handlePageChange}
        />
      </section>
    </>
  );
};

export default TournamentsByUser;
