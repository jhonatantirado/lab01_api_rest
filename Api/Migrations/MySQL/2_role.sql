CREATE TABLE role (
  role_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  role_name varchar(45) NOT NULL,
  PRIMARY KEY (role_id),
  UNIQUE KEY role_id_UNIQUE (role_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO role (role_name) values ('Owner');
INSERT INTO role (role_name) values ('Supervisor');
INSERT INTO role (role_name) values ('Assistant');