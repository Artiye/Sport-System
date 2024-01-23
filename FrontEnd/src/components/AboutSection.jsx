import React from "react";
import { Container, Row, Col } from "reactstrap";
import "../styles/about-section.css";
import aboutImg from "../all-images/1.jpg";

const AboutSection = () => {
  return (
    <section className="about__section" style={{ marginTop: "0px" }}>
      <Container>
        <Row>
          <Col lg="6" md="6">
            <div className="about__section-content">
              <h4 className="section__subtitle">About Us</h4>
              <h2 className="section__title">Welcome to <b>GameChanger</b></h2>
              <p className="section__description mt-4 mb-5">
                Welcome to our premier sports website, your one-stop destination for all things sports-related. 
                Whether you're a die-hard fan, a casual observer, or an athlete looking to stay informed and engaged, 
                our website offers a dynamic platform that caters to all your sports interests.   
                <br/> 
                Looking for more than just information? We offer a range of resources for active participants, 
                including training tips, gear recommendations, and event listings. Stay motivated and inspired by stories of success, 
                perseverance, and teamwork in the sports world.       
              </p>

              <div className="about__section-item d-flex align-items-center">
                <p className="section__description d-flex align-items-center gap-2">
                  <i className="ri-checkbox-circle-line"></i> Create/Join Teams.
                </p>

                <p className="section__description d-flex align-items-center gap-2">
                  <i className="ri-checkbox-circle-line"></i> Create/Join Tournaments.
                </p>
              </div>

              <div className="about__section-item d-flex align-items-center">
                <p className="section__description d-flex align-items-center gap-2">
                  <i className="ri-checkbox-circle-line"></i> Recruit Players.
                </p>

                <p className="section__description d-flex align-items-center gap-2 mx-4">
                  <i className="ri-checkbox-circle-line"></i> Play Matches.
                </p>
              </div>
            </div>
          </Col>

          <Col lg="6" md="6">
            <div className="about__img">
              <img src={aboutImg} alt="" className="w-100" />
            </div>
          </Col>
          
        </Row>
      </Container>
    </section>
  );
};

export default AboutSection;
