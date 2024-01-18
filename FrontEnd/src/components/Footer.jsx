import React from "react";
import { Container, Row, Col } from "reactstrap";
import "../styles/footer.css";
import logo from "../all-images/gameChangerLogo.png";
import { Link } from "react-router-dom";

const Footer = () => {
  return (
    <footer className="footer">
      <Container>
        <Row>

          <Col lg="4" md="4" sm="8">
            <div className="footer-logo">
              <img src={logo}/>
            </div>
            <p className="footer-content">
              Change the game with our system of creating teams, tournaments, matches, joining teams, recruiting players and much more.
            </p>
          </Col>

          <Col lg="4" md="4" sm="8">
            <div className="mb-4 pt-4">
              <h5 className="footer__link-title">Quick Links</h5>
              <ul className="footer__link-list">
                <li><Link to="/">Home</Link></li>
                <li><Link to="/all-teams">Teams</Link></li>
                <li><Link to="/tournaments">Tournaments</Link></li>
                <li><Link to="/all-players">Players</Link></li>
                <li><Link to="/about">About</Link></li>
              </ul>
            </div>
          </Col>

          <Col lg="4" md="4" sm="8">
            <div className="mb-4 pt-4">
              <h5 className="footer__link-title mb-4"> Info: </h5>
              <p className="office__info">Phone: +383 49 20 60 20</p>
              <p className="office__info">Email: sportsmanagement@gmail.com </p>
              <p className="office__info">Location: Kosovë, Prishtinë.</p>
            </div>
          </Col>

        </Row>
      </Container>
    </footer>
  );
};

export default Footer;
