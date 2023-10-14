USE cargonowdb;
-- Insert random data into the `Customer` table (10 records)
INSERT INTO `Customer` (`f_name`, `l_name`, `phone_number`, `email`, `driving_license`, `dl_expiry_date`)
VALUES
    ('John', 'Doe', '1234567890', 'john.doe@example.com', '987654321', '2024-12-31'),
    ('Alice', 'Smith', '9876543210', 'alice.smith@example.com', '123456789', '2023-11-30'),
    ('Bob', 'Johnson', '5555555555', 'bob.johnson@example.com', '456789123', '2023-10-15'),
    ('Sarah', 'Brown', '4444444444', 'sarah.brown@example.com', '789456123', '2024-02-28'),
    ('David', 'Wilson', '3333333333', 'david.wilson@example.com', '654321987', '2024-09-15'),
    ('Emily', 'Anderson', '2222222222', 'emily.anderson@example.com', '987654321', '2023-12-31'),
    ('Michael', 'Clark', '7777777777', 'michael.clark@example.com', '123987456', '2023-11-15'),
    ('Olivia', 'Garcia', '6666666666', 'olivia.garcia@example.com', '852963741', '2024-03-20'),
    ('Sophia', 'Jones', '9999999999', 'sophia.jones@example.com', '369852147', '2023-10-01'),
    ('Daniel', 'Lee', '8888888888', 'daniel.lee@example.com', '741258963', '2024-04-10');

-- Insert random data into the `Employee` table (10 records)
INSERT INTO `Employee` (`f_name`, `l_name`, `role`, `sin`)
VALUES
    ('Emily', 'Anderson', 'Manager', '789456123'),
    ('Michael', 'Brown', 'Employee', '654789321'),
    ('Sophia', 'Clark', 'Employee', '321654987'),
    ('James', 'Smith', 'Manager', '456123789'),
    ('Emma', 'Johnson', 'Employee', '987321654'),
    ('William', 'Wilson', 'Employee', '654987321'),
    ('Olivia', 'Garcia', 'Manager', '123789456'),
    ('Liam', 'Davis', 'Employee', '789654123'),
    ('Ava', 'Brown', 'Employee', '456123987'),
    ('Noah', 'Martinez', 'Employee', '321987654');
    
-- Insert random data into the `Login` table (10 records)
INSERT INTO `Login` (`user_name`, `password`, `em_id`)
VALUES
    ('user1', 'password1', 1),
    ('user2', 'password2', 2),
    ('user3', 'password3', 3),
    ('user4', 'password4', 4),
    ('user5', 'password5', 5),
    ('user6', 'password6', 6),
    ('user7', 'password7', 7),
    ('user8', 'password8', 8),
    ('user9', 'password9', 9),
    ('user10', 'password10', 10);
    
-- Insert random data into the `Car` table (10 records)
INSERT INTO `Car` (`model`, `availability`, `year`, `color`, `license_plate`, `transmission_type`, `maintenance_history`, `insurance_details`, `price_per_day`)
VALUES
    ('Toyota Camry', 1, 2022, 'Blue', 'ABC123', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 55.00),
    ('Honda Civic', 1, 2021, 'Red', 'XYZ456', 'Automatic', 'Recent servicing', 'Basic insurance', 60.00),
    ('Ford Mustang', 0, 2020, 'Yellow', 'DEF789', 'Manual', 'Full service history', 'Premium insurance', 80.00),
    ('Chevrolet Malibu', 1, 2022, 'Silver', 'GHI789', 'Automatic', 'Regular maintenance', 'Basic insurance', 58.00),
    ('Jeep Wrangler', 1, 2021, 'Green', 'JKL123', 'Manual', 'Full service history', 'Comprehensive insurance', 75.00),
    ('Nissan Altima', 1, 2023, 'Black', 'MNO456', 'Automatic', 'Recent servicing', 'Basic insurance', 65.00),
    ('Subaru Outback', 1, 2022, 'White', 'PQR789', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 70.00),
    ('BMW 3 Series', 1, 2021, 'Silver', 'STU123', 'Automatic', 'Full service history', 'Premium insurance', 85.00),
    ('Kia Sportage', 1, 2023, 'Red', 'VWX456', 'Automatic', 'Recent servicing', 'Basic insurance', 62.00),
    ('Hyundai Elantra', 1, 2020, 'Blue', 'YZA789', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 57.00);

-- Insert random data into the `Rental` table (10 records)
INSERT INTO `Rental` (`check_in`, `check_out`, `car_id`, `cu_id`, `em_id`)
VALUES
    ('2023-09-01 08:00:00', '2023-09-05 16:00:00', 1, 1, 1),
    ('2023-09-03 10:00:00', '2023-09-07 18:00:00', 2, 2, 2),
    ('2023-09-05 12:00:00', '2023-09-09 14:00:00', 3, 3, 3),
    ('2023-09-02 09:00:00', '2023-09-06 17:00:00', 4, 4, 4),
    ('2023-09-04 11:00:00', '2023-09-08 15:00:00', 5, 5, 5),
    ('2023-09-06 13:00:00', '2023-09-10 12:00:00', 6, 6, 6),
    ('2023-09-07 14:00:00', '2023-09-11 11:00:00', 7, 7, 7),
    ('2023-09-08 15:00:00', '2023-09-12 10:00:00', 8, 8, 8),
    ('2023-09-09 16:00:00', '2023-09-13 09:00:00', 9, 9, 9),
    ('2023-09-10 17:00:00', '2023-09-14 08:00:00', 10, 10, 10);
    
-- Insert random data into the `Bill` table (10 records)
INSERT INTO `Bill` (`payment_method`, `amount`, `payment_date`, `r_id`)
VALUES
    ('Credit Card', 125.75,'2023-09-05 16:00:00',1),
    ('Cash', 98.50,'2023-09-05 16:00:00',2),
    ('Debit Card', 200.00,'2023-09-05 16:00:00',10),
    ('Credit Card', 75.25,'2023-09-05 16:00:00',3),
    ('Cash', 102.75,'2023-09-05 16:00:00',4),
    ('Debit Card', 150.00,'2023-09-05 16:00:00',5),
    ('Credit Card', 50.50,'2023-09-05 16:00:00',6),
    ('Cash', 85.00,'2023-09-05 16:00:00',7),
    ('Debit Card', 175.25,'2023-09-05 16:00:00',8),
    ('Credit Card', 125.75,'2023-09-05 16:00:00',9);
    
    
