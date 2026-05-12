SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    stat.StatusId AS IDStatus,
    st.StatusName AS StatusName,
    stat.DateBeg AS DATEBEG,
    stat.DateEnd AS DATEEND
    
FROM F009_StatZls stat
LEFT JOIN BaseData bd ON stat.BaseDataId = bd.Id
LEFT JOIN StatTypes st ON stat.StatTypeId = st.Id;