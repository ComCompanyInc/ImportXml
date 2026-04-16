USE SpravTest
GO

SELECT
BaseData.[Type] as [type],
BaseData.[Version] as [version],
BaseData.[Date] as [date],
F031_Ermos.Id as [IDMO],
OrgName.[Name] as [NAM_MOP],
OrgName.ShortName as [NAM_MOK],
Documents.Inn as [INN],
Documents.[Kpp] as [KPP],
Documents.[Ogrn] as [OGRN],
OidMo.[Name] as [OID_MO],
Organizations.Okopf as [OKOPF],
OrgDocuments.Okfs as [OKFS],
[Addresses].[Name] as [ADDR_J],
[Addresses].AddressCode as [ADDR_J_GAR],
[Addresses].[Oktmo] as OKTMO,
Communications.Email as EMAIL,
Communications.Phone as PHONE,
Communications.Fax as FAX,
F031_Ermos.DateBeg as DATEBEG,
F031_Ermos.DateEnd as DATEEND
FROM F031_Ermos
JOIN Organizations
ON F031_Ermos.OrganizationId = Organizations.Id
JOIN OrgDocuments
ON F031_Ermos.OrgDocumentId = OrgDocuments.Id
JOIN Documents
ON F031_Ermos.DocumentId = Documents.Id
JOIN Addresses
ON F031_Ermos.AddressId = Addresses.Id
JOIN BaseData
ON F031_Ermos.BaseDataId = BaseData.Id
JOIN Communications
ON F031_Ermos.CommunicationId = Communications.Id
JOIN OidTypes OidMo
ON OrgDocuments.OidTypeMoId = OidMo.Id
JOIN OrgNames OrgName
ON Organizations.OrgNameId = OrgName.Id