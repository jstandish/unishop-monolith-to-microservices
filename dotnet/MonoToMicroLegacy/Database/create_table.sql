/**
 * Copyright 2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify,
 * merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


IF(db_id(N'unishop') IS NULL)
    BEGIN
        create database unishop;
    END;
go
USE unishop
CREATE TABLE unicorns (
-- general fields
  	id bigint IDENTITY(1,1) PRIMARY KEY,
  	creation_date DATETIME DEFAULT CURRENT_TIMESTAMP,
  	last_modified_date DATETIME NULL,
  	created_by_user_id BIGINT DEFAULT NULL,
  	last_modified_by_user_id BIGINT DEFAULT NULL,
  	active tinyint DEFAULT NULL,
--	model fields
	uuid varchar(64) NOT NULL,
	name varchar(64) DEFAULT NULL,
	description varchar(256) DEFAULT NULL,
  	price decimal(6,2) DEFAULT NULL,
  	image varchar(256) DEFAULT NULL,
  	CONSTRAINT UnicornUnique UNIQUE (uuid),
)
go

CREATE TABLE  unicorns_basket (
-- general fields
  	id BIGINT IDENTITY(1,1) PRIMARY KEY,
  	creation_date DATETIME DEFAULT CURRENT_TIMESTAMP,
  	last_modified_date DATETIME NULL,
  	created_by_user_id BIGINT DEFAULT NULL,
  	last_modified_by_user_id BIGINT DEFAULT NULL,
  	active tinyint DEFAULT NULL,
--	model fields
	uuid varchar(64) NOT NULL,
  	unicornUuid varchar(64) NOT NULL,
  	CONSTRAINT UnicornUniqueBasket UNIQUE (uuid, unicornUuid),
);
go
CREATE TABLE  unicorn_user (
-- general fields
  	id BIGINT IDENTITY(1,1) PRIMARY KEY,
  	creation_date DATETIME DEFAULT CURRENT_TIMESTAMP,
  	last_modified_date DATETIME NULL,
  	created_by_user_id BIGINT  DEFAULT NULL,
  	last_modified_by_user_id BIGINT DEFAULT NULL,
  	active tinyint DEFAULT NULL,
--	model fields
	uuid varchar(64) NOT NULL,
	email varchar(64) NOT NULL,
  	first_name varchar(64) DEFAULT NULL,
  	last_name varchar(64) DEFAULT NULL,
  	CONSTRAINT UserUniqueUser UNIQUE (email),
);
go

INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornFloat', 'Big Unicorn Float! Giant Glitter Unicorn Pool Floaty', 100, 'UnicornFloat');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornHipHop', 'Rainbow Hip Hop Unicorn With Sunglasses Kids Tshirt', 100, 'UnicornHipHop');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornPartyDress', 'Girls Unicorn Party Dress - Tutu Pastel Rainbow Princess Power!', 100, 'UnicornPartyDress');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornGlitter', 'Unicorn Glitter Backpack - Shop for Unique Unicorn Gifts for Girls!', 100, 'UnicornGlitter');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornBeddings', 'Rainbow Unicorn Bedding Set - The Perfect Kids or Adults Unicorn Duvet Set', 100, 'UnicornBeddings');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornPink', 'Pretty Pink Baby Unicorn Summer Party Dress', 100, 'UnicornPink');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornBackpack', 'Top Rated Classy Unicorn Backpack - Kawaii School Bag', 100, 'UnicornBackpack');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornBlanket', 'Superfun Bestselling Unicorn Hooded Blanket', 100, 'UnicornBlanket');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornCool', 'Cool Dabbing Unicorn Mens Hip-hop Shirts', 100, 'UnicornCool');
INSERT INTO unicorns (uuid, name, description, price, image) VALUES (NEWID(),'UnicornFluffy', 'Stylish Fluffy Unicorn Slippers', 100, 'UnicornFluffy');
