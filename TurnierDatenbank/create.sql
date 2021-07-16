CREATE TABLE IF NOT EXISTS Teilnehmer(
    TeilnehmerID integer primary key AUTOINCREMENT,
    Rolle varchar(30),
    Name varchar(30),
    Vorname varchar(30),
    -- wird im Format (DD-MM-YYYYY) angegeben
    Geburtstag varchar(30),
    Groesse decimal
);

CREATE TABLE IF NOT EXISTS Mannschaft(
    MannschaftID integer PRIMARY KEY AUTOINCREMENT,
    Bezeichnung varchar(30),
    Sportart varchar(30),
    FOREIGN KEY (MannschaftID) REFERENCES Teilnehmer(TeilnehmerID)
);

CREATE TABLE IF NOT EXISTS Mitglied_von(
    Id integer PRIMARY KEY AUTOINCREMENT,
    TeilnehmerID integer,
    MannschaftID integer,
    FOREIGN KEY (TeilnehmerID) REFERENCES Teilnehmer(TeilnehmerID),
    FOREIGN KEY (MannschaftID) REFERENCES Mannschaft(MannschaftID)
);

CREATE TABLE IF NOT EXISTS Turnierergebnis(
    TurnierergebnisID integer PRIMARY KEY AUTOINCREMENT,
    TeilnehmerA integer,
    TeilnehmerB integer,
    Sportart varchar(30),
    ErgebnisA integer,
    ErgebnisB integer,
    FOREIGN KEY (TeilnehmerA) REFERENCES Mannschaft(MannschaftID),
    FOREIGN KEY (TeilnehmerB) REFERENCES Mannschaft(MannschaftID)
);

CREATE TABLE IF NOT EXISTS Rangliste(
    RanglisteID integer PRIMARY KEY AUTOINCREMENT,
    SpielID integer,
    Name varchar(30),
    Sportart varchar(30),
    Punkte integer,
    FOREIGN KEY (SpielID) REFERENCES Turnierergebnis(TurnierergebnisID),
    FOREIGN KEY (Name) REFERENCES Mannschaft(MannschaftID)
);

CREATE TABLE IF NOT EXISTS Volleyballspieler(
    VolleyballspielerID integer,
    Trikotnummer integer,
    Position varchar(30),
    -- wird in cm angegben
    Sprunghoehe integer,
    FOREIGN KEY (VolleyballspielerID) REFERENCES Teilnehmer(TeilnehmerID)
);

CREATE TABLE IF NOT EXISTS Fussballspieler(
    FussballspielerID integer,
    Trikotnummer integer,
    Position varchar(30),
    Fuss varchar(10),
    FOREIGN KEY (FussballspielerID) REFERENCES Teilnehmer(TeilnehmerID)
);

CREATE TABLE IF NOT EXISTS Basketballspieler(
    BasketballspielerID integer,
    Trikotnummer integer,
    Position varchar(30),
    AnzahlKoerbe integer,
    FOREIGN KEY (BasketballspielerID) REFERENCES Teilnehmer(TeilnehmerID)
);

CREATE TABLE IF NOT EXISTS Trainer(
    TrainerID integer,
    Sportart varchar(30),
    JahreErfahrung integer,
    FOREIGN KEY (TrainerID) REFERENCES Teilnehmer(TeilnehmerID)
);

CREATE TABLE IF NOT EXISTS Physio(
    PhysioID integer,
    JahreErfahrung integer,
    Sportart varchar(30),
    FOREIGN KEY (PhysioID) REFERENCES Teilnehmer(TeilnehmerID)
);

