SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    sp.Id AS UIDSPMO,
    sp.Code AS IDSPMO,
    orgname.[Name] AS NAM_SPMO,
    orgname.ShortName AS NAM_SK_SPMO,
    comm.Phone AS PHONE,
    sp.OspType AS OSP,
    vt.[Name] AS VID_SPMO,
    oid_spmo.[Name] AS OID_SPMO,
    sp.DateBeg AS DATEBEG,
    sp.DateEnd AS DATEEND
    
FROM F033_Spmos sp
LEFT JOIN BaseData bd ON sp.BaseDataId = bd.Id
LEFT JOIN OrgNames orgname ON sp.OrgNameId = orgname.Id
LEFT JOIN Communications comm ON sp.CommunicationId = comm.Id
LEFT JOIN OrgDocuments od ON sp.OrgDocumentId = od.Id
LEFT JOIN VidTypes vt ON od.VidTypeId = vt.Id
LEFT JOIN OidTypes oid_spmo ON od.OidTypeSpmoId = oid_spmo.Id;