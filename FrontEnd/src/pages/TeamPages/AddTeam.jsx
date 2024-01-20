import React, { useEffect } from "react";
import { Container, Row } from "reactstrap";
import AddTeamForm from "../../components/TeamComponents/AddTeamForm";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const AddTeam = () => {
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
            <AddTeamForm />
          </Row>
        </Container>
    </>
  );
}

export default AddTeam;