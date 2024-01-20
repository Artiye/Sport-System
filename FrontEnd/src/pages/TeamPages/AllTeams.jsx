import React, { useEffect, useState } from "react";
import { Container, Row } from "reactstrap";
import agent from "../../api/agent";
import TeamItem from "../../components/TeamComponents/TeamItem";
import PaginationComponent from "../../components/PaginationComponent";

const AllTeams = () => {
  const [teams, setTeams] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [page, setPage] = useState(1);
  const [perPage] = useState(9);
  const userId = localStorage.getItem("userId");
  const [searchQuery, setSearchQuery] = useState("");
  const [filteredTeams, setFilteredTeams] = useState([]);

  const fetchTeams = async () => {
    try {
      const response = await agent.Team.getAllTeams();
      console.log("API Response:", response);
      setTeams(response);
      setLoading(false);
    } catch (error) {
      console.error("API Error:", error);
      setError(error);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchTeams();
  }, [userId]);

  useEffect(() => {
    const fetchFilteredTeams = async () => {
      try {
        const trimmedQuery = searchQuery.replace(/\s/g, '');
        const response = await agent.Team.SearchTeams(searchQuery);
        console.log("Filtered Teams:", response);
        setFilteredTeams(response);
      } catch (error) {
        console.error("API Error:", error);
        setError(error);
      }
    };
  
    if (searchQuery.trim() !== "") {
      fetchFilteredTeams();
    } else {
      setFilteredTeams([]);
    }
  }, [searchQuery]);

  //pagination
  const displayedTeams = searchQuery.trim() !== "" ? filteredTeams : teams;
  const totalDisplayedTeams = displayedTeams.length; 
  const totalPages = Math.ceil(totalDisplayedTeams / perPage);

  let startIndex = (page - 1) * perPage;
  let endIndex = page * perPage;
  endIndex = Math.min(endIndex, totalDisplayedTeams);
  
  if (page > totalPages) {
    startIndex = 0;
    endIndex = perPage;
  }
  const paginatedTeams = displayedTeams.slice(startIndex, endIndex);
  
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
      <section style={{paddingTop:"0px"}}>
        <Container style={{ width: "75%" }}>
          <div style={{ display: "flex", justifyContent: "flex-end", alignItems: "center", padding: "10px", margin:"20px 0px"}}>
            <input
              type="text"
              placeholder="Search teams..."
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              style={{ padding: "10px", fontSize: "16px", borderRadius: "5px", border: "1px solid #ccc", width: "300px" }} />
          </div>

          <Row>
            {paginatedTeams.length > 0 ? (
              paginatedTeams.map((team) => <TeamItem key={team.id} team={team} /> )
            ) : (
              <div style={{textAlign:"center", margin:"60px 0px 125.5px 0px"}}>No teams available.</div>
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

export default AllTeams;
