USE music_shop;

CREATE TABLE IF NOT EXISTS users
(
  id              BIGINT PRIMARY KEY AUTO_INCREMENT,
  email           VARCHAR(255) UNIQUE NOT NULL,
  password        VARCHAR(255)        NOT NULL,
  role            ENUM ('user', 'admin') DEFAULT 'user',
  last_login_date DATETIME               DEFAULT CURRENT_TIMESTAMP,
  token           VARCHAR(255)        NULL
);