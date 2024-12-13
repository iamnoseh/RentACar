CREATE DATABASE rentacars_db;
CREATE TABLE cars
(
    id serial PRIMARY key,
    model VARCHAR(50),
    manufacturer varchar(100),
    year int,
    priceperday DECIMAL(10,2)
)
CREATE TABLE customers
(
    id serial PRIMARY key,
    fullname VARCHAR(100),
    phone varchar(20),
    email varchar(50) unique
);
CREATE TABLE location
(
    id serial PRIMARY key,
    city varchar(100),
    address text
);

CREATE TABLE rentals
(
    id serial primary key,
    car_id int REFERENCES cars(id) on delete cascade,
    customer_id int REFERENCES customers(id) on delete cascade,
    startdate TIMESTAMP,
    enddate TIMESTAMP,
    totalcost DECIMAL(10,2)
);

CREATE TABLE carlocations
(
    car_id int REFERENCES cars(id) on delete cascade,
    location_id int REFERENCES customers(id) on delete cascade
);


INSERT INTO cars (model, manufacturer, year, priceperday) VALUES
                                                              ('Toyota Corolla', 'Toyota', 2020, 45.50),
                                                              ('Hyundai Elantra', 'Hyundai', 2021, 50.00),
                                                              ('BMW X5', 'BMW', 2022, 120.99),
                                                              ('Mercedes-Benz C200', 'Mercedes-Benz', 2019, 95.75),
                                                              ('Honda Civic', 'Honda', 2018, 40.00);


INSERT INTO customers (fullname, phone, email) VALUES
                                                   ('Аҳмадов Али', '+992981234567', 'ahmadov.ali@gmail.com'),
                                                   ('Сафаров Бахтиёр', '+992981111222', 'safarov.bakhtiyor@yahoo.com'),
                                                   ('Шарипова Нилуфар', '+992987654321', 'nilu.sharipova@mail.ru'),
                                                   ('Зуҳуров Дилшод', '+992981122334', 'dilshod.zuhurov@gmail.com'),
                                                   ('Каримова Сабрина', '+992987899900', 'karimova.sabrina@gmail.com');

INSERT INTO location (city, address) VALUES
                                         ('Душанбе', 'кӯчаи Рӯдакӣ, 100'),
                                         ('Хуҷанд', 'кӯчаи Бобоҷон Ғафуров, 50'),
                                         ('Бохтар', 'кӯчаи Носири Хусрав, 10'),
                                         ('Кӯлоб', 'кӯчаи Айнӣ, 75'),
                                         ('Ваҳдат', 'кӯчаи Сино, 200');


INSERT INTO rentals (car_id, customer_id, startdate, enddate, totalcost) VALUES
                                                                             (1, 2, '2024-12-01 09:00:00', '2024-12-05 18:00:00', 227.50),
                                                                             (3, 1, '2024-12-10 12:00:00', '2024-12-15 14:00:00', 604.95),
                                                                             (5, 4, '2024-11-20 10:30:00', '2024-11-25 16:30:00', 200.00),
                                                                             (2, 3, '2024-12-05 08:00:00', '2024-12-10 20:00:00', 250.00),
                                                                             (4, 5, '2024-12-12 09:15:00', '2024-12-16 19:45:00', 383.00);


INSERT INTO carlocations (car_id, location_id) VALUES
                                                   (1, 1),
                                                   (2, 2),
                                                   (3, 3),
                                                   (4, 4),
                                                   (5, 5);
