
<?php

 // biliyorum email değil kullanıcı adı ama format email o yüzden email yazdım
 $email = $_POST['kadi'];
 $sifre = $_POST['sifre'];
 $email = strtoupper($email);
 $sifre = strtoupper($sifre);
 $sonuc = "Hoşgeldiniz Ziyaretçi";

 $pattern = '/^[A-Za-z][0-9]{9}@SAKARYA\.EDU\.TR$/';
 $emailAd = substr($email, 0, 10);
 if (preg_match($pattern, $email) && $emailAd === $sifre ) {
    $sonuc = "Hoşgeldiniz $sifre";
} else {
    $sonuc = "Geçersiz Kullanıcı Adı ya da Şifre";
}




?>