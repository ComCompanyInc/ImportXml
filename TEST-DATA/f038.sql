SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    addr.Id AS IDADDRESS,
    addr.F032_TrmoId AS UIDMO,
    addr.F033_SpmoId AS UIDSPMO,
    lic.LicenseNum AS N_DOC,
    a.[Name] AS ADDR,
    a.AddressCode AS ADDR_GAR,
    addr.DateBeg AS DATEBEG,
    addr.DateEnd AS DATEEND
    
FROM F038_Addrmps addr
LEFT JOIN BaseData bd ON addr.BaseDataId = bd.Id
LEFT JOIN Licenses lic ON addr.LicenseId = lic.Id
LEFT JOIN Addresses a ON addr.AddressId = a.Id;