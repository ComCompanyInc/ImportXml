SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    ermo.Id AS IDMO,
    oid_mo.[Name] AS OID_MO,
    org.Mcod AS MCOD,
    licmo.F032_TrmoId AS UIDMO,
    lic.LicenseNum AS N_DOC,
    licmo.DateBeg AS DATEBEG,
    licmo.DateEnd AS DATEEND
    
FROM F037_Licmos licmo
LEFT JOIN BaseData bd ON licmo.BaseDataId = bd.Id
LEFT JOIN F031_Ermos ermo ON licmo.F031_ErmoId = ermo.Id
LEFT JOIN Organizations org ON licmo.OrganizationId = org.Id
LEFT JOIN Licenses lic ON licmo.LicenseId = lic.Id
LEFT JOIN OrgDocuments od ON licmo.OrgDocumentId = od.Id
LEFT JOIN OidTypes oid_mo ON od.OidTypeMoId = oid_mo.Id;