CREATE TABLE [dbo].[AsteroidLinks]
(
	[al_system_id] INT NOT NULL, 
    [al_asteroid_id] INT NOT NULL,
    PRIMARY KEY ([al_system_id], [al_asteroid_id])
)
