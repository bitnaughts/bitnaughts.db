CREATE TABLE [dbo].[Players] (
    [player_id]          INT          NOT NULL,
    [alias]              VARCHAR (50) NULL,
    [password]           VARCHAR (50) NULL,
    [current_ship_id]    INT          NULL,
    [current_session_id] INT          NULL,
    PRIMARY KEY CLUSTERED ([player_id] ASC)
);

