cd XmlTests

curl.exe -X POST http://localhost:5000/api/F031_ErmosComtroller/import/F31 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F031_ermo.xml"

curl.exe -X POST http://localhost:5000/api/F032_Trmos/import/F32 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F032_trmo.xml"

curl.exe -X POST http://localhost:5000/api/F033_Spmos/import/F33 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F033_spmo.xml"

curl.exe -X POST http://localhost:5000/api/F038_Addrmps/import/F38 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F038_addrmp.xml"

curl.exe -X POST http://localhost:5000/api/F037_Licmo/import/F37 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F037_licmo.xml"

curl.exe -X POST http://localhost:5000/api/F005_StatOpl/import/F5 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F005_StatOpl.xml"

curl.exe -X POST http://localhost:5000/api/F006_VidExp/import/F6 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F006_VidExp.xml"

curl.exe -X POST http://localhost:5000/api/F007_Vedom/import/F7 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F007_Vedom.xml"

curl.exe -X POST http://localhost:5000/api/F008_TipOms/import/F8 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F008_TipOms.xml"

curl.exe -X POST http://localhost:5000/api/F009_StatZl/import/F9 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F009_StatZl.xml"

curl.exe -X POST http://localhost:5000/api/F010_Subecti/import/F10 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F010_Subecti.xml"

curl.exe -X POST http://localhost:5000/api/F002_SmoEmp/import/F2 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F002.xml"

curl.exe -X POST http://localhost:5000/api/F011_Tipdoc/import/F11 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F011_Tipdoc.xml"

curl.exe -X POST http://localhost:5000/api/F012_TipSch/import/F12 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F012_TipSch.xml"

curl.exe -X POST http://localhost:5000/api/F015_Okrug/import/F15 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F015_Okrug.xml"

curl.exe -X POST http://localhost:5000/api/F017_BillTypes/import/F17 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F017_BillTypes.xml"

curl.exe -X POST http://localhost:5000/api/F014_OplOtk/import/F14 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F014_OplOtk.xml"

curl.exe -X POST http://localhost:5000/api/F001_Tfoms/import/F1 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F001_tfoms.xml"

curl.exe -X POST http://localhost:5000/api/F019_PersAccOrg/import/F19 -H "Content-Type: application/xml; charset=windows-1251" -d "@test_F019_PersAccOrg.xml"