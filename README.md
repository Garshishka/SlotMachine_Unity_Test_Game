# Проект Спин-машины под Android

Базовый проект игры со спин-машиной, сделанный в Юнити под Android. Графика тестовая. У спин-машины имеется:

1. Три колонки слотов
2. Отображения количества спинов
3. Отображение времени восстановления спинов
4. Кнопка SPIN - запускает слот-машину
5. Кнопка BET - выбирает размер ставки
6. Счётчик полученных монет


Assets папка для импорта в Unity проект. Сделан в Unity 2019.2.0f1 и Visual studio 15.8.5

	Assets/ResultsScript.cs - основная логика программы
	Assets/BetButtonClick.cs - выбор ставки
	Assets/SpinClick.cs - что происходит при нажатии кнопки Spin
	Assets/SpinRollScript.cs - Движение барабанов

PayTable.PNG в корне проекта - как считается выигрыш

SlotM.apk - готовое .apk проекта
