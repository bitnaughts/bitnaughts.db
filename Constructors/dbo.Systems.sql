CREATE TABLE [dbo].[Systems]
(
    [s_system_id] INT PRIMARY KEY,
    [s_seed] INT NOT NULL,
    [s_position_x] DECIMAL(5,2) NOT NULL,
    [s_position_y] DECIMAL(5,2) NOT NULL
)
