CREATE TABLE [dbo].[PlanetLinks]
(
	[pl_system_id] INT NOT NULL, 
	[pl_planet_id] INT NOT NULL,
    PRIMARY KEY ([pl_system_id], [pl_planet_id])
)
