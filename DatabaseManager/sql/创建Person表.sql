CREATE TABLE IF NOT EXISTS `person` (
  `id` INT AUTO_INCREMENT PRIMARY KEY,
  `name` VARCHAR(20),
  `age` VARCHAR(10),
  `gender` ENUM('男', '女'),
  `email` VARCHAR(100)
);
