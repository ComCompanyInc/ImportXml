SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    ved.VedId AS IDVED,
    vt.[Name] AS VEDNAME,
    ved.DateBeg AS DATEBEG,
    ved.DateEnd AS DATEEND
    
FROM F007_Vedoms ved
LEFT JOIN BaseData bd ON ved.BaseDataId = bd.Id
LEFT JOIN VedomType vt ON ved.VedomTypeId = vt.Id;