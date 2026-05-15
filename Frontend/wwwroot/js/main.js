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