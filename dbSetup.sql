
-- NOTE you will need to create this table today
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE cars(
  -- NOTE make sure your id column is the first column you define
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  make TINYTEXT NOT NULL,
  model TINYTEXT NOT NULL,
  year INT UNSIGNED NOT NULL,
  color TINYTEXT NOT NULL,
  price MEDIUMINT UNSIGNED NOT NULL,
  mileage MEDIUMINT UNSIGNED NOT NULL,
  engine_type ENUM('small', 'medium', 'large', 'super-size', 'battery'),
  img_url TEXT NOT NULL,
  has_clean_title BOOLEAN NOT NULL DEFAULT true,
  creator_id VARCHAR(255) NOT NULL,
  -- NOTE this will validate that an actual id for an account was used when INSERTING a car into the data base
  -- this will also delete an accounts created cars if the user deletes their account
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
);

INSERT INTO 
cars (make, model, year, price, color, mileage, engine_type, img_url, has_clean_title, creator_id)
VALUES ('mazda', 'miata', 1996, 6000, 'black', 200000, 'small', 'https://images.unsplash.com/photo-1732604226180-9f050e35f7c5?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fG14NXxlbnwwfHwwfHx8MA%3D%3D', true, '65f87bc1e02f1ee243874743');

SELECT * FROM accounts;

SELECT * FROM cars;

DELETE FROM accounts WHERE id = '670ff93326693293c631476f';