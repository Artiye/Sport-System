import React from "react";
import { Container, Row } from "reactstrap";
import PlayerDetailsForm from "../../components/PlayerComponents/PlayerDetailsForm";

const PlayerDetails = () => {
  return (
    <>
        <Container>
          <Row>
            <PlayerDetailsForm />
          </Row>
        </Container>
    </>
  );
}

export default PlayerDetails;
