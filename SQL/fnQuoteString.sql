CREATE FUNCTION dbo.fnQuoteString (@input NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN '''' + @input + ''''
END