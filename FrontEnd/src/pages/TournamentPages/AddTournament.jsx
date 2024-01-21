import React, { useEffect } from "react";
import { Container, Row } from "reactstrap";
import AddTournamentForm from "../../components/TournementComponents/AddTournamentForm";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const AddTournament = () => {
  const navigate = useNavigate();
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (!isLoggedIn) {
      navigate("/login");
    }
  }, [isLoggedIn, navigate]);

  return (
    <>
        <Container>
          <Row>
            <AddTournamentForm />
          </Row>
        </Container>
    </>
  );
}

export default AddTournament;