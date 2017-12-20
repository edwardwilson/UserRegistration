CREATE DATABASE UserRegistration

CREATE TABLE UserDetail (
	"Id" int IDENTITY(1,1),
	"EmailAddress" varchar(254) NOT NULL,
	"Password" varchar(64) NOT NULL,
    "Salt" varchar(32) NOT NULL,
)

CREATE UNIQUE INDEX emailadress_index
ON UserDetail (EmailAddress); 