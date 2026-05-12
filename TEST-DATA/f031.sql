SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    e.Id AS IDMO,
    orgname.[Name] AS NAM_MOP,
    orgname.ShortName AS NAM_MOK,
    doc.Inn AS INN,
    doc.Kpp AS KPP,
    doc.Ogrn AS OGRN,
    oid_mo.[Name] AS OID_MO,
    org.Okopf AS OKOPF,
    od.Okfs AS OKFS,
    addr.[Name] AS ADDR_J,
    addr.AddressCode AS ADDR_J_GAR,
    addr.Oktmo AS OKTMO,
    comm.Email AS EMAIL,
    comm.Phone AS PHONE,
    comm.Fax AS FAX,
    e.DateBeg AS DATEBEG,
    e.DateEnd AS DATEEND
    
FROM F031_Ermos e
LEFT JOIN BaseData bd ON e.BaseDataId = bd.Id
LEFT JOIN Organizations org ON e.OrganizationId = org.Id
LEFT JOIN OrgNames orgname ON org.OrgNameId = orgname.Id
LEFT JOIN Documents doc ON e.DocumentId = doc.Id
LEFT JOIN OrgDocuments od ON e.OrgDocumentId = od.Id
LEFT JOIN OidTypes oid_mo ON od.OidTypeMoId = oid_mo.Id
LEFT JOIN Addresses addr ON e.AddressId = addr.Id
LEFT JOIN Communications comm ON e.CommunicationId = comm.Id;