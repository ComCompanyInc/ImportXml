USE SpravTest
GO

SELECT
BaseData.[Type] AS [TYPE],
BaseData.[Version] AS [VERSION],
BaseData.[Date] AS [DATE],
F038_Addrmps.Id AS [IDADDRESS],
F032_Trmos.Id AS [UIDMO],
F033_Spmos.Id AS [UIDSPMO],
F038_Addrmps.LicenseNum AS [N_DOC],
Addresses.[Name] AS [ADDR],
Addresses.AddressCode AS [ADDR_GAR],
F038_Addrmps.DateBeg AS DATEBEG,
F038_Addrmps.DateEnd AS DATEEND
FROM F038_Addrmps
JOIN F032_Trmos ON
F038_Addrmps.F032_TrmoId = F032_Trmos.Id
JOIN F033_Spmos ON
F038_Addrmps.F033_SpmoId = F033_Spmos.Id
JOIN Addresses ON
F038_Addrmps.AddressId = Addresses.Id
JOIN BaseData ON
F038_Addrmps.BaseDataId = BaseData.Id

