CREATE TABLE user (
  user_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  username varchar(45) NOT NULL,
  password varchar(256) NOT NULL,
  role_id bigint UNSIGNED NOT NULL,
  customer_id bigint UNSIGNED NOT NULL,
  PRIMARY KEY (user_id),
  UNIQUE KEY user_id_UNIQUE (user_id),
  CONSTRAINT FK_user_role_id FOREIGN KEY(role_id) REFERENCES role(role_id),
  CONSTRAINT FK_user_customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO user (username,password,role_id,customer_id) values ('jhonatan.tirado','password',1,1);