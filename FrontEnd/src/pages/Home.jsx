import React, { useState } from "react";
import { Carousel } from "react-bootstrap";
import { Container } from "reactstrap";
import image1 from "../all-images/slide5.jpg";
import image2 from "../all-images/slide6.jpg";
import image3 from "../all-images/slide3.jpg";
import image4 from "../all-images/news1.png";
import image5 from "../all-images/news2.png";
import image6 from "../all-images/news3.png";
import image7 from "../all-images/news4.png";
import "../styles/home.css";

const Home = () => {
  const [index, setIndex] = useState(0);
  const handleSelect = (selectedIndex) => { setIndex(selectedIndex); };

  const latestNews = [
    {
      id: 1,
      title:
        "'Let the games begin' - NBA 2023-24 season preview",
      sport: "Basketball",
      image: image4,
      link: "https://www.bbc.com/sport/basketball/67193847",
    },
    {
      id: 2,
      title: "What are PSGs owners planning with Braga stake?",
      sport: "Europian Football",
      image: image5,
      link: "https://www.bbc.com/sport/football/67192619",
    },
    {
      id: 2,
      title: "Former Olympic champion Retton home from hospital",
      sport: "Gymnastics",
      image: image6,
      link: "https://www.bbc.com/sport/gymnastics/67200775",
    },
    {
      id: 2,
      title: "Rank the top 10 teams in Rugby World Cup history",
      sport: "Rugby",
      image: image7,
      link: "https://www.bbc.com/sport/rugby-union/66822449",
    },
  ];

  return (
    <>
      <section>
        <Container>
          <Carousel
            className="custom-carousel"
            activeIndex={index}
            onSelect={handleSelect}
          >
            <Carousel.Item>
              <img className="d-block w-100" src={image1} alt="First slide" />
              <Carousel.Caption>
                <h3>Change the Game!</h3>
              </Carousel.Caption>
            </Carousel.Item>

            <Carousel.Item>
              <img className="d-block w-100" src={image2} alt="Second slide" />
              <Carousel.Caption>
                <h3 className="text-black">TEAMWORK IS AT THE CORE OF OUR SUCCESS</h3>
                <h5 className="text-black">
                  <b>Coming together is a beginning. Keeping together is progress.
                  Working together is success!</b>
                </h5>
              </Carousel.Caption>
            </Carousel.Item>

            <Carousel.Item>
              <img className="d-block w-100" src={image3} alt="Third slide" />
            </Carousel.Item>
          </Carousel>
        </Container>
      </section>
      <section className="latest-news-section mb-5">
        <Container>
          <h2>Latest News</h2>
          <div className="news-cards">
            {latestNews.map((news) => (
              <div key={news.id} className="news-card">
                <img
                  src={news.image}
                  alt={news.title}
                  className="news-card-image"
                />
                <div className="news-card-content">
                  <h3>
                    <a
                      href={news.link}
                      target="_blank"
                      rel="noopener noreferrer"
                    >
                      {news.title}
                    </a>
                  </h3>
                  <p>Sport: {news.sport}</p>
                </div>
              </div>
            ))}
          </div>
        </Container>
      </section>
    </>
  );
};

export default Home;
