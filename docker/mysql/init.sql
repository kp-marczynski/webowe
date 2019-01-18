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
  name                        VARCHAR(255)                NOT NULL,
  price                       REAL                        NOT NULL,
  place                       VARCHAR(255)                NOT NULL,
  date                        DATETIME                             DEFAULT CURRENT_TIMESTAMP,
  short_info                  VARCHAR(255)                NULL,
  description                 TEXT                        NULL,
  image_url                   TEXT                        NULL,
  number_of_available_tickets INTEGER                     NULL     DEFAULT 0,
  created_by                  BIGINT                      NOT NULL,
  age_range                   ENUM ('ALL', 'ADULTS_ONLY') NOT NULL DEFAULT 'ALL',
  additional_info             VARCHAR(255)                NULL,
  CONSTRAINT events_to_users FOREIGN KEY (created_by) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS orders
(
  order_id          BIGINT        PRIMARY KEY AUTO_INCREMENT,
  user_id           BIGINT        NOT NULL UNIQUE,
  city              VARCHAR(255)  NOT NULL,
  postal_address    VARCHAR(255)  NOT NULL,
  street            VARCHAR(255)  NOT NULL,
  house_number      INTEGER       NOT NULL ,
  apartment_number  INTEGER       NULL,
  phone_number      VARCHAR(255)  NULL,
  CONSTRAINT orders_to_users FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS orders_events
(
  order_id          BIGINT        NOT NULL,
  event_id          BIGINT        NOT NULL,
  event_name        VARCHAR(255)  NOT NULL,
  event_price       REAL          NOT NULL,
  event_place       VARCHAR(255)  NOT NULL,
  quantity          INTEGER       NOT NULL,
  CONSTRAINT orders_events_to_users FOREIGN KEY (user_id) REFERENCES users (id),
  CONSTRAINT orders_events_to_events FOREIGN KEY (event_id) REFERENCES events (id),
  PRIMARY KEY (order_id, event_id)
);

-- CREATE TABLE IF NOT EXISTS orders
-- (
--   user_id           BIGINT        NOT NULL UNIQUE,
--   city              VARCHAR(255)  NOT NULL,
--   postal_address    VARCHAR(255)  NOT NULL,
--   street            VARCHAR(255)  NOT NULL,
--   house_number      INTEGER       NOT NULL ,
--   apartment_number  INTEGER       NULL,
--   phone_number      VARCHAR(255)  NULL,
--   CONSTRAINT aorders_to_users FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
-- );