document.getElementById('getWeather').addEventListener('click', function() {
    const location = document.getElementById('location').value;
    const apiKey = '2aeb4c1fcf414143b7c185758252402'; 
    const url = `https://api.weatherapi.com/v1/forecast.json?key=${apiKey}&q=${location}&days=3`;

    const xhr = new XMLHttpRequest();
    document.getElementById('loading').classList.remove('hidden'); 
    xhr.open('GET', url, true);
    xhr.onload = function() {
        document.getElementById('loading').classList.add('hidden'); 
        if (xhr.status === 200) {
            const data = JSON.parse(xhr.responseText);
            let weatherResult = `<h2>${data.location.name}</h2>`;
            weatherResult += `<p>Температура: ${data.current.temp_c} °C</p>`;
            weatherResult += `<p>Влажность: ${data.current.humidity} %</p>`;
            weatherResult += `<img src="${data.current.condition.icon}" alt="${data.current.condition.text}">`;
            weatherResult += `<h3>Прогноз на 3 дня:</h3>`;
            data.forecast.forecastday.forEach(day => {
                weatherResult += `
                    <div>
                        <h4>${day.date}</h4>
                        <p>Макс: ${day.day.maxtemp_c} °C, Мин: ${day.day.mintemp_c} °C</p>
                        <img src="${day.day.condition.icon}" alt="${day.day.condition.text}">
                    </div>
                `;
            });
            document.getElementById('weatherResult').innerHTML = weatherResult;
        } else {
            document.getElementById('weatherResult').innerHTML = '<p>Ошибка: Город не найден.</p>';
        }
    };
    xhr.onerror = function() {
        document.getElementById('loading').classList.add('hidden'); 
        document.getElementById('weatherResult').innerHTML = '<p>Ошибка: Не удалось выполнить запрос.</p>';
    };
    xhr.send();
});

