# ToDoList
ToDoList bizim okul projemizdir. Bu projede proje yönetimini ve github kullanımını geliştirdiğimiz bir proje.
Bu projede takvimden günlük görevlerinizi takvimde kaydedebilir bunları listeleyebilir ve o güne ait görevleri bir bildirim şeklinde ekrandan alabilirsiniz. 
Ayrıca bu uygulamadan bazı şehirlerin günlük hava durumunu da kontrol edebilrisiniz.
Uygulamaya önce kayıt olup sonra giriş yaparak ToDoList i kullanabilirsiniz.

ToDoList uygulamasında veritabanı olarak MSSQL kullanılmıştır. Kullanıcı bilgileri buraya kaydediliyor. Güvenlik sorunları olmasının önüne geçmek için SHA-256 şifreleme algoritması ile
şifreleriniz veritabanına şifrelenmiş bir şekilde kayıt ediliyor. Ayrıca Veritabanında Görevler ve aylar tablosu var. Aylar tabloları ile Main Ekranda takvim oluşuyor. Görevler tablosunda ise
o güne ait görev eklerseniz görevler oraya kaydediliyor.
Uygulamada API kullanarak openweathermap den bazı şehirlerin anlık hava durumu bilgilerini çekip işleme yaparak o şehirlerin anlık hava durumuna ulaşabilirsiniz.


Uygulamanın birkaç fotoğrafı ekteki gibidir:

![ss1](https://github.com/Yunuskprc/ToDoList/assets/91240806/4bd7f976-d75b-4858-9a9d-e9abf6a2f168)
![ss2](https://github.com/Yunuskprc/ToDoList/assets/91240806/52fbfe46-aa6d-4708-bba3-901a07812442)
![ss3](https://github.com/Yunuskprc/ToDoList/assets/91240806/8ccc5923-a764-434d-bf27-c1ddd0c74240)
![ss4](https://github.com/Yunuskprc/ToDoList/assets/91240806/3afca46c-90a6-473e-9c70-db86cdb49df0)
![ss5](https://github.com/Yunuskprc/ToDoList/assets/91240806/b33f0e57-baf1-40ce-86d7-4362566405c8)
![ss6](https://github.com/Yunuskprc/ToDoList/assets/91240806/412f03d2-a5ec-4717-bf10-e59cde141fb4)
