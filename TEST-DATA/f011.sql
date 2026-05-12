SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    tipOms.DocId AS IDDoc,
    oms.[Name] AS DocName,
    tip.DocSer AS DocSer,
    tip.DocNum AS DocNum,
    tipOms.DateBeg AS DATEBEG,
    tipOms.DateEnd AS DATEEND
    
FROM F011_Tipdocs tip
LEFT JOIN f008_TipOms tipOms ON tip.F008_TipOmsId = tipOms.DocId
LEFT JOIN BaseData bd ON tipOms.BaseDataId = bd.Id
LEFT JOIN OmsTypes oms ON tipOms.OmsTypeId = oms.Id;