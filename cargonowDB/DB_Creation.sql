DROP DATABASE IF EXISTS cargonowdb;
CREATE DATABASE IF NOT EXISTS cargonowdb;
USE cargonowdb;

CREATE TABLE `Login`(
    `l_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `user_name` TEXT NOT NULL,
    `password` TEXT NOT NULL,
    `em_id` BIGINT NOT NULL,
    `created_at` DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS `Customer`(
    `cu_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `f_name` TEXT NOT NULL,
    `l_name` TEXT NOT NULL,
    `phone_number` TEXT NOT NULL,
    `email` TEXT NOT NULL,
    `driving_license` TEXT NOT NULL,
    `dl_expiry_date` DATE NOT NULL,
    `created_at` DATETIME NOT NULL
);
CREATE TABLE IF NOT EXISTS `Employee`(
    `em_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `f_name` TEXT NOT NULL,
    `l_name` TEXT NOT NULL,
    `role` TEXT NOT NULL,
    `sin` TEXT NOT NULL,
    `created_at` DATETIME NOT NULL
);
CREATE TABLE IF NOT EXISTS `Bill`(
    `bill_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `payment_method` TEXT NOT NULL,
    `amount` DOUBLE(8, 2) NOT NULL,
    `payment_date` DATETIME NOT NULL,
    `r_id` BIGINT NOT NULL,
    `created_at` DATETIME NOT NULL
);
CREATE TABLE IF NOT EXISTS `Car`(
    `car_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `model` TEXT NOT NULL,
    `availability` TINYINT(1) NOT NULL,
    `year` INT NOT NULL,
    `color` TEXT NOT NULL,
    `license_plate` TEXT NOT NULL,
    `transmission_type` TEXT NOT NULL,
    `maintenance_history` TEXT NOT NULL,
    `insurance_details` TEXT NOT NULL,
    `price_per_day` DOUBLE(8, 2) NOT NULL,
    `created_at` DATETIME NOT NULL
);
CREATE TABLE IF NOT EXISTS `Rental`(
    `r_id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `check_in` DATETIME NOT NULL,
    `check_out` DATETIME NOT NULL,
    `car_id` BIGINT NOT NULL,
    `cu_id` BIGINT NOT NULL,
    `em_id` BIGINT NOT NULL,
    `created_at` DATETIME NOT NULL
);
ALTER TABLE
    `Rental` ADD CONSTRAINT `rental_em_id_foreign` FOREIGN KEY(`em_id`) REFERENCES `Employee`(`em_id`);
ALTER TABLE
    `Rental` ADD CONSTRAINT `rental_car_id_foreign` FOREIGN KEY(`car_id`) REFERENCES `Car`(`car_id`);
ALTER TABLE
    `Rental` ADD CONSTRAINT `rental_cu_id_foreign` FOREIGN KEY(`cu_id`) REFERENCES `Customer`(`cu_id`);
ALTER TABLE
    `Bill` ADD CONSTRAINT `bill_rental_id_foreign` FOREIGN KEY(`r_id`) REFERENCES `Rental`(`r_id`);
ALTER TABLE
    `Login` ADD CONSTRAINT `login_id_foreign` FOREIGN KEY(`em_id`) REFERENCES `Employee`(`em_id`);