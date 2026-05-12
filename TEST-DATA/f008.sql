SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    tip.DocId AS IDDOC,
    oms.[Name] AS DOCNAME,
    tip.DateBeg AS DATEBEG,
    tip.DateEnd AS DATEEND
    
FROM F008_TipOms tip
LEFT JOIN BaseData bd ON tip.BaseDataId = bd.Id
LEFT JOIN OmsTypes oms ON tip.OmsTypeId = oms.Id;