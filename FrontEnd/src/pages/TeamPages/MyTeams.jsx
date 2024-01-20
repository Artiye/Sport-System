import React, { useEffect, useState } from "react";
import { Container, Row } from "reactstrap";
import { useNavigate } from "react-router-dom";
import agent from "../../api/agent";
import TeamItem from "../../components/TeamComponents/TeamItem";
import LinkForCreate from "../../components/LinkForCreate";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";
import PaginationComponent from "../../components/PaginationComponent";

const MyTeams = () => {
  const [ownTeams, setOwnTeams] = useState([]);
  const [teamsIParticipateIn, setTeamsIParticipateIn] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [page, setPage] = useState(1);
  const [perPage] = useState(6);
  const navigate = useNavigate();
  const userId = localStorage.getItem("userId");
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (!isLoggedIn) {
      navigate("/login");
    }
  }, [isLoggedIn, navigate]);

  const fetchOwnTeams = async () => {
    try {
      const response = await agent.Team.getTeamsByUserId(userId);
      setOwnTeams(response);
    } catch (error) {
      console.error("API Error:", error);
      setError(error);
    }
  };

  const fetchTeamsIParticipateIn = async () => {
    try {
      const response = await agent.Team.getTeamsUserPlaysFor(userId);
      setTeamsIParticipateIn(response);
    } catch (error) {
      console.error("API Error:", error);
      setError(error);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      await Promise.all([fetchOwnTeams(), fetchTeamsIParticipateIn()]);
      setLoading(false);
    };

    fetchData();
  }, [userId]);

  const totalPages = Math.ceil((ownTeams.length + teamsIParticipateIn.length) / perPage);
  const startIndex = (page - 1) * perPage;
  const endIndex = page * perPage;
  const displayedOwnTeams = ownTeams.slice(startIndex, endIndex);
  const displayedTeamsIParticipateIn = teamsIParticipateIn.slice(startIndex, endIndex);

  const handlePageChange = (newPage) => {
    setPage(newPage);
    window.scrollTo(0, 0);
  };

  if (error) {
    console.error("API Error:", error);
    return <div>Error: {error.message}</div>;
  }
  if (loading) {
    console.log("Loading...");
    return <div>Loading...</div>;
  }

  return (
    <>
      <section className="pt-5 pb-5">
        <Container style={{ width: "75%" }}>
          <Row>
            <LinkForCreate title={"Create a new Team"} link={"/add-Team"} />
          </Row>

          {displayedOwnTeams.length > 0 && (
            <>
              <div style={{ display: "flex", alignItems: "center", textAlign: "center", margin: "10px 0" }}>
                <hr style={{ flex: "1" }} />
                <b> <span style={{ margin: "0 10px", color:"black" }}>Teams I Own</span> </b>
                <hr style={{ flex: "1" }} />
              </div>
              <Row>
                {displayedOwnTeams.map((team) => (
                  <TeamItem key={team.id} team={team} />
                ))}
              </Row>
            </>
          )}

          {displayedTeamsIParticipateIn.length > 0 && (
            <>
              <div style={{ display: "flex", alignItems: "center", textAlign: "center", margin: "10px 0" }}>
                <hr style={{ flex: "1" }} />
                <b> <span style={{ margin: "0 10px", color:"black" }}>Teams I Play For</span> </b>
                <hr style={{ flex: "1" }} />
              </div>
              <Row>
                {displayedTeamsIParticipateIn.map((team) => (
                  <TeamItem key={team.id} team={team} />
                ))}
              </Row>
            </>
          )}

          {(!displayedOwnTeams.length && !displayedTeamsIParticipateIn.length) && (
            <div style={{textAlign:"center", margin:"60px 0px 125.5px 0px"}}>No teams available.</div>
          )}
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

export default MyTeams;
