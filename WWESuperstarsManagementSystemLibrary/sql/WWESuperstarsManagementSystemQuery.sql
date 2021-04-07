SELECT s.IDSuperstar, s.Name AS Superstar, s.HeightCm, s.WeightKg, g.Name AS Gender, b.Name AS Brand, ci.Name AS City, co.Name AS Country FROM Superstar AS s
INNER JOIN Gender AS g
ON s.GenderID = g.IDGender
INNER JOIN Brand AS b
ON s.BrandID = b.IDBrand
INNER JOIN City AS ci
ON s.CityID = ci.IDCity
INNER JOIN Country AS co
ON ci.CountryID = co.IDCountry