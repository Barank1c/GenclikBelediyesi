$(document).ready(function () {
    $('.multiple-items').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
            }
        }]
    });
});

const passwordInput = document.querySelector("#Sifre")
const eye = document.querySelector("#eye")

eye.addEventListener("click", function () {
    this.classList.toggle("fa-eye-slash")
    const type = passwordInput.getAttribute("type") === "password" ? "text" : "password"
    passwordInput.setAttribute("type", type)
})

const passwordInput1 = document.querySelector("#sifre1")
const eye1 = document.querySelector("#eye1")

eye1.addEventListener("click", function () {
    this.classList.toggle("fa-eye-slash")
    const type = passwordInput1.getAttribute("type") === "password" ? "text" : "password"
    passwordInput1.setAttribute("type", type)
})


function passwordcontrol() {
    var password1 = document.getElementById("sifre").value;
    var password2 = document.getElementById("sifre1").value;
    if (password1 != password2) {
        alert("Şifreler Farklı!")
        return false;
    }
    return true;
}

function TCNOKontrol() {
    var TCNO = document.getElementById('kimlik').value;
    let bool = true;
    var tek = 0,
        cift = 0,
        sonuc = 0,
        TCToplam = 0,
        i = 0,
        hatali = [11111111110, 22222222220, 33333333330, 44444444440, 55555555550, 66666666660, 7777777770, 88888888880, 99999999990];;


    if (TCNO.length != 11) bool = false;
    if (isNaN(TCNO)) bool = false;
    if (TCNO[0] == 0) bool = false;

    tek = parseInt(TCNO[0]) + parseInt(TCNO[2]) + parseInt(TCNO[4]) + parseInt(TCNO[6]) + parseInt(TCNO[8]);
    cift = parseInt(TCNO[1]) + parseInt(TCNO[3]) + parseInt(TCNO[5]) + parseInt(TCNO[7]);

    tek = tek * 7;
    sonuc = Math.abs(tek - cift);
    if (sonuc % 10 != TCNO[9]) bool = false;

    for (var i = 0; i < 10; i++) {
        TCToplam += parseInt(TCNO[i]);
    }

    if (TCToplam % 10 != TCNO[10]) bool = false;

    if (hatali.toString().indexOf(TCNO) != -1) bool = false;

    if (!bool) {
        alert("GEÇERSİZ KİMLİK NUMARASI!");
    }
    return bool;
}

