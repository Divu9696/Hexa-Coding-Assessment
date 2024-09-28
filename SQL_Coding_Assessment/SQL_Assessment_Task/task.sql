USE SQLPractice;

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    Email VARCHAR(50)
);

CREATE TABLE OrderTable (
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
    ON DELETE CASCADE
);

INSERT INTO Customer (CustomerID, CustomerName, Email) VALUES
(1, 'John Doe', 'john@example.com'),
(2, 'Jane Smith', 'jane@example.com'),
(3, 'Alice Johnson', 'alice@example.com'),
(4, 'Bob Brown', 'bob@example.com'),
(5, 'Charlie Davis', 'charlie@example.com'),
(6, 'Diana Prince', 'diana@example.com'),
(7, 'Eve Black', 'eve@example.com'),
(8, 'Frank White', 'frank@example.com');

SELECT * FROM Customer;
SELECT * FROM OrderTable;

INSERT INTO OrderTable (OrderID, OrderDate, CustomerID) VALUES
(101, '2023-09-20', 1),
(102, '2023-09-21', 2),
(103, '2023-09-22', 3),
(104, '2023-09-23', 4),
(105, '2023-09-24', 5),
(106, '2023-09-25', 6),
(107, '2023-09-26', 7),
(108, '2023-09-27', 8);

-- Deleting record using Join 
DELETE Customer
FROM Customer
JOIN OrderTable ON Customer.CustomerID = OrderTable.CustomerID
WHERE Customer.CustomerID = 2;

SELECT * FROM Customer;
SELECT * FROM OrderTable;








