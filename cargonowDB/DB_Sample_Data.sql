USE cargonowdb;
-- Insert random data into the `Customer` table (10 records)
INSERT INTO `Customer` (`f_name`, `l_name`, `phone_number`, `email`, `driving_license`, `dl_expiry_date`, `created_at`)
VALUES
    ('John', 'Doe', '1234567890', 'john.doe@example.com', '987654321', '2024-12-31', NOW()),
    ('Alice', 'Smith', '9876543210', 'alice.smith@example.com', '123456789', '2023-11-30', NOW()),
    ('Bob', 'Johnson', '5555555555', 'bob.johnson@example.com', '456789123', '2023-10-15', NOW()),
    ('Sarah', 'Brown', '4444444444', 'sarah.brown@example.com', '789456123', '2024-02-28', NOW()),
    ('David', 'Wilson', '3333333333', 'david.wilson@example.com', '654321987', '2024-09-15', NOW()),
    ('Emily', 'Anderson', '2222222222', 'emily.anderson@example.com', '987654321', '2023-12-31', NOW()),
    ('Michael', 'Clark', '7777777777', 'michael.clark@example.com', '123987456', '2023-11-15', NOW()),
    ('Olivia', 'Garcia', '6666666666', 'olivia.garcia@example.com', '852963741', '2024-03-20', NOW()),
    ('Sophia', 'Jones', '9999999999', 'sophia.jones@example.com', '369852147', '2023-10-01', NOW()),
    ('Daniel', 'Lee', '8888888888', 'daniel.lee@example.com', '741258963', '2024-04-10', NOW());

-- Insert random data into the `Employee` table (10 records)
INSERT INTO `Employee` (`f_name`, `l_name`, `role`, `sin`, `created_at`)
VALUES
    ('Emily', 'Anderson', 'Manager', '789456123', NOW()),
    ('Michael', 'Brown', 'Employee', '654789321', NOW()),
    ('Sophia', 'Clark', 'Employee', '321654987', NOW()),
    ('James', 'Smith', 'Manager', '456123789', NOW()),
    ('Emma', 'Johnson', 'Employee', '987321654', NOW()),
    ('William', 'Wilson', 'Employee', '654987321', NOW()),
    ('Olivia', 'Garcia', 'Manager', '123789456', NOW()),
    ('Liam', 'Davis', 'Employee', '789654123', NOW()),
    ('Ava', 'Brown', 'Employee', '456123987', NOW()),
    ('Noah', 'Martinez', 'Employee', '321987654', NOW());
    
-- Insert random data into the `Login` table (10 records)
INSERT INTO `Login` (`user_name`, `password`, `em_id`, `created_at`)
VALUES
    ('user1', 'password1', 1, NOW()),
    ('user2', 'password2', 2, NOW()),
    ('user3', 'password3', 3, NOW()),
    ('user4', 'password4', 4, NOW()),
    ('user5', 'password5', 5, NOW()),
    ('user6', 'password6', 6, NOW()),
    ('user7', 'password7', 7, NOW()),
    ('user8', 'password8', 8, NOW()),
    ('user9', 'password9', 9, NOW()),
    ('user10', 'password10', 10, NOW());
    
-- Insert random data into the `Car` table (10 records)
INSERT INTO `Car` (`model`, `availability`, `year`, `color`, `license_plate`, `transmission_type`, `maintenance_history`, `insurance_details`, `price_per_day`, `created_at`)
VALUES
    ('Toyota Camry', 1, 2022, 'Blue', 'ABC123', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 55.00, NOW()),
    ('Honda Civic', 1, 2021, 'Red', 'XYZ456', 'Automatic', 'Recent servicing', 'Basic insurance', 60.00, NOW()),
    ('Ford Mustang', 0, 2020, 'Yellow', 'DEF789', 'Manual', 'Full service history', 'Premium insurance', 80.00, NOW()),
    ('Chevrolet Malibu', 1, 2022, 'Silver', 'GHI789', 'Automatic', 'Regular maintenance', 'Basic insurance', 58.00, NOW()),
    ('Jeep Wrangler', 1, 2021, 'Green', 'JKL123', 'Manual', 'Full service history', 'Comprehensive insurance', 75.00, NOW()),
    ('Nissan Altima', 1, 2023, 'Black', 'MNO456', 'Automatic', 'Recent servicing', 'Basic insurance', 65.00, NOW()),
    ('Subaru Outback', 1, 2022, 'White', 'PQR789', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 70.00, NOW()),
    ('BMW 3 Series', 1, 2021, 'Silver', 'STU123', 'Automatic', 'Full service history', 'Premium insurance', 85.00, NOW()),
    ('Kia Sportage', 1, 2023, 'Red', 'VWX456', 'Automatic', 'Recent servicing', 'Basic insurance', 62.00, NOW()),
    ('Hyundai Elantra', 1, 2020, 'Blue', 'YZA789', 'Automatic', 'Regular maintenance', 'Comprehensive insurance', 57.00, NOW());

-- Insert random data into the `Rental` table (10 records)
INSERT INTO `Rental` (`check_in`, `check_out`, `car_id`, `cu_id`, `em_id`, `created_at`)
VALUES
    ('2023-09-01 08:00:00', '2023-09-05 16:00:00', 1, 1, 1, NOW()),
    ('2023-09-03 10:00:00', '2023-09-07 18:00:00', 2, 2, 2, NOW()),
    ('2023-09-05 12:00:00', '2023-09-09 14:00:00', 3, 3, 3, NOW()),
    ('2023-09-02 09:00:00', '2023-09-06 17:00:00', 4, 4, 4, NOW()),
    ('2023-09-04 11:00:00', '2023-09-08 15:00:00', 5, 5, 5, NOW()),
    ('2023-09-06 13:00:00', '2023-09-10 12:00:00', 6, 6, 6, NOW()),
    ('2023-09-07 14:00:00', '2023-09-11 11:00:00', 7, 7, 7, NOW()),
    ('2023-09-08 15:00:00', '2023-09-12 10:00:00', 8, 8, 8, NOW()),
    ('2023-09-09 16:00:00', '2023-09-13 09:00:00', 9, 9, 9, NOW()),
    ('2023-09-10 17:00:00', '2023-09-14 08:00:00', 10, 10, 10, NOW());
    
-- Insert random data into the `Bill` table (10 records)
INSERT INTO `Bill` (`payment_method`, `amount`, `payment_date`, `r_id`,`created_at`)
VALUES
    ('Credit Card', 125.75, NOW(),1,NOW()),
    ('Cash', 98.50, NOW(),2,NOW()),
    ('Debit Card', 200.00, NOW(),10,NOW()),
    ('Credit Card', 75.25, NOW(),3,NOW()),
    ('Cash', 102.75, NOW(),4,NOW()),
    ('Debit Card', 150.00, NOW(),5,NOW()),
    ('Credit Card', 50.50, NOW(),6,NOW()),
    ('Cash', 85.00, NOW(),7,NOW()),
    ('Debit Card', 175.25, NOW(),8,NOW()),
    ('Credit Card', 125.75, NOW(),9,NOW());
    
    
