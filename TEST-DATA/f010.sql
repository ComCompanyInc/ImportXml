SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    sub.CodeTf AS KOD_TF,
    s.Okato AS KOD_OKATO,
    s.[Name] AS SUBNAME,
    sub.SubjectId AS OKRUG,
    sub.DateBeg AS DATEBEG,
    sub.DateEnd AS DATEEND
    
FROM F010_Subects sub
LEFT JOIN BaseData bd ON sub.BaseDataId = bd.Id
LEFT JOIN Subjects s ON sub.SubjectId = s.Id;