import React from "react";
import { Container, Row } from "reactstrap";
import TournamentDetailsForm from "../../components/TournementComponents/TournamentDetailsForm";

const TournamentDetails = () => {
  return (
    <>
        <Container>
          <Row>
            <TournamentDetailsForm />
          </Row>
        </Container>
    </>
  );
}

export default TournamentDetails;
