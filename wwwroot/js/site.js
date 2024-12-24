
function menuButonu() {
    var menu = document.getElementById("menu");

    if (menu.style.display === "none") {
        menu.style.display = "block";
    } else {
        menu.style.display = "none";
    }
}

// header küçülmesi 
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.documentElement.scrollTop > 120) {
        document.getElementById("header").style.height = "50px";
        document.getElementById("Logo").style.height = "50px";
    }
    else if (document.documentElement.scrollTop < 60) {
        document.getElementById("header").style.height = "120px";
        document.getElementById("Logo").style.height = "100px";
    }
} 
