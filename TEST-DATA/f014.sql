SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    opl.ErrorCode AS Kod,
    ve.VidId AS IDVID,
    rg.[Name] AS Naim,
    opl.RefusalGroundId AS Osn,
    opl.RefusalReason AS Komment,
    opl.CoefNonPay AS K_NO,
    opl.CoefForfeit AS K_SH,
    opl.CodePG AS KodPG,
    opl.DateBeg AS DATEBEG,
    opl.DateEnd AS DATEEND
    
FROM F014_OplOtks opl
LEFT JOIN BaseData bd ON opl.BaseDataId = bd.Id
LEFT JOIN F006_VidExps ve ON opl.f006_VidExpVidId = ve.VidId
LEFT JOIN RefusalGrounds rg ON opl.RefusalGroundId = rg.Id;