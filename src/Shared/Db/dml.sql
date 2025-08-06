-- =====================================================
-- INSERTS PARA POBLAR LA BASE DE DATOS GESTOR_TORNEOS
-- =====================================================

-- 1. INSERTAR PAÍSES
INSERT INTO Countries (name) VALUES
('España'),
('Argentina'),
('Brasil'),
('Francia'),
('Alemania'),
('Italia'),
('Inglaterra'),
('Portugal'),
('Holanda'),
('Bélgica'),
('Uruguay'),
('Colombia'),
('Chile'),
('México'),
('Estados Unidos');

-- 2. INSERTAR POSICIONES
INSERT INTO Positions (name) VALUES
('Portero'),
('Defensa Central'),
('Lateral Derecho'),
('Lateral Izquierdo'),
('Centrocampista Defensivo'),
('Centrocampista'),
('Centrocampista Ofensivo'),
('Extremo Derecho'),
('Extremo Izquierdo'),
('Delantero Centro'),
('Segundo Delantero'),
('Mediapunta');

-- 3. INSERTAR CIUDADES
INSERT INTO Cities (name) VALUES
('Madrid'),
('Barcelona'),
('Buenos Aires'),
('São Paulo'),
('París'),
('Múnich'),
('Milán'),
('Londres'),
('Lisboa'),
('Ámsterdam'),
('Bruselas'),
('Montevideo'),
('Bogotá'),
('Santiago'),
('Ciudad de México'),
('Nueva York'),
('Valencia'),
('Sevilla'),
('Bilbao'),
('Málaga');

-- 4. INSERTAR TIPOS DE STAFF
INSERT INTO StaffTypes (name) VALUES
('Cuerpo Técnico'),
('Cuerpo Médico');

-- 5. INSERTAR ROLES DE STAFF
INSERT INTO StaffRoles (name, type_id) VALUES
-- Roles Técnicos
('Entrenador Principal', 1),
('Entrenador Asistente', 1),
('Entrenador de Porteros', 1),
-- Roles Médicos
('Médico Principal', 2),
('Médico Asistente', 2),
('Fisioterapeuta Principal', 2),
('Fisioterapeuta Asistente', 2);

-- 6. INSERTAR EQUIPOS
INSERT INTO Teams (name, city_id) VALUES
('Real Madrid', 1),
('FC Barcelona', 2),
('River Plate', 3),
('Flamengo', 4),
('Paris Saint-Germain', 5),
('Bayern Munich', 6),
('AC Milan', 7),
('Manchester City', 8),
('Benfica', 9),
('Ajax', 10),
('Club Brugge', 11),
('Peñarol', 12),
('Atlético Nacional', 13),
('Colo-Colo', 14),
('América', 15),
('New York City FC', 16),
('Valencia CF', 17),
('Sevilla FC', 18),
('Athletic Bilbao', 19),
('Málaga CF', 20);

-- 7. INSERTAR TORNEOS
INSERT INTO Tournaments (name, start_date, end_date) VALUES
('Liga Española 2024', '2024-08-15', '2024-05-25'),
('Copa Libertadores 2024', '2024-02-15', '2024-11-30'),
('Champions League 2024/25', '2024-09-15', '2025-06-01'),
('Premier League 2024/25', '2024-08-10', '2025-05-25'),
('Serie A 2024/25', '2024-08-20', '2025-05-20'),
('Bundesliga 2024/25', '2024-08-18', '2025-05-17'),
('Ligue 1 2024/25', '2024-08-12', '2025-05-25'),
('Copa del Rey 2024/25', '2024-10-15', '2025-04-20');

-- 8. INSERTAR JUGADORES
INSERT INTO Players (team_id, name, country_id, position_id, dorsal, birth_date, market_value) VALUES
-- Real Madrid
(1, 'Vinicius Jr.', 3, 9, 7, '2000-07-12', 95000000.00), -- Extremo Izquierdo
(1, 'Jude Bellingham', 7, 7, 5, '2003-06-29', 85000000.00), -- Centrocampista Ofensivo
(1, 'Thibaut Courtois', 10, 1, 1, '1992-05-11', 45000000.00), -- Portero
(1, 'Antonio Rüdiger', 5, 2, 22, '1993-03-03', 40000000.00), -- Defensa Central
(1, 'Federico Valverde', 12, 6, 15, '1998-07-22', 95000000.00), -- Centrocampista

-- FC Barcelona
(2, 'Robert Lewandowski', 5, 10, 9, '1988-08-21', 35000000.00), -- Delantero Centro
(2, 'Frenkie de Jong', 9, 6, 21, '1997-05-12', 90000000.00), -- Centrocampista
(2, 'Pedri González', 1, 7, 8, '2002-11-25', 95000000.00), -- Centrocampista Ofensivo
(2, 'Gavi Páez', 1, 7, 6, '2004-08-05', 90000000.00), -- Centrocampista Ofensivo
(2, 'Marc-André ter Stegen', 5, 1, 1, '1992-04-30', 35000000.00), -- Portero

-- River Plate
(3, 'Enzo Fernández', 2, 6, 5, '2001-01-17', 80000000.00), -- Centrocampista
(3, 'Julian Álvarez', 2, 10, 9, '2000-01-31', 70000000.00), -- Delantero Centro
(3, 'Franco Armani', 2, 1, 1, '1986-10-16', 8000000.00), -- Portero
(3, 'Nicolás De La Cruz', 12, 7, 11, '1997-06-01', 25000000.00), -- Centrocampista Ofensivo
(3, 'Esequiel Barco', 2, 7, 10, '1999-03-29', 15000000.00), -- Centrocampista Ofensivo

-- Flamengo
(4, 'Gabigol', 3, 10, 9, '1996-08-30', 25000000.00), -- Delantero Centro
(4, 'Bruno Henrique', 3, 8, 27, '1990-12-30', 20000000.00), -- Extremo Derecho
(4, 'Pedro', 3, 10, 9, '1997-06-20', 30000000.00), -- Delantero Centro
(4, 'Gerson', 3, 6, 8, '1997-05-20', 25000000.00), -- Centrocampista
(4, 'Diego Alves', 3, 1, 1, '1985-06-24', 5000000.00), -- Portero

-- Paris Saint-Germain
(5, 'Kylian Mbappé', 4, 9, 7, '1998-12-20', 95000000.00), -- Extremo Izquierdo
(5, 'Lionel Messi', 2, 8, 30, '1987-06-24', 35000000.00), -- Extremo Derecho
(5, 'Neymar Jr.', 3, 9, 10, '1992-02-05', 60000000.00), -- Extremo Izquierdo
(5, 'Marco Verratti', 6, 6, 6, '1992-11-05', 40000000.00), -- Centrocampista
(5, 'Gianluigi Donnarumma', 6, 1, 99, '1999-02-25', 45000000.00), -- Portero

-- Bayern Munich
(6, 'Harry Kane', 7, 10, 9, '1993-07-28', 95000000.00), -- Delantero Centro
(6, 'Joshua Kimmich', 5, 3, 6, '1995-02-08', 75000000.00), -- Lateral Derecho
(6, 'Jamal Musiala', 5, 7, 42, '2003-02-26', 95000000.00), -- Centrocampista Ofensivo
(6, 'Alphonso Davies', 15, 4, 19, '2000-11-02', 70000000.00), -- Lateral Izquierdo
(6, 'Manuel Neuer', 5, 1, 1, '1986-03-27', 12000000.00), -- Portero

-- AC Milan
(7, 'Rafael Leão', 8, 9, 10, '1999-06-10', 90000000.00), -- Extremo Izquierdo
(7, 'Theo Hernández', 4, 4, 19, '1997-10-06', 60000000.00), -- Lateral Izquierdo
(7, 'Mike Maignan', 4, 1, 16, '1995-07-03', 45000000.00), -- Portero
(7, 'Ismaël Bennacer', 4, 6, 4, '1997-12-01', 40000000.00), -- Centrocampista
(7, 'Olivier Giroud', 4, 10, 9, '1986-09-30', 8000000.00), -- Delantero Centro

-- Manchester City
(8, 'Erling Haaland', 11, 10, 9, '2000-07-21', 95000000.00), -- Delantero Centro
(8, 'Kevin De Bruyne', 10, 7, 17, '1991-06-28', 60000000.00), -- Centrocampista Ofensivo
(8, 'Phil Foden', 7, 7, 47, '2000-05-28', 95000000.00), -- Centrocampista Ofensivo
(8, 'Rúben Dias', 8, 2, 3, '1997-05-14', 80000000.00), -- Defensa Central
(8, 'Ederson', 3, 1, 31, '1993-08-17', 45000000.00), -- Portero

-- Benfica
(9, 'João Félix', 8, 10, 11, '1999-11-10', 50000000.00), -- Delantero Centro
(9, 'Enzo Fernández', 2, 6, 13, '2001-01-17', 80000000.00), -- Centrocampista
(9, 'Rafa Silva', 8, 8, 27, '1993-05-17', 25000000.00), -- Extremo Derecho
(9, 'Odisseas Vlachodimos', 5, 1, 99, '1994-04-26', 15000000.00), -- Portero
(9, 'Nicolás Otamendi', 2, 2, 30, '1988-02-12', 8000000.00), -- Defensa Central

-- Ajax
(10, 'Mohammed Kudus', 11, 7, 20, '2000-08-02', 40000000.00), -- Centrocampista Ofensivo
(10, 'Steven Bergwijn', 9, 8, 7, '1997-10-08', 25000000.00), -- Extremo Derecho
(10, 'Dusan Tadic', 11, 10, 10, '1988-11-20', 15000000.00), -- Delantero Centro
(10, 'Remko Pasveer', 9, 1, 1, '1983-11-08', 2000000.00), -- Portero
(10, 'Jurriën Timber', 9, 2, 2, '2001-06-17', 45000000.00); -- Defensa Central

-- 9. INSERTAR STAFF
INSERT INTO Staff (team_id, name, country_id, role_id) VALUES
-- Real Madrid Staff
(1, 'Carlo Ancelotti', 6, 1), -- Entrenador Principal
(1, 'Davide Ancelotti', 6, 2), -- Entrenador Asistente
(1, 'Luis Llopis', 1, 3), -- Entrenador de Porteros
(1, 'Dr. Niko Mihic', 5, 4), -- Médico Principal
(1, 'Dr. Jesús Olmo', 1, 5), -- Médico Asistente
(1, 'José Carlos Parrales', 1, 6), -- Fisioterapeuta Principal
(1, 'Carlos Lalin', 1, 7), -- Fisioterapeuta Asistente

-- FC Barcelona Staff
(2, 'Xavi Hernández', 1, 1), -- Entrenador Principal
(2, 'Óscar Hernández', 1, 2), -- Entrenador Asistente
(2, 'José Ramón de la Fuente', 1, 3), -- Entrenador de Porteros
(2, 'Dr. Ricard Pruna', 1, 4), -- Médico Principal
(2, 'Dr. Daniel Medina', 1, 5), -- Médico Asistente
(2, 'Jaume Munill', 1, 6), -- Fisioterapeuta Principal
(2, 'Joan Carles Medina', 1, 7), -- Fisioterapeuta Asistente

-- River Plate Staff
(3, 'Martín Demichelis', 2, 1), -- Entrenador Principal
(3, 'Hernán Buján', 2, 2), -- Entrenador Asistente
(3, 'Germán Lux', 2, 3), -- Entrenador de Porteros
(3, 'Dr. Pedro Hansing', 2, 4), -- Médico Principal
(3, 'Dr. Diego Yacob', 2, 5), -- Médico Asistente
(3, 'Carlos Ponce', 2, 6), -- Fisioterapeuta Principal
(3, 'Dr. Gustavo Yacob', 2, 7), -- Fisioterapeuta Asistente

-- Flamengo Staff
(4, 'Jorge Sampaoli', 2, 1), -- Entrenador Principal
(4, 'Sebastián Beccacece', 2, 2), -- Entrenador Asistente
(4, 'Roberto Gattuso', 2, 3), -- Entrenador de Porteros
(4, 'Dr. Márcio Tannure', 3, 4), -- Médico Principal
(4, 'Dr. Rodrigo Lasmar', 3, 5), -- Médico Asistente
(4, 'Bruno Mazziotti', 3, 6), -- Fisioterapeuta Principal
(4, 'Dr. Paulo Roberto', 3, 7), -- Fisioterapeuta Asistente

-- Paris Saint-Germain Staff
(5, 'Luis Enrique', 1, 1), -- Entrenador Principal
(5, 'Rafael Pol', 1, 2), -- Entrenador Asistente
(5, 'Juan Carlos Unzué', 1, 3), -- Entrenador de Porteros
(5, 'Dr. Christophe Baudot', 4, 4), -- Médico Principal
(5, 'Dr. Emmanuel Orhant', 4, 5), -- Médico Asistente
(5, 'Philippe Lambert', 4, 6), -- Fisioterapeuta Principal
(5, 'Dr. Jean-Marcel Ferret', 4, 7); -- Fisioterapeuta Asistente

-- 10. INSERTAR EQUIPOS EN TORNEOS
INSERT INTO TournamentTeams (tournament_id, team_id) VALUES
-- Liga Española 2024
(1, 1), (1, 2), (1, 17), (1, 18), (1, 19), (1, 20),

-- Copa Libertadores 2024
(2, 3), (2, 4), (2, 12), (2, 13), (2, 14), (2, 15),

-- Champions League 2024/25
(3, 1), (3, 2), (3, 5), (3, 6), (3, 7), (3, 8), (3, 9), (3, 10),

-- Premier League 2024/25
(4, 8),

-- Serie A 2024/25
(5, 7),

-- Bundesliga 2024/25
(6, 6),

-- Ligue 1 2024/25
(7, 5);

-- 11. INSERTAR PARTIDOS
INSERT INTO Matches (tournament_id, home_team_id, away_team_id, match_date, home_score, away_score) VALUES
-- Liga Española 2024
(1, 1, 2, '2024-08-20', 3, 1),
(1, 2, 1, '2024-12-15', 2, 2),
(1, 17, 18, '2024-09-10', 1, 0),
(1, 19, 20, '2024-09-15', 2, 1),
(1, 1, 17, '2024-10-05', 4, 0),
(1, 2, 19, '2024-10-12', 3, 2),

-- Copa Libertadores 2024
(2, 3, 4, '2024-03-15', 2, 1),
(2, 4, 3, '2024-05-20', 1, 3),
(2, 12, 13, '2024-04-10', 0, 2),
(2, 14, 15, '2024-04-15', 1, 1),

-- Champions League 2024/25
(3, 1, 5, '2024-09-25', 2, 1),
(3, 6, 7, '2024-09-26', 3, 0),
(3, 8, 9, '2024-10-02', 4, 2),
(3, 10, 2, '2024-10-03', 1, 3),
(3, 5, 1, '2024-10-23', 1, 2),
(3, 7, 6, '2024-10-24', 0, 2);

-- 12. INSERTAR ESTADÍSTICAS DE JUGADORES
INSERT INTO PlayerStats (player_id, match_id, goals, assists, minutes_played) VALUES
-- Estadísticas de Vinicius Jr.
(1, 1, 2, 1, 90), -- Real Madrid vs Barcelona (Liga)
(1, 2, 0, 1, 90), -- Barcelona vs Real Madrid (Liga)
(1, 11, 1, 0, 85), -- Real Madrid vs PSG (Champions)

-- Estadísticas de Jude Bellingham
(2, 1, 1, 0, 90), -- Real Madrid vs Barcelona (Liga)
(2, 2, 1, 1, 90), -- Barcelona vs Real Madrid (Liga)
(2, 11, 0, 1, 90), -- Real Madrid vs PSG (Champions)

-- Estadísticas de Robert Lewandowski
(6, 1, 0, 0, 90), -- Real Madrid vs Barcelona (Liga)
(6, 2, 2, 0, 90), -- Barcelona vs Real Madrid (Liga)
(6, 14, 1, 0, 90), -- Ajax vs Barcelona (Champions)

-- Estadísticas de Frenkie de Jong
(7, 1, 0, 1, 90), -- Real Madrid vs Barcelona (Liga)
(7, 2, 0, 1, 90), -- Barcelona vs Real Madrid (Liga)
(7, 14, 0, 1, 90), -- Ajax vs Barcelona (Champions)

-- Estadísticas de Enzo Fernández (River)
(10, 7, 1, 1, 90), -- River vs Flamengo (Libertadores)
(10, 8, 0, 2, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Julian Álvarez
(11, 7, 1, 0, 90), -- River vs Flamengo (Libertadores)
(11, 8, 2, 0, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Gabigol
(15, 7, 0, 0, 90), -- River vs Flamengo (Libertadores)
(15, 8, 1, 0, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Kylian Mbappé
(20, 11, 1, 0, 90), -- Real Madrid vs PSG (Champions)
(20, 15, 0, 1, 90), -- PSG vs Real Madrid (Champions)

-- Estadísticas de Harry Kane
(25, 12, 2, 0, 90), -- Bayern vs Milan (Champions)
(25, 16, 1, 0, 90), -- Milan vs Bayern (Champions)

-- Estadísticas de Erling Haaland
(35, 13, 3, 0, 90), -- Man City vs Benfica (Champions)
(35, 16, 1, 1, 90), -- Milan vs Bayern (Champions)

-- Estadísticas de Kevin De Bruyne
(36, 13, 0, 2, 90), -- Man City vs Benfica (Champions)
(36, 16, 1, 1, 90); -- Milan vs Bayern (Champions)

-- 13. INSERTAR TRANSFERENCIAS
INSERT INTO Transfers (player_id, origin_team_id, destination_team_id, transfer_date, transfer_type, amount) VALUES
-- Transferencias de compra
(2, NULL, 1, '2023-07-01', 'Buy', 95000000.00), -- Bellingham a Real Madrid
(20, NULL, 5, '2017-08-31', 'Buy', 95000000.00), -- Mbappé a PSG
(25, NULL, 6, '2023-08-12', 'Buy', 95000000.00), -- Kane a Bayern
(35, NULL, 8, '2022-07-01', 'Buy', 60000000.00), -- Haaland a Man City
(1, NULL, 1, '2018-07-12', 'Buy', 45000000.00), -- Vinicius a Real Madrid

-- Transferencias de préstamo
(9, 2, 1, '2024-01-15', 'Loan', NULL), -- Gavi prestado a Real Madrid
(16, 4, 3, '2024-02-01', 'Loan', NULL), -- Bruno Henrique prestado a River
(31, 9, 8, '2024-01-20', 'Loan', NULL), -- João Félix prestado a Man City
(40, 10, 2, '2024-02-10', 'Loan', NULL), -- Kudus prestado a Barcelona

-- Transferencias históricas
(10, 3, 8, '2023-01-31', 'Buy', 95000000.00), -- Enzo Fernández a Chelsea
(11, 3, 8, '2022-07-01', 'Buy', 21400000.00), -- Julian Álvarez a Man City
(6, NULL, 2, '2022-07-19', 'Buy', 45000000.00), -- Lewandowski a Barcelona
(7, 10, 2, '2019-07-01', 'Buy', 75000000.00), -- De Jong a Barcelona
(8, 2, 2, '2021-08-01', 'Buy', 5000000.00), -- Pedri a Barcelona (juvenil)
(9, 2, 2, '2021-07-01', 'Buy', 0.00); -- Gavi a Barcelona (juvenil)
