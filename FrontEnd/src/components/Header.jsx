import React, {useState}from "react";
import { Container, Row, Col, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import { Link, NavLink, useLocation, useNavigate  } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from '../pages/IdentityPages/UserContext';
import "../styles/header.css";
import logo from "../all-images/gameChangerLogo.png";

const Header = () => {
  const { isLoggedIn } = useContext(UserContext);
  const [teamDropdownOpen, setTeamDropdownOpen] = useState(false);
  const [tournamentDropdownOpen, setTournamentDropdownOpen] = useState(false);
  const [playerDropdownOpen, setPlayerDropdownOpen] = useState(false);
  const location = useLocation();
  const userId = localStorage.getItem("userId");

  const teamIsActive = location.pathname === '/my-teams' || location.pathname === '/all-teams';
  const tournamentIsActive = location.pathname === '/tournaments' || location.pathname === '/my-tournaments';
  const playerIsActive = location.pathname === `/player/${userId}` || location.pathname === '/all-players';
  
  const navigate = useNavigate();

  const toggleTeamDropdown = () => {
    setTeamDropdownOpen(!teamDropdownOpen);
  };
  const toggleTournamentDropdown = () => {
    setTournamentDropdownOpen(!tournamentDropdownOpen);
  };
  const togglePlayerDropdown = () => {
    setPlayerDropdownOpen(!playerDropdownOpen);
  };

  return (
    <header className="header">

      {/* ============ header top ============ */}
      <div className="header__top">
        <Container>
          <Row>
            <Col lg="6" md="6" sm="6">
              <div className="site-logo" style={{width: "150px"}}>
                <img src={logo}/>
              </div>
            </Col>

            <Col lg="6" md="6" sm="6">
            <div className="header__top__right d-flex align-items-center justify-content-end gap-3">
                  <>
                    <Link style={{ fontSize:'19px', margin:"0px 5px"}}  to="/login" className="d-flex align-items-center gap-1">
                      <i className="ri-login-circle-line"></i> Login
                    </Link>

                    <Link style={{ fontSize:'19px'}} to="/register" className="d-flex align-items-center gap-1">
                      <i class="ri-user-add-line"></i> Register
                    </Link>
                  </>
              </div>
            </Col>
          </Row>
        </Container>
      </div>

      {/* ========== main navigation =========== */}
      <div className="main__navbar">
        <Container className="mainMenu">
        <Row style={{fontSize:'17px'}} className="justify-content-center">
          <Col lg="6" md="6" sm="6" className="px-2">
            <div className="d-flex gap-5">
              <NavLink to="/" className={(navClass) => navClass.isActive ? "nav__active nav__item" : "nav__item "}>
                <i className="ri-home-3-line"></i> Home
              </NavLink>

              {isLoggedIn ? (
                <Dropdown isOpen={teamDropdownOpen} toggle={toggleTeamDropdown}>
                  <DropdownToggle tag="span" data-toggle="dropdown" aria-expanded={teamDropdownOpen} className="dropdown-toggle">
                    <Link className={`nav__item ${teamIsActive ? "nav__active" : ""}`}>
                      <i className="ri-team-line"></i> Teams
                    </Link>
                  </DropdownToggle>
                  <DropdownMenu className="dropdown-menu">
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate('/my-teams')}>
                      <Link to="/my-teams" className="theLink">My Teams</Link>
                    </DropdownItem>
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate('/all-teams')}>
                      <Link to="/all-teams" className="theLink">All Teams</Link>
                    </DropdownItem>
                  </DropdownMenu>
                </Dropdown>
                  ) : (             
                <NavLink to="/all-teams" className={(navClass) => navClass.isActive ? "nav__active nav__item" : "nav__item "}>
                  <i className="ri-team-line"></i> Teams
                </NavLink>
              )}

              {isLoggedIn ? (
                <Dropdown isOpen={tournamentDropdownOpen} toggle={toggleTournamentDropdown}>
                  <DropdownToggle tag="span" data-toggle="dropdown" aria-expanded={tournamentDropdownOpen} className="dropdown-toggle">
                    <Link className={`nav__item ${tournamentIsActive ? "nav__active" : ""}`}>
                    <i className="ri-focus-3-line"></i> Tournaments
                    </Link>
                  </DropdownToggle>
                  <DropdownMenu className="dropdown-menu">
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate('/my-tournaments')}>
                      <Link to="/my-tournaments" className="theLink">My tournaments</Link>
                    </DropdownItem>
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate('/tournaments')}>
                      <Link to="/tournaments" className="theLink">All tournaments</Link>
                    </DropdownItem>
                  </DropdownMenu>
                </Dropdown>
                  ) : (             
                <NavLink to="/tournaments" className={(navClass) => navClass.isActive ? "nav__active nav__item" : "nav__item "}>
                  <i className="ri-focus-3-line"></i> Tournaments
                </NavLink>
              )}

              {isLoggedIn ? (
                <Dropdown isOpen={playerDropdownOpen} toggle={togglePlayerDropdown}>
                  <DropdownToggle tag="span" data-toggle="dropdown" aria-expanded={playerDropdownOpen} className="dropdown-toggle">
                    <Link className={`nav__item ${playerIsActive ? "nav__active" : ""}`}>
                      <i className="ri-team-line"></i> Players
                    </Link>
                  </DropdownToggle>
                  <DropdownMenu className="dropdown-menu">
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate(`/player/${userId}`)}>
                      <Link to={`/player/${userId}`} className="theLink">My Profile</Link>
                    </DropdownItem>
                    <DropdownItem className="dropdown-menu-item" onClick={() => navigate('/all-players')}>
                      <Link to="/all-players" className="theLink">All Players</Link>
                    </DropdownItem>
                  </DropdownMenu>
                </Dropdown>
                  ) : (             
                <NavLink to="/all-players" className={(navClass) => navClass.isActive ? "nav__active nav__item" : "nav__item "}>
                  <i className="ri-team-line"></i> Players
                </NavLink>
              )}

              <NavLink to="/about" className={(navClass) => navClass.isActive ? "nav__active nav__item" : "nav__item"}>
                <i className="ri-presentation-fill"></i> About
              </NavLink>
            </div>
          </Col>
          </Row>
        </Container>
      </div>
    </header>
  );
};

export default Header;
