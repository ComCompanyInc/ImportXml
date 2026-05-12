SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    tr.Id AS UIDMO,
    tr.f031_ermoId AS IDMO,
    org.Mcod AS MCOD,
    addr.Oktmo AS OKTMO_P,
    subj.[Name] AS SUBJ,
    tr.InclusionDate AS D_BEGIN,
    tr.DateBeginOms AS D_BEGIN_OMS,
    tr.ExclusionDate AS D_END,
    NULL AS NAME_E,
    osp.[Name] AS OSP,
    tr.f031_ermoParentId AS PARENT_IDMO,
    tr.ParentId AS PARENT_UIDMO,
    vt.[Name] AS VID_MO,
    oid_mo.[Name] AS OID_MO,
    NULL AS OID_SPMO,
    orgname.[Name] AS NAM_MOP,
    orgname.ShortName AS NAM_MOK,
    doc.Inn AS INN,
    doc.Kpp AS KPP,
    doc.Ogrn AS OGRN,
    addr.[Index] AS JURADDRESS_INDEX,
    addr.[Name] AS JURADDRESS_ADDRESS,
    addr.AddressCode AS GAR_ADDRESS,
    od.Okfs AS OKFS,
    org.VedPri AS VEDPRI,
    comm.Phone AS PHONE,
    comm.Fax AS FAX,
    comm.Email AS EMAIL,
    tr.DateBeg AS DATEBEG,
    tr.DateEnd AS DATEEND
    
FROM F032_Trmos tr
LEFT JOIN BaseData bd ON tr.BaseDataId = bd.Id
LEFT JOIN Organizations org ON tr.OrganizationId = org.Id
LEFT JOIN OrgNames orgname ON org.OrgNameId = orgname.Id
LEFT JOIN Documents doc ON tr.DocumentId = doc.Id
LEFT JOIN Addresses addr ON tr.AddressId = addr.Id
LEFT JOIN Districts dist ON addr.DistrictId = dist.Id
LEFT JOIN Subjects subj ON dist.SubjectId = subj.Id
LEFT JOIN OspType osp ON tr.OspTypeId = osp.Id
LEFT JOIN OrgDocuments od ON tr.OrgDocumentId = od.Id
LEFT JOIN VidTypes vt ON od.VidTypeId = vt.Id
LEFT JOIN OidTypes oid_mo ON od.OidTypeMoId = oid_mo.Id
LEFT JOIN Communications comm ON tr.CommunicationId = comm.Id;