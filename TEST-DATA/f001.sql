SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    sub.CodeTf AS tf_kod,
    s.Okato AS tf_okato,
    doc.Ogrn AS tf_ogrn,
    orgname.[Name] AS name_tfp,
    orgname.ShortName AS name_tfk,
    addr.[Index] AS [index],
    addr.[Name] AS [address],
    pers.Surname AS fam_dir,
    pers.[Name] AS im_dir,
    pers.Patronymic AS ot_dir,
    comm.Phone AS phone,
    comm.Fax AS fax,
    comm.HotLine AS hot_line,
    comm.Email AS e_mail,
    org.KfTf AS kf_tf,
    comm.[Site] AS www,
    
    -- Банковские реквизиты (MTR)
    tf.Bic AS [MTR/bic],
    doc_inn.Inn AS [MTR/inn],
    doc_kpp.Kpp AS [MTR/kpp],
    org.Kbk AS [MTR/kbk],
    addr.Oktmo AS [MTR/oktmo],
    
    -- Счет плательщика (MTR_POL)
    acc_sender.[Name] AS [MTR/MTR_POL/L_NAIM],
    acc_sender.Bank AS [MTR/MTR_POL/L_B],
    acc_sender.Rs AS [MTR/MTR_POL/L_RS],
    
    -- Счет получателя (MTR_PL)
    acc_receiver.[Name] AS [MTR/MTR_PL/T_NAIM],
    acc_receiver.Bank AS [MTR/MTR_PL/T_B],
    acc_receiver.Rs AS [MTR/MTR_PL/T_RS],
    
    tf.DEdit AS d_edit,
    tf.DEnd AS d_end,
    tf.DBegin AS d_begin,
    tf.NoSmo AS no_smo
    
FROM F001_Tfoms tf
LEFT JOIN BaseData bd ON tf.BaseDataId = bd.Id
LEFT JOIN F010_Subects sub ON tf.f010_SubectiId = sub.Id
LEFT JOIN Subjects s ON sub.SubjectId = s.Id
LEFT JOIN Addresses addr ON tf.AddressId = addr.Id
LEFT JOIN Documents doc ON tf.DocumentId = doc.Id
LEFT JOIN Organizations org ON tf.OrganizationId = org.Id
LEFT JOIN OrgNames orgname ON org.OrgNameId = orgname.Id
LEFT JOIN People pers ON tf.PersonId = pers.Id
LEFT JOIN Communications comm ON tf.CommunicationId = comm.Id
LEFT JOIN Accounts acc_sender ON tf.SenderAccountId = acc_sender.Id
LEFT JOIN Accounts acc_receiver ON tf.ReceiverAccountId = acc_receiver.Id
LEFT JOIN Documents doc_inn ON tf.DocumentId = doc_inn.Id  -- для INN в MTR
LEFT JOIN Documents doc_kpp ON tf.DocumentId = doc_kpp.Id;  -- для KPP в MTR