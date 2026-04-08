USE SpravTest;
GO

SELECT *
FROM F032_Trmos F32
JOIN F031_Ermos F31
ON F32.f031_ermoId = F31.Id
JOIN Organizations Org
ON F32.OrganizationId = Org.Id
JOIN [Addresses] Addr
ON F32.AddressId = Addr.Id
JOIN MoDocuments MoDoc
ON F32.MoDocumentId = MoDoc.Id

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

