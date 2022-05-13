CREATE TABLE Categories (
id INT IDENTITY(1, 1) NOT NULL,
name_of varchar(50) NOT NULL,
PRIMARY KEY(id)
);

INSERT INTO Categories (name_of) VALUES 
('Fitness shoes'), 
('Walking shoes'), 
('business shoes'),
('Beach shoes'),  
('Home shoes');

CREATE TABLE Products (
id INT IDENTITY(1, 1) NOT NULL,
name_of varchar(50) NOT NULL,
CategoryID1 INT,
CategoryID2 INT,
PRIMARY KEY(id)
);

INSERT INTO Products (name_of, CategoryID1, CategoryID2) VALUES 
('Sneakers', 1, 2), 
('shoes', 3, 0), 
('slippers', 4, 5), 
('sandals', 2, 4), 
('boots', 3, 2), 
('football boots', 0, 0);

SELECT Products.name_of, Categories.name_of
FROM Products LEFT JOIN Categories
ON Categories.id = Products.CategoryID1 OR Categories.id = Products.CategoryID2