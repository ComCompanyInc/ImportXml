SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    okrug.Code AS KOD_OK,
    dist.[Name] AS OKRNAME,
    okrug.DateBeg AS DATEBEG,
    okrug.DateEnd AS DATEEND
    
FROM F015_Okrugs okrug
LEFT JOIN BaseData bd ON okrug.BaseDataId = bd.Id
LEFT JOIN Districts dist ON okrug.DistrictId = dist.Id;