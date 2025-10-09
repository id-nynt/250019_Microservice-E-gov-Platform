CREATE TABLE accounts (
    user_id TEXT NOT NULL,
    name TEXT NOT NULL
);

CREATE TABLE vaccinations (
    id SERIAL PRIMARY KEY,
    user_id TEXT NOT NULL,
    type TEXT NOT NULL,
    vacc_date TIMESTAMP NOT NULL
);



INSERT INTO accounts (user_id, name) VALUES
('aab','Alice Conway'),
('aac','Bob Johnson'),
('aad','Charles Leone'),
('aae','Dana White'),
('aaf','Elanor Jones');



INSERT INTO vaccinations (id, user_id, type, vacc_date) VALUES 
('1','aab', 'Pfizer', '2023-03-15 10:30:00'),
('2','aab', 'Pfizer', '2023-03-21 11:30:00'),
('3','aac', 'Moderna', '2023-04-02 14:00:00'),
('4','aad', 'AstraZeneca', '2022-12-20 09:00:00'),
('5','aae', 'Novavax', '2023-01-10 11:45:00');