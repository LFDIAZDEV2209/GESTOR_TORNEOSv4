CREATE DATABASE IF NOT EXISTS gestor_torneos;
USE gestor_torneos;

CREATE TABLE Positions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE Cities (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE Countries (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE Tournaments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL
) ENGINE=InnoDB;

CREATE TABLE Teams (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    city_id INT,
    FOREIGN KEY (city_id) REFERENCES Cities(id) ON DELETE SET NULL
) ENGINE=InnoDB;

CREATE TABLE TournamentTeams (
    tournament_id INT,
    team_id INT,
    PRIMARY KEY (tournament_id, team_id),
    FOREIGN KEY (tournament_id) REFERENCES Tournaments(id) ON DELETE CASCADE,
    FOREIGN KEY (team_id) REFERENCES Teams(id) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE Players (
    id INT AUTO_INCREMENT PRIMARY KEY,
    team_id INT,
    name VARCHAR(100) NOT NULL,
    country_id INT,
    position_id INT,
    dorsal INT,
    birth_date DATE,
    market_value DECIMAL(10,2),
    FOREIGN KEY (team_id) REFERENCES Teams(id) ON DELETE SET NULL,
    FOREIGN KEY (country_id) REFERENCES Countries(id) ON DELETE SET NULL,
    FOREIGN KEY (position_id) REFERENCES Positions(id) ON DELETE SET NULL
) ENGINE=InnoDB;

CREATE TABLE PlayerStats (
    id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    match_id INT NOT NULL,
    goals INT DEFAULT 0,
    assists INT DEFAULT 0,
    minutes_played INT DEFAULT 0,
    FOREIGN KEY (player_id) REFERENCES Players(id) ON DELETE CASCADE,
    FOREIGN KEY (match_id) REFERENCES Matches(id) ON DELETE CASCADE
) ENGINE=InnoDB;


CREATE TABLE Staff (
    id INT AUTO_INCREMENT PRIMARY KEY,
    team_id INT,
    name VARCHAR(100) NOT NULL,
    country_id INT,
    role_id INT NOT NULL,
    FOREIGN KEY (team_id) REFERENCES Teams(id) ON DELETE SET NULL,
    FOREIGN KEY (role_id) REFERENCES StaffRoles(id) ON DELETE CASCADE,
    FOREIGN KEY (country_id) REFERENCES Countries(id) ON DELETE SET NULL
) ENGINE=InnoDB;

CREATE TABLE StaffRoles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    type_id INT NOT NULL,
    FOREIGN KEY (type_id) REFERENCES StaffTypes(id)
) ENGINE=InnoDB;

CREATE TABLE StaffTypes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE Matches (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tournament_id INT NOT NULL,
    home_team_id INT NOT NULL,
    away_team_id INT NOT NULL,
    match_date DATE NOT NULL,
    home_score INT DEFAULT 0,
    away_score INT DEFAULT 0,
    FOREIGN KEY (tournament_id) REFERENCES Tournaments(id) ON DELETE CASCADE,
    FOREIGN KEY (home_team_id) REFERENCES Teams(id) ON DELETE CASCADE,
    FOREIGN KEY (away_team_id) REFERENCES Teams(id) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE Transfers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    player_id INT NOT NULL,
    origin_team_id INT,
    destination_team_id INT NOT NULL,
    transfer_date DATE NOT NULL,
    transfer_type ENUM('Buy', 'Loan') NOT NULL,
    amount DECIMAL(12,2),
    FOREIGN KEY (player_id) REFERENCES Players(id) ON DELETE CASCADE,
    FOREIGN KEY (origin_team_id) REFERENCES Teams(id) ON DELETE SET NULL,
    FOREIGN KEY (destination_team_id) REFERENCES Teams(id) ON DELETE CASCADE
) ENGINE=InnoDB;
