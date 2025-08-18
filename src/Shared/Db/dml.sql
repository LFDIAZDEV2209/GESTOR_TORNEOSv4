-- =====================================================
-- DML ACTUALIZADO PARA GESTOR_TORNEOSv4
-- Coincide exactamente con el DDL actualizado
-- Orden de inserts: BASE -> DEPENDENCIAS -> COMPLEJAS
-- =====================================================

-- 1. INSERTAR POSICIONES (BASE - sin dependencias)
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
('Mediapunta'),
('Libero'),
('Carrilero'),
('Volante de Enlace'),
('Falso 9'),
('Mediapunta Defensivo'),
('Extremo Invertido'),
('Delantero Secundario'),
('Portero-Líbero');

-- 2. INSERTAR CIUDADES (BASE - sin dependencias)
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
('Málaga'),
('Tokio'),
('Seúl'),
('Sídney'),
('Toronto'),
('Casablanca'),
('Dakar'),
('El Cairo'),
('Lagos'),
('Accra'),
('Abiyán'),
('Túnez'),
('Argel'),
('Pretoria'),
('Yaundé'),
('Bamako');

-- 3. INSERTAR PAÍSES (BASE - sin dependencias)
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
('Estados Unidos'),
('Japón'),
('Corea del Sur'),
('Australia'),
('Canadá'),
('Marruecos'),
('Senegal'),
('Egipto'),
('Nigeria'),
('Ghana'),
('Costa de Marfil'),
('Túnez'),
('Argelia'),
('Sudáfrica'),
('Camerún'),
('Mali');

-- 4. INSERTAR TIPOS DE STAFF (BASE - sin dependencias)
INSERT INTO StaffTypes (name) VALUES
('Cuerpo Técnico'),
('Cuerpo Médico'),
('Cuerpo de Preparación Física'),
('Cuerpo de Análisis'),
('Cuerpo de Scouting');

-- 5. INSERTAR TORNEOS (DEPENDENCIA SIMPLE)
INSERT INTO Tournaments (name, start_date, end_date) VALUES
('Liga Española 2024/25', '2024-08-15', '2025-05-25'),
('Copa Libertadores 2024', '2024-02-15', '2024-11-30'),
('Champions League 2024/25', '2024-09-15', '2025-06-01'),
('Premier League 2024/25', '2024-08-10', '2025-05-25'),
('Serie A 2024/25', '2024-08-20', '2025-05-20'),
('Bundesliga 2024/25', '2024-08-18', '2025-05-17'),
('Ligue 1 2024/25', '2024-08-12', '2025-05-25'),
('Copa del Rey 2024/25', '2024-10-15', '2025-04-20'),
('Copa América 2024', '2024-06-20', '2024-07-14'),
('Eurocopa 2024', '2024-06-14', '2024-07-14');

-- 6. INSERTAR EQUIPOS (DEPENDENCIA SIMPLE - necesita Cities)
INSERT INTO Teams (name, city_id) VALUES
-- Equipos Españoles
('Real Madrid', 1),
('FC Barcelona', 2),
('Atlético de Madrid', 1),
('Valencia CF', 17),
('Sevilla FC', 18),
('Athletic Bilbao', 19),
('Málaga CF', 20),
('Villarreal CF', 17),
('Real Sociedad', 19),
('Getafe CF', 1),

-- Equipos Sudamericanos
('River Plate', 3),
('Boca Juniors', 3),
('Flamengo', 4),
('Palmeiras', 4),
('Peñarol', 12),
('Nacional', 12),
('Atlético Nacional', 13),
('Millonarios', 13),
('Colo-Colo', 14),
('Universidad de Chile', 14),

-- Equipos Europeos
('Paris Saint-Germain', 5),
('Bayern Munich', 6),
('AC Milan', 7),
('Inter Milan', 7),
('Manchester City', 8),
('Manchester United', 8),
('Liverpool FC', 8),
('Arsenal FC', 8),
('Benfica', 9),
('Porto', 9),
('Ajax', 10),
('PSV Eindhoven', 10),
('Club Brugge', 11),
('Anderlecht', 11),

-- Equipos de otros continentes
('New York City FC', 16),
('Toronto FC', 23),
('Urawa Red Diamonds', 21),
('FC Seoul', 22),
('Sydney FC', 23),
('Al Ahly', 26),
('Wydad Casablanca', 25),
('Kaizer Chiefs', 32);

-- 7. INSERTAR ROLES DE STAFF (DEPENDENCIA SIMPLE - necesita StaffTypes)
INSERT INTO StaffRoles (name, type_id) VALUES
-- Roles Técnicos
('Entrenador Principal', 1),
('Entrenador Asistente', 1),
('Entrenador de Porteros', 1),
('Entrenador de Defensa', 1),
('Entrenador de Ataque', 1),
('Analista Táctico', 1),

-- Roles Médicos
('Médico Principal', 2),
('Médico Asistente', 2),
('Fisioterapeuta Principal', 2),
('Fisioterapeuta Asistente', 2),
('Nutricionista', 2),
('Psicólogo Deportivo', 2),

-- Roles de Preparación Física
('Preparador Físico Principal', 3),
('Preparador Físico Asistente', 3),
('Recuperador Físico', 3),

-- Roles de Análisis
('Analista de Rendimiento', 4),
('Analista de Video', 4),
('Analista de Datos', 4),

-- Roles de Scouting
('Scout Principal', 5),
('Scout Regional', 5),
('Observador de Rivales', 5);

-- 8. INSERTAR JUGADORES (DEPENDENCIA COMPLEJA - necesita Teams, Countries, Positions)
INSERT INTO Players (team_id, name, country_id, position_id, dorsal, birth_date, market_value) VALUES
-- Real Madrid
(1, 'Vinicius Jr.', 3, 9, 7, '2000-07-12', 95000000.00),
(1, 'Jude Bellingham', 7, 7, 5, '2003-06-29', 85000000.00),
(1, 'Thibaut Courtois', 10, 1, 1, '1992-05-11', 45000000.00),
(1, 'Antonio Rüdiger', 5, 2, 22, '1993-03-03', 40000000.00),
(1, 'Federico Valverde', 12, 6, 15, '1998-07-22', 95000000.00),
(1, 'Eduardo Camavinga', 4, 5, 12, '2002-11-10', 80000000.00),
(1, 'Rodrygo Goes', 3, 9, 11, '2001-01-09', 85000000.00),
(1, 'Aurélien Tchouaméni', 4, 5, 18, '2000-01-27', 80000000.00),

-- FC Barcelona
(2, 'Robert Lewandowski', 5, 10, 9, '1988-08-21', 35000000.00),
(2, 'Frenkie de Jong', 9, 6, 21, '1997-05-12', 90000000.00),
(2, 'Pedri González', 1, 7, 8, '2002-11-25', 95000000.00),
(2, 'Gavi Páez', 1, 7, 6, '2004-08-05', 90000000.00),
(2, 'Marc-André ter Stegen', 5, 1, 1, '1992-04-30', 35000000.00),
(2, 'Ronald Araújo', 12, 2, 4, '1999-03-07', 80000000.00),
(2, 'Jules Koundé', 4, 2, 23, '1998-11-12', 70000000.00),
(2, 'Lamine Yamal', 1, 8, 19, '2007-07-13', 75000000.00),

-- River Plate
(11, 'Enzo Fernández', 2, 6, 5, '2001-01-17', 80000000.00),
(11, 'Julian Álvarez', 2, 10, 9, '2000-01-31', 70000000.00),
(11, 'Franco Armani', 2, 1, 1, '1986-10-16', 8000000.00),
(11, 'Nicolás De La Cruz', 12, 7, 11, '1997-06-01', 25000000.00),
(11, 'Esequiel Barco', 2, 7, 10, '1999-03-29', 15000000.00),
(11, 'Manuel Lanzini', 2, 7, 10, '1993-02-15', 12000000.00),

-- Flamengo
(13, 'Gabigol', 3, 10, 9, '1996-08-30', 25000000.00),
(13, 'Bruno Henrique', 3, 8, 27, '1990-12-30', 20000000.00),
(13, 'Pedro', 3, 10, 9, '1997-06-20', 30000000.00),
(13, 'Gerson', 3, 6, 8, '1997-05-20', 25000000.00),
(13, 'Diego Alves', 3, 1, 1, '1985-06-24', 5000000.00),
(13, 'Arrascaeta', 12, 7, 14, '1994-06-01', 30000000.00),

-- Paris Saint-Germain
(21, 'Kylian Mbappé', 4, 9, 7, '1998-12-20', 95000000.00),
(21, 'Lionel Messi', 2, 8, 30, '1987-06-24', 35000000.00),
(21, 'Neymar Jr.', 3, 9, 10, '1992-02-05', 60000000.00),
(21, 'Marco Verratti', 6, 6, 6, '1992-11-05', 40000000.00),
(21, 'Gianluigi Donnarumma', 6, 1, 99, '1999-02-25', 45000000.00),
(21, 'Achraf Hakimi', 25, 3, 2, '1998-11-04', 65000000.00),

-- Bayern Munich
(22, 'Harry Kane', 7, 10, 9, '1993-07-28', 95000000.00),
(22, 'Joshua Kimmich', 5, 3, 6, '1995-02-08', 75000000.00),
(22, 'Jamal Musiala', 5, 7, 42, '2003-02-26', 95000000.00),
(22, 'Alphonso Davies', 23, 4, 19, '2000-11-02', 70000000.00),
(22, 'Manuel Neuer', 5, 1, 1, '1986-03-27', 12000000.00),
(22, 'Thomas Müller', 5, 12, 25, '1989-09-13', 15000000.00),

-- AC Milan
(23, 'Rafael Leão', 8, 9, 10, '1999-06-10', 90000000.00),
(23, 'Theo Hernández', 4, 4, 19, '1997-10-06', 60000000.00),
(23, 'Mike Maignan', 4, 1, 16, '1995-07-03', 45000000.00),
(23, 'Ismaël Bennacer', 26, 6, 4, '1997-12-01', 40000000.00),
(23, 'Olivier Giroud', 4, 10, 9, '1986-09-30', 8000000.00),
(23, 'Christian Pulisic', 15, 8, 11, '1998-09-18', 25000000.00),

-- Manchester City
(25, 'Erling Haaland', 11, 10, 9, '2000-07-21', 95000000.00),
(25, 'Kevin De Bruyne', 10, 7, 17, '1991-06-28', 60000000.00),
(25, 'Phil Foden', 7, 7, 47, '2000-05-28', 95000000.00),
(25, 'Rúben Dias', 8, 2, 3, '1997-05-14', 80000000.00),
(25, 'Ederson', 3, 1, 31, '1993-08-17', 45000000.00),
(25, 'Jack Grealish', 7, 9, 10, '1995-09-10', 60000000.00),

-- Benfica
(29, 'João Félix', 8, 10, 11, '1999-11-10', 50000000.00),
(29, 'Rafa Silva', 8, 8, 27, '1993-05-17', 25000000.00),
(29, 'Odisseas Vlachodimos', 5, 1, 99, '1994-04-26', 15000000.00),
(29, 'Nicolás Otamendi', 2, 2, 30, '1988-02-12', 8000000.00),
(29, 'Ángel Di María', 2, 8, 11, '1988-02-14', 8000000.00),

-- Ajax
(31, 'Mohammed Kudus', 11, 7, 20, '2000-08-02', 40000000.00),
(31, 'Steven Bergwijn', 9, 8, 7, '1997-10-08', 25000000.00),
(31, 'Dusan Tadic', 11, 10, 10, '1988-11-20', 15000000.00),
(31, 'Remko Pasveer', 9, 1, 1, '1983-11-08', 2000000.00),
(31, 'Jurriën Timber', 9, 2, 2, '2001-06-17', 45000000.00),

-- Jugadores asiáticos
(37, 'Shinzo Koroki', 16, 10, 9, '1986-07-31', 5000000.00),
(38, 'Ki Sung-yueng', 17, 6, 8, '1989-01-24', 8000000.00),
(39, 'Tim Cahill', 18, 10, 4, '1979-12-06', 2000000.00),
(40, 'Alphonso Davies', 23, 4, 19, '2000-11-02', 70000000.00),

-- Jugadores africanos
(41, 'Sadio Mané', 20, 9, 10, '1992-04-10', 35000000.00),
(42, 'Mohamed Salah', 22, 8, 11, '1992-06-15', 65000000.00);

-- 9. INSERTAR EQUIPOS EN TORNEOS (DEPENDENCIA COMPLEJA - necesita Tournaments y Teams)
INSERT INTO TournamentTeams (tournament_id, team_id) VALUES
-- Liga Española 2024/25
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10),

-- Copa Libertadores 2024
(2, 11), (2, 12), (2, 13), (2, 14), (2, 15), (2, 16), (2, 17), (2, 18), (2, 19), (2, 20),

-- Champions League 2024/25
(3, 1), (3, 2), (3, 21), (3, 22), (3, 23), (3, 24), (3, 25), (3, 26), (3, 27), (3, 28), (3, 29), (3, 30), (3, 31), (3, 32),

-- Premier League 2024/25
(4, 25), (4, 26), (4, 27), (4, 28),

-- Serie A 2024/25
(5, 23), (5, 24),

-- Bundesliga 2024/25
(6, 22),

-- Ligue 1 2024/25
(7, 21),

-- Copa del Rey 2024/25
(8, 1), (8, 2), (8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8), (8, 9), (8, 10),

-- Copa América 2024
(9, 11), (9, 12), (9, 13), (9, 14), (9, 15), (9, 16), (9, 17), (9, 18), (9, 19), (9, 20),

-- Eurocopa 2024
(10, 1), (10, 2), (10, 21), (10, 22), (10, 23), (10, 24), (10, 25), (10, 26), (10, 27), (10, 28), (10, 29), (10, 30), (10, 31), (10, 32);

-- 10. INSERTAR STAFF (DEPENDENCIA COMPLEJA - necesita Teams, Countries, StaffRoles)
INSERT INTO Staff (team_id, name, country_id, role_id) VALUES
-- Real Madrid Staff
(1, 'Carlo Ancelotti', 6, 1), -- Entrenador Principal
(1, 'Davide Ancelotti', 6, 2), -- Entrenador Asistente
(1, 'Luis Llopis', 1, 3), -- Entrenador de Porteros
(1, 'Dr. Niko Mihic', 5, 7), -- Médico Principal
(1, 'Dr. Jesús Olmo', 1, 8), -- Médico Asistente
(1, 'José Carlos Parrales', 1, 9), -- Fisioterapeuta Principal
(1, 'Carlos Lalin', 1, 10), -- Fisioterapeuta Asistente
(1, 'Antonio Pintus', 6, 13), -- Preparador Físico Principal

-- FC Barcelona Staff
(2, 'Xavi Hernández', 1, 1), -- Entrenador Principal
(2, 'Óscar Hernández', 1, 2), -- Entrenador Asistente
(2, 'José Ramón de la Fuente', 1, 3), -- Entrenador de Porteros
(2, 'Dr. Ricard Pruna', 1, 7), -- Médico Principal
(2, 'Dr. Daniel Medina', 1, 8), -- Médico Asistente
(2, 'Jaume Munill', 1, 9), -- Fisioterapeuta Principal
(2, 'Joan Carles Medina', 1, 10), -- Fisioterapeuta Asistente
(2, 'Joaquín Valdés', 1, 13), -- Preparador Físico Principal

-- River Plate Staff
(11, 'Martín Demichelis', 2, 1), -- Entrenador Principal
(11, 'Hernán Buján', 2, 2), -- Entrenador Asistente
(11, 'Germán Lux', 2, 3), -- Entrenador de Porteros
(11, 'Dr. Pedro Hansing', 2, 7), -- Médico Principal
(11, 'Dr. Diego Yacob', 2, 8), -- Médico Asistente
(11, 'Carlos Ponce', 2, 9), -- Fisioterapeuta Principal
(11, 'Dr. Gustavo Yacob', 2, 10), -- Fisioterapeuta Asistente

-- Flamengo Staff
(13, 'Jorge Sampaoli', 2, 1), -- Entrenador Principal
(13, 'Sebastián Beccacece', 2, 2), -- Entrenador Asistente
(13, 'Roberto Gattuso', 2, 3), -- Entrenador de Porteros
(13, 'Dr. Márcio Tannure', 3, 7), -- Médico Principal
(13, 'Dr. Rodrigo Lasmar', 3, 8), -- Médico Asistente
(13, 'Bruno Mazziotti', 3, 9), -- Fisioterapeuta Principal
(13, 'Dr. Paulo Roberto', 3, 10), -- Fisioterapeuta Asistente

-- Paris Saint-Germain Staff
(21, 'Luis Enrique', 1, 1), -- Entrenador Principal
(21, 'Rafael Pol', 1, 2), -- Entrenador Asistente
(21, 'Juan Carlos Unzué', 1, 3), -- Entrenador de Porteros
(21, 'Dr. Christophe Baudot', 4, 7), -- Médico Principal
(21, 'Dr. Emmanuel Orhant', 4, 8), -- Médico Asistente
(21, 'Philippe Lambert', 4, 9), -- Fisioterapeuta Principal
(21, 'Dr. Jean-Marcel Ferret', 4, 10), -- Fisioterapeuta Asistente

-- Bayern Munich Staff
(22, 'Thomas Tuchel', 5, 1), -- Entrenador Principal
(22, 'Anthony Barry', 7, 2), -- Entrenador Asistente
(22, 'Toni Tapalovic', 5, 3), -- Entrenador de Porteros
(22, 'Dr. Roland Schmidt', 5, 7), -- Médico Principal
(22, 'Dr. Jochen Hahne', 5, 8), -- Médico Asistente
(22, 'Andreas Kornmayer', 5, 13), -- Preparador Físico Principal

-- AC Milan Staff
(23, 'Stefano Pioli', 6, 1), -- Entrenador Principal
(23, 'Giacomo Murelli', 6, 2), -- Entrenador Asistente
(23, 'Luca Meroni', 6, 3), -- Entrenador de Porteros
(23, 'Dr. Stefano Mazzoni', 6, 7), -- Médico Principal
(23, 'Dr. Roberto Morra', 6, 8), -- Médico Asistente
(23, 'Andrea Maldera', 6, 13), -- Preparador Físico Principal

-- Manchester City Staff
(25, 'Pep Guardiola', 1, 1), -- Entrenador Principal
(25, 'Juanma Lillo', 1, 2), -- Entrenador Asistente
(25, 'Xabi Mancisidor', 1, 3), -- Entrenador de Porteros
(25, 'Dr. Max Sala', 1, 7), -- Médico Principal
(25, 'Dr. Gary O\'Driscoll', 7, 8), -- Médico Asistente
(25, 'Carlos Lalin', 1, 13), -- Preparador Físico Principal

-- Benfica Staff
(29, 'Roger Schmidt', 5, 1), -- Entrenador Principal
(29, 'Emanuel Ferro', 8, 2), -- Entrenador Asistente
(29, 'João Brito', 8, 3), -- Entrenador de Porteros
(29, 'Dr. João Paulo Rebelo', 8, 7), -- Médico Principal
(29, 'Dr. Nuno Loureiro', 8, 8), -- Médico Asistente

-- Ajax Staff
(31, 'John van \'t Schip', 9, 1), -- Entrenador Principal
(31, 'Hedwiges Maduro', 9, 2), -- Entrenador Asistente
(31, 'Anton Scheutjens', 9, 3), -- Entrenador de Porteros
(31, 'Dr. Edwin Goedhart', 9, 7), -- Médico Principal
(31, 'Dr. Rob Ouderland', 9, 8); -- Médico Asistente;

-- 11. INSERTAR PARTIDOS (DEPENDENCIA COMPLEJA - necesita Tournaments, Teams, TournamentTeams)
INSERT INTO Matches (tournament_id, home_team_id, away_team_id, match_date, home_score, away_score, is_finished) VALUES
-- Liga Española 2024/25
(1, 1, 2, '2024-08-20', 3, 1, true),
(1, 2, 1, '2024-12-15', 2, 2, true),
(1, 3, 4, '2024-09-10', 1, 0, true),
(1, 5, 6, '2024-09-15', 2, 1, true),
(1, 1, 3, '2024-10-05', 4, 0, true),
(1, 2, 5, '2024-10-12', 3, 2, true),
(1, 7, 8, '2024-11-01', 0, 0, false),
(1, 9, 10, '2024-11-08', 0, 0, false),

-- Copa Libertadores 2024
(2, 11, 13, '2024-03-15', 2, 1, true),
(2, 13, 11, '2024-05-20', 1, 3, true),
(2, 15, 17, '2024-04-10', 0, 2, true),
(2, 19, 20, '2024-04-15', 1, 1, true),
(2, 12, 14, '2024-06-01', 0, 0, false),
(2, 16, 18, '2024-06-08', 0, 0, false),

-- Champions League 2024/25
(3, 1, 21, '2024-09-25', 2, 1, true),
(3, 22, 23, '2024-09-26', 3, 0, true),
(3, 25, 29, '2024-10-02', 4, 2, true),
(3, 31, 2, '2024-10-03', 1, 3, true),
(3, 21, 1, '2024-10-23', 1, 2, true),
(3, 23, 22, '2024-10-24', 0, 2, true),
(3, 29, 25, '2024-11-06', 0, 0, false),
(3, 2, 31, '2024-11-07', 0, 0, false),

-- Premier League 2024/25
(4, 25, 26, '2024-08-12', 2, 1, true),
(4, 27, 28, '2024-08-19', 1, 1, true),
(4, 26, 25, '2024-12-07', 0, 0, false),
(4, 28, 27, '2024-12-14', 0, 0, false),

-- Serie A 2024/25
(5, 23, 24, '2024-08-25', 2, 0, true),
(5, 24, 23, '2024-12-21', 0, 0, false),

-- Bundesliga 2024/25
(6, 22, 22, '2024-08-18', 0, 0, false), -- Placeholder para partidos futuros

-- Ligue 1 2024/25
(7, 21, 21, '2024-08-12', 0, 0, false), -- Placeholder para partidos futuros

-- Copa del Rey 2024/25
(8, 1, 4, '2024-10-20', 0, 0, false),
(8, 2, 5, '2024-10-27', 0, 0, false),
(8, 3, 6, '2024-11-03', 0, 0, false),
(8, 7, 8, '2024-11-10', 0, 0, false),

-- Copa América 2024
(9, 11, 13, '2024-06-25', 0, 0, false),
(9, 15, 17, '2024-06-28', 0, 0, false),
(9, 19, 20, '2024-07-01', 0, 0, false),
(9, 12, 14, '2024-07-04', 0, 0, false),

-- Eurocopa 2024
(10, 1, 21, '2024-06-18', 0, 0, false),
(10, 22, 23, '2024-06-21', 0, 0, false),
(10, 25, 29, '2024-06-24', 0, 0, false),
(10, 31, 2, '2024-06-27', 0, 0, false);

-- 12. INSERTAR ESTADÍSTICAS DE JUGADORES (DEPENDENCIA COMPLEJA - necesita Players, Matches)
INSERT INTO PlayerStats (player_id, match_id, goals, assists, minutes_played) VALUES
-- Estadísticas de Vinicius Jr. (Real Madrid)
(71, 1, 2, 1, 90), -- Real Madrid vs Barcelona (Liga)
(71, 2, 0, 1, 90), -- Barcelona vs Real Madrid (Liga)
(71, 11, 1, 0, 85), -- Real Madrid vs PSG (Champions)

-- Estadísticas de Jude Bellingham (Real Madrid)
(72, 1, 1, 0, 90), -- Real Madrid vs Barcelona (Liga)
(72, 2, 1, 1, 90), -- Barcelona vs Real Madrid (Liga)
(72, 11, 0, 1, 90), -- Real Madrid vs PSG (Champions)

-- Estadísticas de Robert Lewandowski (Barcelona)
(73, 1, 0, 0, 90), -- Real Madrid vs Barcelona (Liga)
(73, 2, 2, 0, 90), -- Barcelona vs Real Madrid (Liga)
(73, 14, 1, 0, 90), -- Ajax vs Barcelona (Champions)

-- Estadísticas de Frenkie de Jong (Barcelona)
(74, 1, 0, 1, 90), -- Real Madrid vs Barcelona (Liga)
(74, 2, 0, 1, 90), -- Barcelona vs Real Madrid (Liga)
(74, 14, 0, 1, 90), -- Ajax vs Barcelona (Champions)

-- Estadísticas de Enzo Fernández (River)
(75, 9, 1, 1, 90), -- River vs Flamengo (Libertadores)
(75, 10, 0, 2, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Julian Álvarez (River)
(76, 9, 1, 0, 90), -- River vs Flamengo (Libertadores)
(76, 10, 2, 0, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Gabigol (Flamengo)
(77, 9, 0, 0, 90), -- River vs Flamengo (Libertadores)
(77, 10, 1, 0, 90), -- Flamengo vs River (Libertadores)

-- Estadísticas de Kylian Mbappé (PSG)
(78, 11, 1, 0, 90), -- Real Madrid vs PSG (Champions)
(78, 15, 0, 1, 90), -- PSG vs Real Madrid (Champions)

-- Estadísticas de Harry Kane (Bayern)
(79, 12, 2, 0, 90), -- Bayern vs Milan (Champions)
(79, 16, 1, 0, 90), -- Milan vs Bayern (Champions)

-- Estadísticas de Erling Haaland (Man City)
(80, 13, 3, 0, 90), -- Man City vs Benfica (Champions)
(80, 16, 1, 1, 90), -- Milan vs Bayern (Champions)

-- Estadísticas de Kevin De Bruyne (Man City)
(81, 13, 0, 2, 90), -- Man City vs Benfica (Champions)
(81, 16, 1, 1, 90), -- Milan vs Bayern (Champions)

-- Estadísticas de João Félix (Benfica)
(82, 13, 0, 0, 90), -- Man City vs Benfica (Champions)
(82, 15, 0, 0, 90), -- PSG vs Real Madrid (Champions)

-- Estadísticas de Mohammed Kudus (Ajax)
(83, 14, 0, 0, 90), -- Ajax vs Barcelona (Champions)
(83, 18, 0, 0, 90), -- Ajax vs Barcelona (Champions)

-- Estadísticas de otros jugadores destacados
(84, 1, 0, 0, 90), -- Courtois (Real Madrid)
(85, 1, 0, 0, 90), -- Rüdiger (Real Madrid)
(86, 1, 0, 1, 90), -- Valverde (Real Madrid)
(87, 1, 0, 0, 90), -- Camavinga (Real Madrid)
(88, 1, 0, 0, 90), -- Rodrygo (Real Madrid)
(89, 1, 0, 0, 90), -- Tchouaméni (Real Madrid)

(90, 2, 0, 0, 90), -- Pedri (Barcelona)
(91, 2, 0, 0, 90), -- Gavi (Barcelona)
(92, 2, 0, 0, 90), -- Ter Stegen (Barcelona)
(93, 2, 0, 0, 90), -- Araújo (Barcelona)
(94, 2, 0, 0, 90), -- Koundé (Barcelona)
(95, 2, 0, 0, 90); -- Yamal (Barcelona)

-- 13. INSERTAR TRANSFERENCIAS (DEPENDENCIA COMPLEJA - necesita Players, Teams)
INSERT INTO Transfers (player_id, origin_team_id, destination_team_id, transfer_date, transfer_type, amount) VALUES
-- Transferencias de compra recientes
(72, NULL, 1, '2023-07-01', 'Buy', 95000000.00), -- Bellingham a Real Madrid
(99, NULL, 21, '2017-08-31', 'Buy', 95000000.00), -- Mbappé a PSG
(105, NULL, 22, '2023-08-12', 'Buy', 95000000.00), -- Kane a Bayern
(117, NULL, 25, '2022-07-01', 'Buy', 60000000.00), -- Haaland a Man City
(71, NULL, 1, '2018-07-12', 'Buy', 45000000.00), -- Vinicius a Real Madrid

-- Transferencias de préstamo
(82, 2, 1, '2024-01-15', 'Loan', NULL), -- Gavi prestado a Real Madrid
(94, 13, 11, '2024-02-01', 'Loan', NULL), -- Bruno Henrique prestado a River
(123, 29, 25, '2024-01-20', 'Loan', NULL), -- João Félix prestado a Man City
(124, 31, 2, '2024-02-10', 'Loan', NULL), -- Kudus prestado a Barcelona

-- Transferencias históricas importantes
(75, 11, 25, '2023-01-31', 'Buy', 95000000.00), -- Enzo Fernández a Chelsea
(76, 11, 25, '2022-07-01', 'Buy', 21400000.00), -- Julian Álvarez a Man City
(77, NULL, 2, '2022-07-19', 'Buy', 45000000.00), -- Lewandowski a Barcelona
(78, 31, 2, '2019-07-01', 'Buy', 75000000.00), -- De Jong a Barcelona
(79, 2, 2, '2021-08-01', 'Buy', 5000000.00), -- Pedri a Barcelona (juvenil)
(80, 2, 2, '2021-07-01', 'Buy', 0.00), -- Gavi a Barcelona (juvenil)

-- Transferencias de jugadores asiáticos y africanos
(83, NULL, 37, '2023-01-15', 'Buy', 8000000.00), -- Koroki a Urawa
(84, NULL, 38, '2023-02-01', 'Buy', 12000000.00), -- Ki a FC Seoul
(85, NULL, 39, '2023-03-01', 'Buy', 5000000.00), -- Cahill a Sydney FC
(86, NULL, 22, '2019-01-01', 'Buy', 10000000.00), -- Davies a Bayern

-- Transferencias de jugadores africanos
(87, NULL, 25, '2023-07-01', 'Buy', 55000000.00), -- Mané a Bayern
(88, NULL, 27, '2017-07-01', 'Buy', 42000000.00), -- Salah a Liverpool
(89, NULL, 24, '2020-09-01', 'Buy', 70000000.00), -- Osimhen a Napoli
(90, NULL, 28, '2020-10-05', 'Buy', 50000000.00); -- Partey a Arsenal
