//Hizmet resimleri
let jSlideSayi = 1;
slideGoster(jSlideSayi);

// sonraki/önceki kontrolleri
function slideArttir(n) {
  slideGoster(jSlideSayi += n);
}

// Küçük resim kontrolleri
function SlideSabit(n) {
  slideGoster(jSlideSayi = n);
}


function slideGoster(n) {
  let i;
  let jslides = document.getElementsByClassName("slide");
  let jkucukresim = document.getElementsByClassName("kucukresim");
  if (n > jslides.length) {jSlideSayi = 1}
  if (n < 1) {jSlideSayi = jslides.length}
  for (i = 0; i < jslides.length; i++) {
    jslides[i].style.display = "none";
  }
  for (i = 0; i < jkucukresim.length; i++) {
    jkucukresim[i].className = jkucukresim[i].className.replace(" active", "");
  }
  jslides[jSlideSayi-1].style.display = "block";
  jkucukresim[jSlideSayi-1].className += " active";
}
