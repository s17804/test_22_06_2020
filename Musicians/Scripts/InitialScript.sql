IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Musicians] (
    [IdMusician] int NOT NULL IDENTITY,
    [FirstName] nvarchar(30) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [NickName] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Musicians] PRIMARY KEY ([IdMusician])
);

GO

CREATE TABLE [MusicLabels] (
    [IdMusicLabel] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_MusicLabels] PRIMARY KEY ([IdMusicLabel])
);

GO

CREATE TABLE [Albums] (
    [IdAlbum] int NOT NULL IDENTITY,
    [AlbumName] nvarchar(30) NOT NULL,
    [PublishDate] datetime2 NOT NULL,
    [IdMusicLabel] int NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([IdAlbum]),
    CONSTRAINT [FK_Albums_MusicLabels_IdMusicLabel] FOREIGN KEY ([IdMusicLabel]) REFERENCES [MusicLabels] ([IdMusicLabel]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Tracks] (
    [IdTrack] int NOT NULL IDENTITY,
    [TrackName] nvarchar(20) NOT NULL,
    [Duration] real NOT NULL,
    [IdMusicAlbum] int NULL,
    CONSTRAINT [PK_Tracks] PRIMARY KEY ([IdTrack]),
    CONSTRAINT [FK_Tracks_Albums_IdMusicAlbum] FOREIGN KEY ([IdMusicAlbum]) REFERENCES [Albums] ([IdAlbum]) ON DELETE NO ACTION
);

GO

CREATE TABLE [MusicianTracks] (
    [IdMusicianTrack] int NOT NULL IDENTITY,
    [IdMusician] int NULL,
    [IdTrack] int NULL,
    CONSTRAINT [PK_MusicianTracks] PRIMARY KEY ([IdMusicianTrack]),
    CONSTRAINT [FK_MusicianTracks_Musicians_IdMusician] FOREIGN KEY ([IdMusician]) REFERENCES [Musicians] ([IdMusician]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MusicianTracks_Tracks_IdTrack] FOREIGN KEY ([IdTrack]) REFERENCES [Tracks] ([IdTrack]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Albums_IdMusicLabel] ON [Albums] ([IdMusicLabel]);

GO

CREATE INDEX [IX_MusicianTracks_IdMusician] ON [MusicianTracks] ([IdMusician]);

GO

CREATE INDEX [IX_MusicianTracks_IdTrack] ON [MusicianTracks] ([IdTrack]);

GO

CREATE INDEX [IX_Tracks_IdMusicAlbum] ON [Tracks] ([IdMusicAlbum]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200629190318_InitialCreate', N'5.0.0-preview.6.20312.4');

GO

