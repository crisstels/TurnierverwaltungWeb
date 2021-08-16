CREATE VIEW IF NOT EXISTS Turnierergebnisse AS
SELECT TurnierergebnisID,Turnierergebnis.Sportart, ErgebnisA, ErgebnisB, Mannschaft.Bezeichnung, m.Bezeichnung
FROM Turnierergebnis INNER JOIN Mannschaft ON (Turnierergebnis.TeilnehmerB = Mannschaft.MannschaftID) inner join
                                            Mannschaft as m ON(Turnierergebnis.TeilnehmerA = m.MannschaftID);
