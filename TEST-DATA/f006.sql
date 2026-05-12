SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    ve.VidId AS IDVID,
    et.[Name] AS VIDNAME,
    ve.DateBeg AS DATEBEG,
    ve.DateEnd AS DATEEND
    
FROM F006_VidExps ve
LEFT JOIN BaseData bd ON ve.BaseDataId = bd.Id
LEFT JOIN ExpTypes et ON ve.ExpTypeId = et.Id;