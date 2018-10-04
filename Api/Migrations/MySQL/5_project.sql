CREATE TABLE project (
  project_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  project_name varchar(200) NOT NULL,
  budget decimal(10,2) DEFAULT NULL,
  currency_id bigint UNSIGNED NOT NULL,
  customer_id bigint UNSIGNED NOT NULL,
  PRIMARY KEY (project_id),
  UNIQUE KEY project_id_UNIQUE (project_id),
  CONSTRAINT FK_project_customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
  CONSTRAINT FK_project_currency_id FOREIGN KEY(currency_id) REFERENCES currency(currency_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT into project (project_name,budget,currency_id,customer_id) values ('TransMobile',1000000.00,2,1);