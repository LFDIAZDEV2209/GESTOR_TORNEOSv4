-- =====================================================
-- CONSULTAS SQL PARA GESTOR DE TORNEOS
-- =====================================================

-- =====================================================
-- MENÚ TORNEOS (0.x)
-- =====================================================

-- 0.1. ADD TORNEO
-- INSERT INTO Tournaments (name, start_date, end_date) VALUES ('Nombre Torneo', '2024-01-01', '2024-12-31');

-- 0.2. BUSCAR TORNEO
-- Buscar torneo por nombre
SELECT id, name, start_date, end_date 
FROM Tournaments 
WHERE name LIKE '%Nombre%';

-- Buscar torneo por ID
SELECT id, name, start_date, end_date 
FROM Tournaments 
WHERE id = 1;

-- Listar todos los torneos
SELECT id, name, start_date, end_date 
FROM Tournaments 
ORDER BY start_date DESC;

-- 0.3. ELIMINAR TORNEO
-- DELETE FROM Tournaments WHERE id = 1;

-- 0.4. ACTUALIZAR TORNEO
-- UPDATE Tournaments SET name = 'Nuevo Nombre', start_date = '2024-01-01', end_date = '2024-12-31' WHERE id = 1;

-- =====================================================
-- MENÚ REGISTRO DE EQUIPOS (1.x)
-- =====================================================

-- 1.1. REGISTRAR EQUIPO
-- INSERT INTO Teams (name, city_id) VALUES ('Nombre Equipo', 1);

-- 1.2. REGISTRAR CUERPO TÉCNICO
-- INSERT INTO Staff (team_id, name, country_id, role_id) VALUES (1, 'Nombre Staff', 1, 1);

-- 1.3. REGISTRAR CUERPO MÉDICO
-- INSERT INTO Staff (team_id, name, country_id, role_id) VALUES (1, 'Nombre Médico', 1, 4);

-- 1.4. INSCRIPCIÓN TORNEO
-- INSERT INTO TournamentTeams (tournament_id, team_id) VALUES (1, 1);

-- 1.5. NOTIFICACIÓN DE TRANSFERENCIA
-- Consulta para ver transferencias recientes de un equipo
SELECT 
    p.name AS jugador,
    t1.name AS equipo_origen,
    t2.name AS equipo_destino,
    tr.transfer_date,
    tr.transfer_type,
    tr.amount
FROM Transfers tr
JOIN Players p ON tr.player_id = p.id
LEFT JOIN Teams t1 ON tr.origin_team_id = t1.id
JOIN Teams t2 ON tr.destination_team_id = t2.id
WHERE tr.destination_team_id = 1
ORDER BY tr.transfer_date DESC;

-- 1.6. SALIR DE TORNEO
-- DELETE FROM TournamentTeams WHERE tournament_id = 1 AND team_id = 1;

-- =====================================================
-- MENÚ REGISTRO DE JUGADORES (2.x)
-- =====================================================

-- 2.1. REGISTRAR JUGADOR
-- INSERT INTO Players (team_id, name, country_id, position_id, dorsal, birth_date, market_value) 
-- VALUES (1, 'Nombre Jugador', 1, 1, 10, '2000-01-01', 50000000.00);

-- 2.2. BUSCAR JUGADOR
-- Buscar por nombre
SELECT 
    p.id,
    p.name,
    t.name AS equipo,
    c.name AS pais,
    pos.name AS posicion,
    p.dorsal,
    p.birth_date,
    p.market_value
FROM Players p
JOIN Teams t ON p.team_id = t.id
JOIN Countries c ON p.country_id = c.id
JOIN Positions pos ON p.position_id = pos.id
WHERE p.name LIKE '%Nombre%';

-- Buscar por equipo
SELECT 
    p.id,
    p.name,
    c.name AS pais,
    pos.name AS posicion,
    p.dorsal,
    p.birth_date,
    p.market_value
FROM Players p
JOIN Countries c ON p.country_id = c.id
JOIN Positions pos ON p.position_id = pos.id
WHERE p.team_id = 1
ORDER BY p.dorsal;

-- Buscar por posición
SELECT 
    p.id,
    p.name,
    t.name AS equipo,
    c.name AS pais,
    p.dorsal,
    p.birth_date,
    p.market_value
FROM Players p
JOIN Teams t ON p.team_id = t.id
JOIN Countries c ON p.country_id = c.id
WHERE p.position_id = 1
ORDER BY p.market_value DESC;

-- 2.3. EDITAR JUGADOR
-- UPDATE Players SET team_id = 2, name = 'Nuevo Nombre', country_id = 2, position_id = 2, dorsal = 11, birth_date = '2000-01-01', market_value = 60000000.00 WHERE id = 1;

-- 2.4. ELIMINAR JUGADOR
-- DELETE FROM Players WHERE id = 1;

-- =====================================================
-- MENÚ DE TRANSFERENCIAS (3.x)
-- =====================================================

-- 3.1. COMPRAR JUGADOR
-- INSERT INTO Transfers (player_id, origin_team_id, destination_team_id, transfer_date, transfer_type, amount) 
-- VALUES (1, 2, 1, '2024-01-01', 'Buy', 50000000.00);

-- 3.2. PRESTAR JUGADOR
-- INSERT INTO Transfers (player_id, origin_team_id, destination_team_id, transfer_date, transfer_type, amount) 
-- VALUES (1, 2, 1, '2024-01-01', 'Loan', NULL);

-- Consulta para ver jugadores disponibles para transferencia
SELECT 
    p.id,
    p.name,
    t.name AS equipo_actual,
    c.name AS pais,
    pos.name AS posicion,
    p.market_value
FROM Players p
JOIN Teams t ON p.team_id = t.id
JOIN Countries c ON p.country_id = c.id
JOIN Positions pos ON p.position_id = pos.id
WHERE p.team_id != 1  -- Excluir jugadores del equipo destino
ORDER BY p.market_value DESC;

-- =====================================================
-- MENÚ DE ESTADÍSTICAS (4.x)
-- =====================================================

-- 4.1. JUGADORES CON MÁS ASISTENCIAS TORNEO
SELECT 
    p.name AS jugador,
    t.name AS equipo,
    pos.name AS posicion,
    SUM(ps.assists) AS total_asistencias
FROM PlayerStats ps
JOIN Players p ON ps.player_id = p.id
JOIN Teams t ON p.team_id = t.id
JOIN Positions pos ON p.position_id = pos.id
JOIN Matches m ON ps.match_id = m.id
WHERE m.tournament_id = 1  -- Cambiar por el ID del torneo
GROUP BY p.id, p.name, t.name, pos.name
HAVING total_asistencias > 0
ORDER BY total_asistencias DESC;

-- 4.2. EQUIPO CON MÁS GOLES
SELECT 
    t.name AS equipo,
    SUM(CASE 
        WHEN m.home_team_id = t.id THEN m.home_score
        WHEN m.away_team_id = t.id THEN m.away_score
        ELSE 0
    END) AS goles_marcados
FROM Teams t
JOIN TournamentTeams tt ON t.id = tt.team_id
JOIN Matches m ON (m.home_team_id = t.id OR m.away_team_id = t.id) AND m.tournament_id = tt.tournament_id
WHERE tt.tournament_id = 1  -- Cambiar por el ID del torneo
GROUP BY t.id, t.name
ORDER BY goles_marcados DESC
LIMIT 1;

-- 4.3. JUGADOR MÁS CARO POR EQUIPO
SELECT 
    t.name AS equipo,
    p.name AS jugador,
    pos.name AS posicion,
    p.market_value
FROM Players p
JOIN Teams t ON p.team_id = t.id
JOIN Positions pos ON p.position_id = pos.id
WHERE p.market_value IS NOT NULL
AND p.market_value = (
    SELECT MAX(p2.market_value)
    FROM Players p2
    WHERE p2.team_id = t.id AND p2.market_value IS NOT NULL
)
ORDER BY t.name;

-- 4.4. JUGADORES MENOR AL PROMEDIO DE EDAD POR EQUIPO
SELECT 
    t.name AS equipo,
    p.name AS jugador,
    pos.name AS posicion,
    TIMESTAMPDIFF(YEAR, p.birth_date, CURDATE()) AS edad
FROM Players p
JOIN Teams t ON p.team_id = t.id
JOIN Positions pos ON p.position_id = pos.id
WHERE p.birth_date IS NOT NULL
AND TIMESTAMPDIFF(YEAR, p.birth_date, CURDATE()) < 
    (SELECT AVG(TIMESTAMPDIFF(YEAR, p2.birth_date, CURDATE())) 
     FROM Players p2 
     WHERE p2.team_id = t.id AND p2.birth_date IS NOT NULL)
ORDER BY t.name, edad ASC;

SELECT AVG(TIMESTAMPDIFF(YEAR, birth_date, CURDATE())) 
FROM Players;

