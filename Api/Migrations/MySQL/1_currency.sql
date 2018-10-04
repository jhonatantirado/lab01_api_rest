CREATE TABLE currency (
  currency_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  iso_code varchar(3) NOT NULL,
  PRIMARY KEY (currency_id),
  UNIQUE KEY currency_id_UNIQUE (currency_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO currency(iso_code) VALUES('PEN');
INSERT INTO currency(iso_code) VALUES('USD');
INSERT INTO currency(iso_code) VALUES('EUR');