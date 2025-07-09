# Lisanslanabilir ve Dağıtılabilir bir ToDoList Uygulaması

## Amaç

Bir uygulamayı lisanslayabilmek ve kurulum dosyası haline getirip dağıtabilmek.

## İçerik

- License API
- License Library
- ToDoList App
- Setup Project

### License API

- Makine ID'sine göre lisans anahtarı oluşturur.
- Gönderilen lisans anahtarını doğrular ve veritabanına kaydeder.

### License Library

- Lisans anahtarı oluşturma ve lisanslama işlemlerini gerçekleştirir.
- API ile haberleşen **License Service** içerir.

### ToDoList App

- Lisans anahtarı sayfası ve uygulama ekranı içerir.
- Cihaza özel anahtar üretir ve bunu aktifleştirebilir.
- Lisanslanmayan uygulama 5 ten fazla yeni iş ekleyemez.

### Setup Project

- Gerekli dosyaları toplayarak birer adet **.msi** ve **.exe** setup dosyalarını oluşturur.
