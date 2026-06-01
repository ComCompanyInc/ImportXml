function addLog(fileName, message) {
    // Клонируем шаблон
    const template = document.getElementById('logTemplate');
    const logCard = template.content.cloneNode(true);
    
    // Заполняем данными
    logCard.querySelector('.log-time').textContent = new Date().toLocaleTimeString();
    logCard.querySelector('.file-name').textContent = fileName;
    logCard.querySelector('.log-message').textContent = message;
    
    // Добавляем на страницу
    document.getElementById('logContainer').appendChild(logCard);
}

async function importXml() { // async/await для последовательной загрузки
    await importOneXml('F031_ErmosComtroller/import/F31', 'test_F031_ermo');
    await importOneXml('F032_Trmos/import/F32', 'test_F032_trmo');
    await importOneXml('F033_Spmos/import/F33', 'test_F033_spmo');
    await importOneXml('F038_Addrmps/import/F38', 'test_F038_addrmp');
    await importOneXml('F037_Licmo/import/F37', 'test_F037_licmo');
    await importOneXml('F005_StatOpl/import/F5', 'test_F005_StatOpl');
    await importOneXml('F006_VidExp/import/F6', 'test_F006_VidExp');
    await importOneXml('F007_Vedom/import/F7', 'test_F007_Vedom');
    await importOneXml('F008_TipOms/import/F8', 'test_F008_TipOms');
    await importOneXml('F009_StatZl/import/F9', 'test_F009_StatZl');
    await importOneXml('F010_Subecti/import/F10', 'test_F010_Subecti');
    await importOneXml('F002_SmoEmp/import/F2', 'test_F002');
    await importOneXml('F011_Tipdoc/import/F11', 'test_F011_Tipdoc');
    await importOneXml('F012_TipSch/import/F12', 'test_F012_TipSch');
    await importOneXml('F015_Okrug/import/F15', 'test_F015_Okrug');
    await importOneXml('F017_BillTypes/import/F17', 'test_F017_BillTypes');
    await importOneXml('F014_OplOtk/import/F14', 'test_F014_OplOtk');
    await importOneXml('F001_Tfoms/import/F1', 'test_F001_tfoms');
    await importOneXml('F019_PersAccOrg/import/F19', 'test_F019_PersAccOrg');
    
    await alert('Импорт завершен!');
}

function importOneXml(patch, fileName) {
    // 1. Загружаем XML файл как BLOB (бинарные данные)
    return fetch('/xml/' + fileName + '.xml')
        .then(response => response.blob())  // изменили: .blob() вместо .text()
        .then(blob => {
            // 2. Отправляем на C# сервер как есть
            return fetch('http://localhost:5000/api/' + patch, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/xml; charset=windows-1251'
                },
                body: blob  // отправляем blob, а не строку (чтобы не портить кодировкой данные)
            });
        })
        .then(response => response.text())
        .then(data => {
            console.log('Ответ сервера:', data);
            //alert('Импорт ' + fileName + ' завершен! Результат: ' + data);
            addLog(fileName, data);
        })
        .catch(error => {
            console.error('Ошибка:', error);
            alert('Ошибка при импорте ' + fileName + ': ' + error.message);
        });
}