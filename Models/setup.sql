

CREATE TABLE books (
  id INT NOT NULL AUTO_INCREMENT,
  title VARCHAR(80) NOT NULL,
  Auther VARCHAR(255),
  isAvailable TINYINT NOT NULL,
  PRIMARY KEY (id)
)