SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    s.Okato AS tf_okato,
    org.OrgTypeId AS orgtype,
    org.OrgCode AS orgcod,
    orgname.Name AS nam_orgp,
    orgname.ShortName AS nam_orgk,
    sub.CodeTf AS tf_kod,
    sme.SmoCod AS smocod,
    pao.DateBeg AS datebeg,
    pao.DateEnd AS dateend
    
FROM F019_PersAccOrgs pao
LEFT JOIN f001_tfoms tf ON pao.F001_TfomsId = tf.Id
LEFT JOIN BaseData bd ON tf.BaseDataId = bd.Id
LEFT JOIN Subjects s ON pao.SubjectId = s.Id
LEFT JOIN Organizations org ON pao.OrganizationId = org.Id
LEFT JOIN OrgNames orgname ON org.OrgNameId = orgname.Id
LEFT JOIN f002_smoEmps sme ON pao.F002_SmoEmpId = sme.SmoCod
LEFT JOIN F010_Subects sub ON tf.F010_SubectiId = sub.Id;