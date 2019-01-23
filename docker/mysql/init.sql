USE muzyka4zycie;

CREATE TABLE IF NOT EXISTS users
(
  id              BIGINT                  PRIMARY KEY AUTO_INCREMENT,
  email           VARCHAR(255)            UNIQUE NOT NULL,
  password        VARCHAR(255)            NOT NULL,
  role            ENUM ('user', 'admin')  DEFAULT 'user',
  last_login_date DATETIME                DEFAULT CURRENT_TIMESTAMP,
  token           VARCHAR(255)            NULL
);

CREATE TABLE IF NOT EXISTS events
(
  id                          BIGINT                      PRIMARY KEY AUTO_INCREMENT,
  name                        VARCHAR(255)                NOT NULL,
  price                       REAL                        NOT NULL,
  place                       VARCHAR(255)                NOT NULL,
  date                        DATETIME                    DEFAULT CURRENT_TIMESTAMP,
  short_info                  VARCHAR(255)                NULL,
  description                 TEXT                        NULL,
  image_url                   TEXT                        NULL,
  number_of_available_tickets INTEGER                     NULL DEFAULT 0,
  created_by                  BIGINT                      NOT NULL,
  age_range                   ENUM ('ALL', 'ADULTS_ONLY') NOT NULL DEFAULT 'ALL',
  additional_info             VARCHAR(255)                NULL,
  CONSTRAINT events_to_users FOREIGN KEY (created_by) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS orders
(
  id                BIGINT        PRIMARY KEY AUTO_INCREMENT,
  user_id           BIGINT        NOT NULL,
  full_name         VARCHAR(255)  NOT NULL,
  phone_number      VARCHAR(255)  NULL,
  email             VARCHAR(255)  NOT NULL,
  city              VARCHAR(255)  NOT NULL,
  postal_address    VARCHAR(255)  NOT NULL,
  street            VARCHAR(255)  NOT NULL,
  house_number      INTEGER       NOT NULL ,
  order_status      VARCHAR(255)  NOT NULL,
  order_date        DATETIME      DEFAULT CURRENT_TIMESTAMP,
  shipping_cost     REAL          NOT NULL,
  shipping_method   VARCHAR(255)  NOT NULL,
  total_price       REAL          NOT NULL
  );

CREATE TABLE IF NOT EXISTS orders_events
(
  id                BIGINT        PRIMARY KEY AUTO_INCREMENT,
  order_id          BIGINT        NOT NULL,
  event_id          BIGINT        NOT NULL,
  event_name        VARCHAR(255)  NOT NULL,
  event_price       REAL          NOT NULL,
  event_date        DATETIME      NOT NULL,
  event_place       VARCHAR(255)  NOT NULL,
  quantity          INTEGER       NOT NULL,
  UNIQUE (order_id, event_id),
  CONSTRAINT orders_events_to_orders FOREIGN KEY (order_id) REFERENCES orders (id) ON DELETE CASCADE
);
