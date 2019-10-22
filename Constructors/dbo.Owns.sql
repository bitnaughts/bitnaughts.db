CREATE TABLE [dbo].[Owns]
(
	[o_player_id] INT NOT NULL, 
    [o_ship_id] INT NOT NULL,
    PRIMARY KEY ([o_player_id], [o_ship_id])
)
