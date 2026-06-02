// функция поиска таблицы по фильтрам
function loadTableByParam(tableId) {  

    // Формируем json
    const filter = {};
    
    // Находим все поля ввода в строке input-row
    document.querySelectorAll('.input-row input').forEach(input => {
        const fieldName = input.id;        // id = имя свойства
        const fieldValue = input.value;    // значение из поля
        if (fieldValue) {
            filter[fieldName] = fieldValue;
        }
    });
    
    console.log(filter);

    // Показываем индикатор загрузки
    document.querySelector('.right').innerHTML = '<div style="padding: 20px;">Загрузка...</div>';

    // Асинхронно получаем HTML таблицы
    fetch(`/Table/GetTable?tableId=${tableId}&filterJson=${JSON.stringify(filter)}`)
        .then(response => response.text())
        .then(html => {
            // Вставляем полученный HTML в правый див
            document.querySelector('.right').innerHTML = html;
        })
        .catch(error => {
            document.querySelector('.right').innerHTML = `<div style="color: red; padding: 20px;">Ошибка: ${error}</div>`;
        });
}