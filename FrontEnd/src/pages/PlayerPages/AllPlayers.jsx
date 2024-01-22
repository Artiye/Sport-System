import React, { useEffect, useState } from "react";
import { Container, Row } from "reactstrap";
import agent from "../../api/agent";
import PlayerItem from "../../components/PlayerComponents/PlayerItem";
import PaginationComponent from "../../components/PaginationComponent";

const AllPlayers = () => {
  const [players, setPlayers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [page, setPage] = useState(1);
  const [perPage] = useState(18);
  const userId = localStorage.getItem("userId");
  const [searchQuery, setSearchQuery] = useState("");
  const [filteredPlayers, setFilteredPlayers] = useState([]);

  const fetchPlayers = async () => {
    try {
      const response = await agent.User.getAllUsers();
      console.log("API Response:", response);
      setPlayers(response);
      setLoading(false);
    } catch (error) {
      console.error("API Error:", error);
      setError(error);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchPlayers();
  }, [userId]);

  useEffect(() => {
    const fetchFilteredPlayers = async () => {
      try {
        const trimmedQuery = searchQuery.replace(/\s/g, '');
        const response = await agent.User.SearchUser(trimmedQuery);
        console.log("Filtered Players:", response);
        setFilteredPlayers(response);
      } catch (error) {
        console.error("API Error:", error);
        setError(error);
      }
    };
  
    if (searchQuery.trim() !== "") {
      fetchFilteredPlayers();
    } else {
      setFilteredPlayers([]);
    }
  }, [searchQuery]);

  //pagination
  const displayedPlayers = searchQuery.trim() !== "" ? filteredPlayers : players;
  const totalDisplayedPlayers = displayedPlayers.length;
  const totalPages = Math.ceil(totalDisplayedPlayers / perPage);
  
  let startIndex = (page - 1) * perPage;
  let endIndex = page * perPage;
  endIndex = Math.min(endIndex, totalDisplayedPlayers);
  
  if (page > totalPages) {
    startIndex = 0;
    endIndex = perPage;
  }
  const paginatedPlayers = displayedPlayers.slice(startIndex, endIndex);
  
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
              placeholder="Search players..."
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              style={{ padding: "10px", fontSize: "16px", borderRadius: "5px", border: "1px solid #ccc", width: "300px" }} />
          </div>

          <Row>
            {paginatedPlayers.length > 0 ? (
              paginatedPlayers.map((player) => (
                <PlayerItem key={player.applicationUserId} player={player} />
              ))
            ) : (
              <div style={{textAlign:"center", margin:"60px 0px 125.5px 0px"}}>No players available.</div>
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

export default AllPlayers;
