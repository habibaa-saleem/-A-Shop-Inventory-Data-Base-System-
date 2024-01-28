------------------------------------------------PRODUCT CATEGORIES

CREATE TABLE product_categories
 (
 category_id NUMBER,
 category_name VARCHAR2( 255 ) NOT NULL
 );
CREATE SEQUENCE pc_sequence
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER pc_trig
BEFORE INSERT ON product_categories
FOR EACH ROW
BEGIN
  SELECT pc_sequence.NEXTVAL INTO :NEW.category_id FROM dual;
END;

ALTER TABLE product_categories ADD constraint pc_pk PRIMARY KEY(category_id);

----------------------------------------------RACK

CREATE TABLE Rack(          
rack_no number,
description varchar2(1000),
category_id number
);
select * from product;

CREATE SEQUENCE rack_sequence
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER rack_trig
BEFORE INSERT ON rack
FOR EACH ROW
BEGIN
  SELECT rack_sequence.NEXTVAL INTO :NEW.rack_no FROM dual;
END;
ALTER TABLE rack ADD constraint rack_fk  FOREIGN KEY(category_id)  REFERENCES product_categories(category_id) ON DELETE CASCADE;
ALTER TABLE rack ADD constraint rack_pk PRIMARY KEY(rack_no);


desc salesman;
--------------------------------VENDOR 
CREATE TABLE Vendor(
vendor_id number,
barcode_id number,   
name varchar(255),
email varchar(255),
phone_number int,

);




CREATE SEQUENCE vendor_sequence
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER vendor_trig
BEFORE INSERT ON vendor
FOR EACH ROW
BEGIN
  SELECT vendor_sequence.NEXTVAL INTO :NEW.vendor_id FROM dual;
END;
ALTER TABLE vendor ADD constraint vendor_pk PRIMARY KEY(vendor_id);
ALTER TABLE vendor ADD constraint vendor_fk FOREIGN KEY(barcode_id)   REFERENCES product(barcodeid) ON DELETE CASCADE;

ALTER TABLE Vendor ADD CONSTRAINT chk_email CHECK (email LIKE '%@gmail.com');

--ALTER TABLE Vendor ADD CONSTRAINT chk_number CHECK (phone_number LIKE '03_________');


-----------------------------PURCHASED

CREATE TABLE purchased (         --for products purchased from vendor
  bill_id number,
  vendor_id number,
  purchase_date TIMESTAMP default TIMESTAMP,
  total_cost DECIMAL(10, 2),
  barcodeid number,
  paid NUMBER DEFAULT 0
);


CREATE SEQUENCE purchased_sequence
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER purchased_trig
BEFORE INSERT ON purchased
FOR EACH ROW
BEGIN
  SELECT purchased_sequence.NEXTVAL INTO :NEW.bill_id FROM dual;
END;

ALTER TABLE purchased ADD constraint v_pk PRIMARY KEY(bill_id);
ALTER TABLE purchased ADD constraint purchased_fk FOREIGN KEY(vendor_id) REFERENCES vendor(vendor_id) ON DELETE CASCADE;
ALTER TABLE purchased ADD constraint purchased_fk1 FOREIGN KEY(barcodeid) REFERENCES product(barcodeid) ON DELETE CASCADE;

--------------------------------address_vendor
Create table address_vendor
(
street_number VARCHAR(255),
street_name VARCHAR(255),
apartment_number VARCHAR(255),
country varchar(255),
city     varchar(255),
vendor_id number

);

ALTER TABLE address_vendor ADD constraint v_fk FOREIGN KEY(vendor_id) REFERENCES vendor(vendor_id) ON DELETE CASCADE;
ALTER TABLE address_vendor ADD constraint v_pk2 PRIMARY KEY(vendor_id);

----------------------------------------PRODUCT
CREATE TABLE product(
      barcodeid number,         --pk
      product_name VARCHAR2(255),
      rack_no number,    --fk
      category_id number,
      description varchar2(2000),
      list_price number(10,2)
);

     
CREATE SEQUENCE product_seq
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER product_trig
BEFORE INSERT ON product
FOR EACH ROW
BEGIN
  SELECT product_seq.NEXTVAL INTO :NEW.barcodeid FROM dual;
END;


ALTER TABLE product ADD CONSTRAINT p_pk PRIMARY KEY(barcodeid);
ALTER TABLE product ADD CONSTRAINT p_fk1 FOREIGN KEY(category_id) REFERENCES product_categories(category_id) ON DELETE CASCADE;
ALTER TABLE product ADD CONSTRAINT p_fk3 FOREIGN KEY(rack_no) REFERENCES rack(rack_no) ON DELETE CASCADE;

-------------------------------------------------------ADDRESS
CREATE TABLE ADDRESS_DETAILS
(
street_number VARCHAR(255),
street_name VARCHAR(255),
apartment_number VARCHAR(255),
country varchar(255),
city     varchar(255),
customer_id number
);

ALTER TABLE ADDRESS_DETAILS ADD CONSTRAINT customer_id FOREIGN KEY(customer_id) REFERENCES customer(customer_id) ON DELETE CASCADE;
ALTER TABLE ADDRESS_DETAILS ADD CONSTRAINT add_pk PRIMARY KEY(customer_id);

---------------------------------------------------Customer
CREATE TABLE Customer(
customer_id number,
firstname varchar(255),
lastname  varchar(255),
email varchar(255) ,         
phone_number int,

);

CREATE SEQUENCE cust_seq
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER cust_trig
BEFORE INSERT ON customer
FOR EACH ROW
BEGIN
  SELECT cust_seq.NEXTVAL INTO :NEW.customer_id FROM dual;
END;

ALTER TABLE CUSTOMER ADD CONSTRAINT cust_pk PRIMARY KEY(customer_id);

ALTER TABLE Customer ADD CONSTRAINT chk_email_cust CHECK (email LIKE '%@gmail.com');

--ALTER TABLE Customer ADD CONSTRAINT chk_number_cust CHECK (phone_number LIKE '03_________');



-------------------------------------------------------------SALESMAN
CREATE TABLE salesman
(
salesman_id number,
first_name VARCHAR( 255 ) NOT NULL,
last_name  VARCHAR( 255 ) NOT NULL,
email      VARCHAR( 255 ) NOT NULL,
phone      VARCHAR( 50 ) NOT NULL ,
hire_date  timestamp default SYSTIMESTAMP; ,
salary     number
  
);


CREATE SEQUENCE sales_seq
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER salesman_trig
BEFORE INSERT ON salesman
FOR EACH ROW
BEGIN
  SELECT sales_seq.NEXTVAL INTO :NEW.salesman_id FROM dual;
END;

ALTER TABLE Salesman ADD CONSTRAINT sales_pk PRIMARY KEY(salesman_id);
ALTER TABLE Salesman ADD CONSTRAINT chk_email_sales CHECK (email LIKE '%@gmail.com');
--ALTER TABLE Salesman ADD CONSTRAINT chk_number_sale CHECK (phone LIKE '03_________');




-----------------------------------------------------orders

CREATE TABLE orders
(
order_id number,
customer_id number,
salesman_id number,
barcodeid number,
date_of_sale TIMESTAMP,
status   varchar(20),
);



CREATE SEQUENCE order_seq
START WITH 1
INCREMENT BY 1
MAXVALUE 999999999999999999999999999
MINVALUE 1
CACHE 20
NOCYCLE
ORDER;

CREATE OR REPLACE TRIGGER order_trig
BEFORE INSERT ON orders
FOR EACH ROW
BEGIN
  SELECT order_seq.NEXTVAL INTO :NEW.order_id FROM dual;
END;

ALTER TABLE orders ADD CONSTRAINT orders_pk PRIMARY KEY(order_id);
ALTER TABLE orders ADD CONSTRAINT  fk_customer FOREIGN KEY(customer_id) REFERENCES Customer(customer_id) ON DELETE CASCADE;
ALTER TABLE orders ADD CONSTRAINT fk_sale  FOREIGN KEY(barcodeid)    REFERENCES  Product(barcodeid) ON DELETE CASCADE;

ALTER TABLE orders ADD constraint st_check CHECK (status in ('sale','return'));

--------------------------------------------------------------------Order items

CREATE TABLE order_items 
(    
order_id NUMBER,
barcodeid NUMBER,
quantity NUMBER,
unit_price NUMBER
  
);

ALTER TABLE order_items ADD CONSTRAINT pk_order_items PRIMARY KEY (order_id, barcodeid);
ALTER TABLE order_items ADD CONSTRAINT fk_order_items_order FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE;
ALTER TABLE order_items ADD CONSTRAINT fk_order_items_product FOREIGN KEY (barcodeid) REFERENCES product(barcodeid) ON DELETE CASCADE;

-----------------------------------------------------INVENTORIES


CREATE TABLE inventories
(
barcodeid   number,
quantity      number not null,
safety_stock_level int,
lead_time int,
reorder_point int,
date_added   TIMESTAMP default SYSTIMESTAMP
);

ALTER TABLE inventories ADD CONSTRAINT in_fk FOREIGN KEY(barcodeid) REFERENCES product(barcodeid);
ALTER TABLE inventories ADD CONSTRAINT in_pk PRIMARY KEY(barcodeid);



