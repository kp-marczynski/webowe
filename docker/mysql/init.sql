USE muzyka4zycie;

CREATE TABLE IF NOT EXISTS users
(
  id              BIGINT PRIMARY KEY AUTO_INCREMENT,
  email           VARCHAR(255) UNIQUE NOT NULL,
  password        VARCHAR(255)        NOT NULL,
  role            ENUM ('user', 'admin') DEFAULT 'user',
  last_login_date DATETIME               DEFAULT CURRENT_TIMESTAMP,
  token           VARCHAR(255)        NULL
);

CREATE TABLE IF NOT EXISTS events
(
  id                          BIGINT PRIMARY KEY AUTO_INCREMENT,
  name                        VARCHAR(255) NOT NULL,
  price                       REAL         NOT NULL,
  place                       VARCHAR(255) NOT NULL,
  date                        DATETIME          DEFAULT CURRENT_TIMESTAMP,
  short_info                  VARCHAR(255) NULL,
  description                 TEXT         NULL,
  image_url                   TEXT         NULL,
  number_of_available_tickets INTEGER      NULL DEFAULT 0,
  created_by                  BIGINT       NOT NULL,

  CONSTRAINT events_to_users FOREIGN KEY (created_by) REFERENCES users (id) ON DELETE CASCADE
);