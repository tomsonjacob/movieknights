/* spCreateUser
CREATE PROC spCreateUser
@email VARCHAR(100),
@password VARCHAR(512)

AS BEGIN

INSERT INTO dbo.[User]
(Email, Password)
VALUES  ( @email, @password)

END


EXEC spCreateUser
@email = "ffff@gg.co",
@password = "pass"
*/

/* spLoginReturnID

CREATE PROC spLoginReturnID
@email VARCHAR(100),
@password VARCHAR(512)

AS BEGIN

    DECLARE @userID VARCHAR(20)

    SELECT id FROM dbo.[User]
    WHERE Email = @email AND
    [Password] = @password

    RETURN @userID

END

/* spAddWatch*/

CREATE PROC spAddWatch
@userID int,
@movieID VARCHAR(50)

AS BEGIN

    INSERT INTO dbo.[Watch]
    (userID, movieID)
    VALUES  ( @userID, @movieID)

END