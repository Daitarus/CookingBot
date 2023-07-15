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
    "SupportsInlineQueries" boolean,
    "State" int NOT NULL
)
TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS "Documents"
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
TABLESPACE pg_default;