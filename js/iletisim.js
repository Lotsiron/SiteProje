function temizleForm() {
  document.getElementById("formIletisim").reset();
}

var fields = {};  // global erişmek için

document.addEventListener("DOMContentLoaded", function() {   // kod uzamasın diye hepini tek seferde kısaltmak
  fields.ad = document.getElementById('iad');
  fields.soyad = document.getElementById('isoyad');
  fields.email = document.getElementById('email');
  fields.il = document.getElementById('il');
  fields.mesaj = document.getElementById('mesaj');
})

function emailDogrulama(email) {
  let regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
  return regex.test(String(email).toLowerCase());
}

function bosDegil(value) {
  if (value == null || typeof value == 'undefined' ) return false; //boş mu?
  return (value.length > 0);   // boş olan bir string mi?
}

function fieldDogrulama(field, dogrulamaFonksiyonu) {
  if (field == null) return false;
 
  let dogrumu = dogrulamaFonksiyonu(field.value)
  if (!dogrumu) {
  field.className = 'placeholderRed';
  } else {
  field.className = '';
  }
 
  return dogrumu;
}

function isValid() {
  var valid = true;
  
  valid &= fieldDogrulama(fields.ad, bosDegil);
  valid &= fieldDogrulama(fields.soyad, bosDegil);
  valid &= fieldDogrulama(fields.il, bosDegil);
  valid &= fieldDogrulama(fields.email, bosDegil);
  valid &= fieldDogrulama(fields.mesaj, bosDegil);
 
  return valid;
}

class Kullanıcı {                                 // oluşturulan bu kullanıcı ve bilgileri bir database'e göndermek için kullanılabilir 
  constructor(ad, soyad, il, email, mesaj) {
  this.ad = ad;
  this.soyad = soyad;
  this.il = il;
  this.email = email;
  this.mesaj = mesaj;
  }
}

function iGonder() {
  if (isValid()) {
    let klnc = new Kullanıcı(iad.value, isoyad.value, il.value, email.value, mesaj.value);

    alert(" Mesajınız için teşekkürler " + iad.value + " " + isoyad.value + "\n Mesajınız : " + mesaj.value)
  }
  else { alert("Bir hata çıktı")} 
}



