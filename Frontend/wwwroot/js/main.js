
// функция открытия страницы для выгрузки данных из XML в БД
function openImport() {
    fetch('/Import/All')
        .then(response => response.text())
        .then(html => {
            document.querySelector('.right').innerHTML = html;
            
            // ЗАГРУЖАЕМ И ВЫПОЛНЯЕМ СКРИПТ
            const script = document.createElement('script');
            script.src = '/js/import/importXml.js';
            document.body.appendChild(script);
        })
        .catch(error => {
            document.querySelector('.right').innerHTML = '<p>Ошибка загрузки</p>';
        });
}

// подгрузка основной страницы с таблицей документа 
function loadTablePage(tableId) {
    // Показываем индикатор загрузки
    document.querySelector('.right').innerHTML = '<div style="padding: 20px;">Загрузка...</div>';
    
    // Асинхронно получаем HTML таблицы
    fetch(`/Table/GetTable?tableId=${tableId}`)
        .then(response => response.text())
        .then(html => {
            // Вставляем полученный HTML в правый див
            document.querySelector('.right').innerHTML = html;

            // Загружаем JS файл для этой таблицы динамически
            const script = document.createElement('script');
            script.src = '/js/Table/GetTable.js';
            document.body.appendChild(script);
        })
        .catch(error => {
            document.querySelector('.right').innerHTML = `<div style="color: red; padding: 20px;">Ошибка: ${error}</div>`;
        });
}