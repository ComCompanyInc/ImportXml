SELECT 
    -- Секция zglv (из BaseData)
    bd.[Type] AS [type],
    bd.[Version] AS [version],
    bd.[Date] AS [date],
    
    -- Секция zap (данные из таблиц)
    subj.Okato AS tf_okato,
    ot.OrgTypeName AS orgType,
    tip.SchId AS billcod,
    tip.[Name] AS bill_namp,
    tip.ShortName AS bill_namk,
    bt.DateBeg AS datebeg,
    bt.DateEnd AS dateend,
    bt.BudgetSource AS IS_PAY
    
FROM f017_BillTypes bt
LEFT JOIN BaseData bd ON bt.BaseDataId = bd.Id
LEFT JOIN Subjects subj ON bt.SubjectId = subj.Id
LEFT JOIN OrgTypes ot ON bt.OrgTypeId = ot.Id
LEFT JOIN F012_TipSches tip ON bt.f012_TipSchId = tip.SchId;