import React from "react";
import { Container, Row } from "reactstrap";
import TeamDetailsForm from "../../components/TeamComponents/TeamDetailsForm";

const TeamDetails = () => {
  return (
    <>
        <Container>
          <Row>
            <TeamDetailsForm />
          </Row>
        </Container>
    </>
  );
}

export default TeamDetails;
