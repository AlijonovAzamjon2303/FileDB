# FileDB Console Application   
# Text/Json database CRUD  
Bu loyiha database sifatida fayllardan foydalanishga mo'ljallangan.   
Siz quyidagi dasturda .json yoki .txt fayllardan database sifatida foydalanishni tanlashingiz mumkin.   
[Interface](https://github.com/AlijonovAzamjon2303/FileDB/blob/master/FileDB/Brokers/Storages/IStorageBroker.cs)'lar qo'llanganligi sababli dasturimiz SOLID design principle'lariga to'liq tushadi.  
[Identity Service](https://github.com/AlijonovAzamjon2303/FileDB/blob/master/FileDB/Services/Identities/IdentityService.cs) orqali Singleton design pattern amalda qo'llangan. Bu bo'limimizda yangi userga takrorlanmagan 
yangi Id berishimiz mumkin bo'ladi.   
[Files](https://github.com/AlijonovAzamjon2303/FileDB/tree/master/FileDB/Services/Files) bo'limi orqali esa Composite dwsign pattern amalga oshirilgan.   
## Quyida dastur ishidan namuna keltirib o'taman  
![demoFileDB](https://github.com/AlijonovAzamjon2303/FileDB/assets/112892881/5554efcc-2afb-472d-a5f0-8866aff3def9)
