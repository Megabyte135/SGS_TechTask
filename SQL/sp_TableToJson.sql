CREATE PROCEDURE [dbo].[sp_TableToJson] (@tableName NVARCHAR(128))

AS

BEGIN
	DECLARE @json NVARCHAR(MAX)
    DECLARE @columnName NVARCHAR(128)
    DECLARE @sql NVARCHAR(MAX)
	CREATe TABLE #temp (Result NVARCHAR(MAX))
	DECLARE @result NVARCHAR(MAX)
    DECLARE @cursor CURSOR

    SET @cursor = CURSOR FOR 
	SELECT COLUMN_NAME
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = @tableName
    ORDER BY ORDINAL_POSITION

	BEGIN
		SET @sql = 'SELECT ''{'' + ';

		OPEN @cursor
		FETCH NEXT FROM @cursor INTO @columnName

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @sql = @sql 
			+ dbo.fnQuoteString('"' + @columnName + '"') 
			+ dbo.fnAddSeparator() 
			+ dbo.fnQuoteString('"') + '+ '
			+ 'CAST(' + @columnName + ' AS NVARCHAR(MAX)) + ' +
			+ dbo.fnQuoteString('" ') + '+ ' + dbo.fnQuoteString(', ') + '+ '
			FETCH NEXT FROM @cursor INTO @columnName
		END

		CLOSE @cursor
		DEALLOCATE @cursor

		IF LEN(@sql) > 1
			SET @sql = LEFT(@sql, LEN(@sql) - 5)
		SET @sql = @sql + ' + ''}'' ' + 'AS result ' + 'FROM ' + @tableName + ';';
		PRINT @sql;
		INSERT INTO #temp 
		EXEC sp_executesql @sql;
	END

	SET @sql = '
	WITH InitialCTE AS (
		SELECT 
			Result,
			ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn
		FROM #temp
	),
	ResultCTE AS (
		SELECT
			Result,
			rn
		FROM InitialCTE
		WHERE rn = 1

		UNION ALL

		SELECT
			CONCAT(c.Result, '', '', r.Result),
			r.rn
		FROM InitialCTE r
		JOIN ResultCTE c ON r.rn = c.rn + 1
	)
	SELECT Result AS json
	FROM ResultCTE
	WHERE rn = (SELECT MAX(rn) FROM InitialCTE);
	';

    EXEC sp_executesql @sql;
	DROP TABLE #temp;
END