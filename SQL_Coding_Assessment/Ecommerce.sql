
CREATE DATABASE Ecommerce;

USE Ecommerce;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    firstName VARCHAR(50),
    lastName VARCHAR(50),
    email VARCHAR(100),
    address VARCHAR(255)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    name VARCHAR(100),
    description TEXT,
    price DECIMAL(10, 2),
    stockQuantity INT
);

CREATE TABLE cart (
    cart_id INT PRIMARY KEY,
    customer_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    total_price DECIMAL(10, 2),
    shipping_address VARCHAR(255),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    itemAmount DECIMAL(10, 2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO customers (customer_id, firstName, lastName, email, address)
VALUES 
(1, 'John', 'Doe', 'johndoe@example.com', '123 Main St, City'),
(2, 'Jane', 'Smith', 'janesmith@example.com', '456 Elm St, Town'),
(3, 'Robert', 'Johnson', 'robert@example.com', '789 Oak St, Village'),
(4, 'Sarah', 'Brown', 'sarah@example.com', '101 Pine St, Suburb'),
(5, 'David', 'Lee', 'david@example.com', '234 Cedar St, District'),
(6, 'Laura', 'Hall', 'laura@example.com', '567 Birch St, County'),
(7, 'Michael', 'Davis', 'michael@example.com', '890 Maple St, State'),
(8, 'Emma', 'Wilson', 'emma@example.com', '321 Redwood St, Country'),
(9, 'William', 'Taylor', 'william@example.com', '432 Spruce St, Province'),
(10, 'Olivia', 'Adams', 'olivia@example.com', '765 Fir St, Territory');

-- SELECT * FROM customers;

INSERT INTO products (product_id, name, description, price, stockQuantity)
VALUES 
(1, 'Laptop', 'High-performance laptop', 800.00, 10),
(2, 'Smartphone', 'Latest smartphone', 600.00, 15),
(3, 'Tablet', 'Portable tablet', 300.00, 20),
(4, 'Headphones', 'Noise-canceling', 150.00, 30),
(5, 'TV', '4K Smart TV', 900.00, 5),
(6, 'Coffee Maker', 'Automatic coffee maker', 50.00, 25),
(7, 'Refrigerator', 'Energy-efficient', 700.00, 10),
(8, 'Microwave Oven', 'Countertop microwave', 80.00, 15),
(9, 'Blender', 'High-speed blender', 70.00, 20),
(10, 'Vacuum Cleaner', 'Bagless vacuum cleaner', 120.00, 10);

-- SELECT * FROM products;

INSERT INTO cart (cart_id, customer_id, product_id, quantity)
VALUES 
(1, 1, 1, 2),
(2, 1, 3, 1),
(3, 2, 2, 3),
(4, 3, 4, 4),
(5, 3, 5, 2),
(6, 4, 6, 1),
(7, 5, 1, 1),
(8, 6, 10, 2),
(9, 6, 9, 3),
(10, 7, 7, 2);

-- SELECT * FROM cart;

INSERT INTO orders (order_id, customer_id, order_date, total_price, shipping_address)
VALUES 
(1, 1, '2023-01-05', 1200.00, '123 Main St, City'),
(2, 2, '2023-02-10', 900.00, '456 Elm St, Town'),
(3, 3, '2023-03-15', 300.00, '789 Oak St, Village'),
(4, 4, '2023-04-20', 150.00, '101 Pine St, Suburb'),
(5, 5, '2023-05-25', 1800.00, '234 Cedar St, District'),
(6, 6, '2023-06-30', 400.00, '567 Birch St, County'),
(7, 7, '2023-07-05', 700.00, '890 Maple St, State'),
(8, 8, '2023-08-10', 160.00, '321 Redwood St, Country'),
(9, 9, '2023-09-15', 140.00, '432 Spruce St, Province'),
(10, 10, '2023-10-20', 1400.00, '765 Fir St, Territory');

-- SELECT * FROM orders;

INSERT INTO order_items (order_item_id, order_id, product_id, quantity, itemAmount)
VALUES 
(1, 1, 1, 2, 1600.00),
(2, 1, 3, 1, 300.00),
(3, 2, 2, 3, 1800.00),
(4, 3, 5, 2, 1800.00),
(5, 4, 4, 4, 600.00),
(6, 4, 6, 1, 50.00),
(7, 5, 1, 1, 800.00),
(8, 5, 2, 2, 1200.00),
(9, 6, 10, 2, 240.00),
(10, 6, 9, 3, 210.00);

-- SELECT * FROM order_items;

-- Update refrigerator product price to 800:
UPDATE products
SET price = 800
WHERE name = 'Refrigerator';
-- SELECT * FROM products;

-- Remove all cart items for a specific customer:

DELETE FROM cart
WHERE customer_id = 6;
SELECT * FROM cart;

-- Retrieve Products Priced Below $100:
SELECT * FROM products
WHERE price < 100;

-- Find Products with Stock Quantity Greater Than 5:
SELECT * FROM products
WHERE stockQuantity > 5;

-- Retrieve Orders with Total Amount Between $500 
-- and $1000:
SELECT * FROM orders
WHERE total_price BETWEEN 500 AND 1000;

-- Find Products which name ends with letter 'r':

SELECT * FROM products
WHERE name LIKE '%r';

-- Retrieve Cart Items for Customer 5:
SELECT * FROM cart
WHERE customer_id = 5;

-- Find Customers Who Placed Orders in 2023:
SELECT DISTINCT customers.* 
FROM customers
JOIN orders ON 
customers.customer_id = orders.customer_id
WHERE YEAR(order_date) = 2023;

-- Determine the Minimum Stock Quantity for Each Product Category:

-- question 9 asks for the minimum stock quantity for each product category,
-- but the dataset provided doesn't explicitly mention a product category
-- so we are adding category column in table products and upadting it

ALTER TABLE products
ADD category VARCHAR(50);

UPDATE products
SET category = CASE
    WHEN name IN ('Laptop', 'Smartphone', 'Tablet') THEN 'Electronics'
    WHEN name IN ('TV', 'Refrigerator', 'Microwave Oven') THEN 'Home Appliances'
    WHEN name IN ('Coffee Maker', 'Blender') THEN 'Kitchen Appliances'
    WHEN name = 'Vacuum Cleaner' THEN 'Cleaning'
    ELSE 'Miscellaneous'
END;

SELECT category, MIN(stockQuantity) AS min_stock
FROM products
GROUP BY category;

-- Calculate the Total Amount Spent by Each Customer:
SELECT customer_id, SUM(total_price) AS total_spent
FROM orders
GROUP BY customer_id;

-- Find the Average Order Amount for Each Customer:
SELECT customer_id, AVG(total_price) AS avg_order_amount
FROM orders
GROUP BY customer_id;

-- Count the Number of Orders Placed by Each Customer:
SELECT customer_id, COUNT(order_id) AS order_count
FROM orders
GROUP BY customer_id;

-- Find the Maximum Order Amount for Each Customer:
SELECT customer_id, MAX(total_price) AS max_order_amount
FROM orders
GROUP BY customer_id;


-- Get Customers Who Placed Orders Totaling Over $1000:
SELECT customer_id, SUM(total_price) AS total_spent
FROM orders
GROUP BY customer_id
HAVING SUM(total_price) > 1000;

-- Subquery to Find Products Not in the Cart:
SELECT * FROM products
WHERE product_id NOT IN 
 (SELECT product_id FROM cart);


--  Subquery to Find Customers Who Haven't Placed Orders:
SELECT * FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM orders);


-- Subquery to Calculate the Percentage of Total Revenue for a Product:
SELECT product_id, (SUM(itemAmount) / 
(SELECT SUM(itemAmount) FROM order_items)) * 100 AS revenue_percentage
FROM order_items
GROUP BY product_id;


-- Subquery to Find Products with Low Stock:

-- we can assume "low stock" refers to products 
-- with a stock quantity below a certain value i.e - 5
SELECT * FROM products
WHERE stockQuantity < 5;



-- Subquery to Find Customers Who Placed High-Value Orders:
SELECT * FROM customers
WHERE customer_id IN 
    (SELECT customer_id FROM orders 
    WHERE total_price > 1000);





























