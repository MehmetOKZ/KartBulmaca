# 🍒 Kart Bulmaca Oyunu - Hafıza Eşleştirme

Bu proje, C# ve Windows Forms kullanılarak geliştirilen basit bir hafıza oyunudur. Oyuncunun amacı, kartları tıklayarak aynı sembolleri eşleştirmektir. Oyun; rastgele karıştırılmış 8 farklı sembolden (her biri çift) oluşur.

## 🎮 Oynanış

- Oyuncu her seferinde iki kart açar.
- Eğer semboller eşleşirse kartlar pasif hale gelir.
- Eğer eşleşmezse kartlar tekrar kapanır.
- Tüm kartlar başarıyla eşleştirildiğinde oyun biter ve bir tebrik mesajı gösterilir.

## 🧠 Özellikler

- Basit ve anlaşılır kullanıcı arayüzü.
- Dinamik olarak sembollerin karıştırılması.
- Her eşlemeden sonra kısa bir bekleme süresi (750ms).
- Oyun bitince otomatik tebrik mesajı.

## 🖼️ Ekran Görüntüleri

### Başlangıç Ekranı
![Screenshot-1](https://github.com/MehmetOKZ/KartBulmaca/blob/master/ASSET/Screenshot-1.png?raw=true)

### Oyun Sırasında
![Screenshot-2](https://github.com/MehmetOKZ/KartBulmaca/blob/master/ASSET/Screenshot-2.png?raw=true)

### Oyun Sonu
![Screenshot-3](https://github.com/MehmetOKZ/KartBulmaca/blob/master/ASSET/Screenshot-3.png?raw=true)

## 🛠️ Nasıl Çalışır?

### Kart Dağıtımı

```csharp
semboller = semboller.OrderBy(x => rnd.Next()).ToList();

Kart Tıklama
btn.Click += KartTiklandi;
Kullanıcı bir karta tıkladığında, eğer kart daha önce açılmamışsa sembol gösterilir ve eşleşme kontrolü başlatılır.

Eşleşme Kontrolü
if (ilkSecilen.Tag.ToString() == ikinciSecilen.Tag.ToString())
{
    ilkSecilen.Enabled = false;
    ikinciSecilen.Enabled = false;
}

OyunBitişKontrolü
if (kontrol is Button && kontrol.Enabled)
{
    return;
}
MessageBox.Show("Tebrikler tüm eşleşmeler doğru! :) ");

📁 Kurulum
1.Bu repoyu klonlayın veya indirin.

2.Visual Studio ile açın.

3.Form1.cs dosyasında oyunun mantığı yer almaktadır.

4.Form1.Designer.cs içindeki tableLayoutPanel1 tasarımda en az 16 buton içermelidir.

5.Derleyip çalıştırın. 🚀

📌 Gereksinimler
--.NET Framework 4.7.2 veya üzeri

--Visual Studio 2019 veya üzeri


