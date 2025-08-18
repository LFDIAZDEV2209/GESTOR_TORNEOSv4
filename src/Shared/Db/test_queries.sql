-- =====================================================
-- CONSULTAS DE PRUEBA PARA VERIFICAR LA BASE DE DATOS
-- =====================================================

-- 1. Verificar que las tablas existen y tienen datos
SELECT 'Positions' as tabla, COUNT(*) as total FROM Positions
UNION ALL
SELECT 'Cities', COUNT(*) FROM Cities
UNION ALL
SELECT 'Countries', COUNT(*) FROM Countries
UNION ALL
SELECT 'Teams', COUNT(*) FROM Teams
UNION ALL
SELECT 'Players', COUNT(*) FROM Players
UNION ALL
SELECT 'Matches', COUNT(*) FROM Matches
UNION ALL
SELECT 'PlayerStats', COUNT(*) FROM PlayerStats
UNION ALL
SELECT 'Transfers', COUNT(*) FROM Transfers;

-- 2. Verificar jugadores con sus equipos
SELECT 
    p.id,
    p.name,
    p.dorsal,
    t.name as equipo,
    c.name as pais,
    pos.name as posicion
FROM Players p
LEFT JOIN Teams t ON p.team_id = t.id
LEFT JOIN Countries c ON p.country_id = c.id
LEFT JOIN Positions pos ON p.position_id = pos.id
LIMIT 10;

-- 3. Verificar partidos con equipos
SELECT 
    m.id,
    m.match_date,
    t1.name as equipo_local,
    t2.name as equipo_visitante,
    m.home_score,
    m.away_score,
    m.is_finished
FROM Matches m
JOIN Teams t1 ON m.home_team_id = t1.id
JOIN Teams t2 ON m.away_team_id = t2.id
LIMIT 10;

-- 4. Verificar estadísticas de jugadores
SELECT 
    ps.id,
    p.name as jugador,
    t.name as equipo,
    ps.goals,
    ps.assists,
    ps.minutes_played
FROM PlayerStats ps
JOIN Players p ON ps.player_id = p.id
LEFT JOIN Teams t ON p.team_id = t.id
LIMIT 10;

-- 5. Verificar transferencias
SELECT 
    tr.id,
    p.name as jugador,
    t1.name as equipo_origen,
    t2.name as equipo_destino,
    tr.transfer_type,
    tr.amount
FROM Transfers tr
JOIN Players p ON tr.player_id = p.id
LEFT JOIN Teams t1 ON tr.origin_team_id = t1.id
JOIN Teams t2 ON tr.destination_team_id = t2.id
LIMIT 10;

-- 6. Verificar equipos en torneos
SELECT 
    tt.tournament_id,
    t.name as torneo,
    tm.name as equipo
FROM TournamentTeams tt
JOIN Tournaments t ON tt.tournament_id = t.id
JOIN Teams tm ON tt.team_id = tm.id
LIMIT 10;
