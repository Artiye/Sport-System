import React, { useEffect, useState } from "react";
import { Container, Row, Input } from "reactstrap"; // Changed Button to Input for search
import agent from "../../api/agent";
import TournamentItem from "../../components/TournementComponents/TournamentItem";
import PaginationComponent from "../../components/PaginationComponent";

const TournamentsList = () => {
    const [tournaments, setTournaments] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [page, setPage] = useState(1);
    const [perPage] = useState(4);
    const [searchQuery, setSearchQuery] = useState("");
    const [filteredTournaments, setFilteredTournaments] = useState([]);

    const fetchTournaments = async () => {
        try {
            const response = await agent.Tournament.getAllTournaments();
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
    }, []);

    useEffect(() => {
        const fetchFilteredTournaments = async () => {
            try {
                const trimmedQuery = searchQuery.replace(/\s/g, '');
                const response = await agent.Tournament.SearchTournaments(searchQuery);
                console.log("Filtered Tournaments:", response);
                setFilteredTournaments(response);
            } catch (error) {
                console.error("API Error:", error);
                setError(error);
            }
        };

        if (searchQuery.trim() !== "") {
            fetchFilteredTournaments();
        } else {
            setFilteredTournaments([]);
        }
    }, [searchQuery]);

    //pagination
    const displayedTournaments = searchQuery.trim() !== "" ? filteredTournaments : tournaments;
    const totalDisplayedTournaments = displayedTournaments.length; 
    const totalPages = Math.ceil(totalDisplayedTournaments / perPage);

    let startIndex = (page - 1) * perPage;
    let endIndex = page * perPage;
    endIndex = Math.min(endIndex, totalDisplayedTournaments);
    
    if (page > totalPages) {
        startIndex = 0;
        endIndex = perPage;
    }
    const paginatedTournaments = displayedTournaments.slice(startIndex, endIndex);
    
    const handlePageChange = (newPage) => {
        setPage(newPage);
        window.scrollTo(0, 0);
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
            <section style={{paddingTop:"0px"}}>
                <Container style={{ width: "75%" }}>
                    <div style={{ display: "flex", justifyContent: "flex-end", alignItems: "center", padding: "10px", margin:"20px 0px"}}>
                        <input
                        type="text"
                        placeholder="Search tournaments..."
                        value={searchQuery}
                        onChange={(e) => setSearchQuery(e.target.value)}
                        style={{ padding: "10px", fontSize: "16px", borderRadius: "5px", border: "1px solid #ccc", width: "300px" }} />
                    </div>

                    <Row>
                        {paginatedTournaments && paginatedTournaments.length > 0 ? (
                            paginatedTournaments.map((tournament) => (
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

export default TournamentsList;
