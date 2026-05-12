SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    tip.SchId AS IDSch,
    tip.[Name] AS SchNameP,
    tip.ShortName AS SchNameK,
    tip.DateBeg AS DATEBEG,
    tip.DateEnd AS DATEEND
    
FROM F012_TipSches tip
LEFT JOIN BaseData bd ON tip.BaseDataId = bd.Id;