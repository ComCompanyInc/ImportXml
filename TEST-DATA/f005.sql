SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    stat.StatusCode AS IDIDST,
    ps.StatusName AS STNAME,
    stat.DateBeg AS DATEBEG,
    stat.DateEnd AS DATEEND
    
FROM F005_StatOpls stat
LEFT JOIN BaseData bd ON stat.BaseDataId = bd.Id
LEFT JOIN PaymentStatuses ps ON stat.PaymentStatusId = ps.Id;