CREATE TABLE [dbo].[FightsAt]
(
	[fa_ship_1_id] INT NOT NULL, 
    [fa_ship_2_id] INT NOT NULL,
    [fa_system_id] INT NOT NULL,
    [fa_date] DATETIME NOT NULL,
    PRIMARY KEY ([fa_ship_1_id], [fa_ship_2_id], [fa_system_id], [fa_date])
)
