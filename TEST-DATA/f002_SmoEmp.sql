SELECT 
    -- Секция zglv (глобальные данные)
    bd.Type AS [type],
    bd.Version AS [version],
    bd.Date AS [date],
    
    -- Территориальный орган (TF_OKATO из f010_Subecti)
    subj.Okato AS TF_OKATO,
    
    -- Данные страховой компании
    sme.SmoCod AS smocod,
    
    -- Наименования (из OrgName через Organization)
    orgname.Name AS nam_smop,
    orgname.ShortName AS nam_smok,
    
    -- Документы (из Document)
    doc.Inn AS INN,
    doc.Ogrn AS Ogrn,
    doc.Kpp AS KPP,
    
    -- Юридический адрес (из Address)
    addr_j.[Name] AS [jurAddress/ADDR_J],
    addr_j.[Index] AS [jurAddress/INDEX_J],
    
    -- Почтовый адрес (из Address)
    addr_p.[Name] AS [pstAddress/addr_f],
    addr_p.[Index] AS [pstAddress/INDEX_F],
    
    -- Код ОКОПФ
    org.Okopf AS OKOPF,
    
    -- Руководитель (из Person)
    pers.Surname AS fam_ruk,
    pers.[Name] AS im_ruk,
    pers.Patronymic AS ot_ruk,
    
    -- Контакты (из Communication)
    comm.Phone AS Phone,
    comm.Fax AS Fax,
    comm.HotLine AS hot_line,
    comm.Email AS e_mail,
    comm.[Site] AS WWW,
    
    -- Лицензия (из License)
    lic.LicenseNum AS [licenziy/N_DOC],
    lic.Dstart AS [licenziy/D_START],
    lic.DateE AS [licenziy/DATE_E],
    lic.Dterm AS [licenziy/D_TERM],
    
    -- Тип организации
    org.OrgTypeId AS ORG,
    
    -- Включение СМО (из f002_InsInclude)
    inc.DBegin AS [insInclude/d_begin],
    inc.DEnd AS [insInclude/d_end],
    inc.NameE AS [insInclude/NAME_E],
    inc.NalP AS [insInclude/NAL_P],
    
    -- Дата редактирования
    adv.DEdit AS D_EDIT
    
FROM F002_SmoEmps sme
LEFT JOIN BaseData bd ON sme.BaseDataId = bd.Id
LEFT JOIN Organizations org ON sme.OrganizationId = org.Id
LEFT JOIN OrgNames orgname ON org.OrgNameId = orgname.Id
LEFT JOIN Documents doc ON sme.DocumentId = doc.Id
LEFT JOIN Addresses addr_j ON sme.AddressId = addr_j.Id
LEFT JOIN Addresses addr_p ON sme.AddressId = addr_p.Id
LEFT JOIN People pers ON sme.PersonId = pers.Id
LEFT JOIN Communications comm ON sme.CommunicationId = comm.Id
LEFT JOIN Licenses lic ON sme.LicenseId = lic.Id
LEFT JOIN InsIncludes inc ON sme.F002_InsIncludeId = inc.Id
LEFT JOIN f002_smo_insAdvices adv ON sme.SmoCod = adv.F002_SmoEmpSmoCod

LEFT JOIN Addresses addr ON sme.AddressId = addr.Id
LEFT JOIN Districts dist ON addr.DistrictId = dist.Id
LEFT JOIN Subjects subj ON dist.SubjectId = subj.Id