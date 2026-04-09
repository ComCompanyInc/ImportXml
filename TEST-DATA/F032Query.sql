USE SpravTest;
GO

SELECT
BData.[Type] AS [type],
BData.[Version] AS [version],
BData.[Date] AS [date],
F32.[Id] AS [UIDMO],
F31.[Id] AS [IDMO],
Org.[Mcod] AS [MCOD],
Addr.[Oktmo] AS [OKTMO],
Subj.[Name] AS [SUBJ],
F32.InclusionDate AS [D_BEGIN],
F32.DateBeginOms AS [D_BEGIN_OMS],
F32.ExclusionDate AS [D_END],
Org.NameE AS [NAME_E],
Osp.[Name] AS [OSP],
ParentF031.[Id] AS [PARENT_IDMO],
Parent.[Id] AS [PARENT_UIDMO],
VidMo.[Name] AS [VID_MO],
MoDoc.[OidMo] AS [OID_MO],
MoDoc.[OidSpmo] AS [OID_SPMO],
Org.[Name] AS [NAM_MOP],
Org.[ShortName] AS [NAM_MOK],
Doc.[Inn] AS [INN],
Doc.[Kpp] AS [KPP],
Doc.[Ogrn] AS [OGRN],
Addr.[Index] AS [JURADDRESS_INDEX],
Addr.[Name] AS [JURADDRESS_ADDRESS],
Addr.AddressCode AS [GAR_ADDRESS],
MoDoc.[Okfs] AS [OKFS],
Org.VedPri AS [VEDPRI],
Comunication.Phone AS [PHONE],
Comunication.Fax AS [FAX],
Comunication.Email AS [EMAIL],
F32.DateBeg AS [DATEBEG],
F32.DateEnd AS [DATEEND]
FROM F032_Trmos F32
JOIN F031_Ermos F31
ON F32.f031_ermoId = F31.Id
JOIN Organizations Org
ON F32.OrganizationId = Org.Id
JOIN [Addresses] Addr
ON F32.AddressId = Addr.Id
JOIN Districts Distr
ON Addr.DistrictId = Distr.Id
JOIN [Subjects] Subj
ON Subj.Id = Distr.SubjectId
JOIN MoDocuments MoDoc
ON F32.MoDocumentId = MoDoc.Id
JOIN OspType Osp
ON F32.OspTypeId = Osp.Id

JOIN F032_Trmos Parent
ON F32.ParentId = Parent.Id

JOIN F031_Ermos ParentF031
ON F32.f031_ermoParentId = ParentF031.Id

JOIN VidMos VidMo
ON MoDoc.VidMoId = VidMo.Id
JOIN Documents Doc
ON F32.DocumentId = Doc.Id
JOIN Communications Comunication
ON F32.CommunicationId = Comunication.Id
JOIN BaseData BData
ON F32.BaseDataId = BData.Id
