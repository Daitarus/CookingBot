DROP DATABASE IF EXISTS "LybraryBot";

CREATE DATABASE "LybraryBot"
    WITH
    OWNER = "LybraryBotUser"
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

DROP TABLE IF EXISTS "Users";
DROP TABLE IF EXISTS "Documents";

CREATE TABLE IF NOT EXISTS "Users"
(
    "Id" SERIAL PRIMARY KEY,
    "IdTelegram" bigint NOT NULL,
    "IsBot" boolean NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "LastName" character varying(50),
    "UserName" character varying(50),
    "LanguageCode" character varying(10),
    "CanJoinGroups" boolean,
    "CanReadAllGroupMessages" boolean,
    "SupportsInlineQueries" boolean
)

CREATE TABLE IF NOT EXISTS public."Documents"
(
    "Id" SERIAL PRIMARY KEY,
    "Name" character varying(100) NOT NULL,
    "Author" character varying(100) ,
    "Extension" character varying(10) NOT NULL,
    "Size" integer NOT NULL,
    "DateAdded" timestamp with time zone NOT NULL,
    "RelativePath" character varying(500) NOT NULL,
	"UserId" int REFERENCES "Users" ("Id")
)
