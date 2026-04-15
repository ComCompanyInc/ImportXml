USE SpravTest
GO

SELECT
BaseData.[Type] AS [TYPE],
BaseData.[Version] AS [VERSION],
BaseData.[Date] AS [DATE],
F033_Spmos.Id AS UIDSPMO,
F033_Spmos.Code AS IDSPMO,
F033_Spmos.[Name] AS NAM_SPMO,
F033_Spmos.ShortName AS NAM_SK_SPMO,
Communications.Phone AS PHONE,
OspType.[Name] AS OSP,
VidTypes.[Name] AS VID_SPMO,
OidTypes.[Name] AS OID_SPMO,
F033_Spmos.DateBeg AS DATEBEG,
F033_Spmos.DateEnd AS DATEEND
FROM F033_Spmos
JOIN OspType
ON F033_Spmos.OspTypeId = OspType.Id
JOIN OrgDocuments
ON F033_Spmos.OrgDocumentId = OrgDocuments.Id
JOIN Communications
ON F033_Spmos.CommunicationId = Communications.Id
JOIN OidTypes
ON OrgDocuments.OidTypeSpmoId = OidTypes.Id
JOIN VidTypes
ON OrgDocuments.VidTypeId = VidTypes.Id
JOIN BaseData
ON F033_Spmos.BaseDataId = BaseData.Id