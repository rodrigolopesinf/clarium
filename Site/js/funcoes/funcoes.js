function ShowHideDIV(nomeDiv, nomeDiv2, valor, elem) {
    valor = document.getElementById(elem).value;
    if (valor === "true") {
        document.getElementById(nomeDiv).style.display = "block";
        document.getElementById(nomeDiv2).style.display = "none";
    }
    else {
        document.getElementById(nomeDiv).style.display = "block";
        document.getElementById(nomeDiv2).style.display = "none";
    }
}

function ShowHideDIV2(nomeDiv, valor, elem) {
    valor = document.getElementById(elem).value;
    if (valor == "True") {
        document.getElementById(nomeDiv).style.display = "none";
    }
    else {
        document.getElementById(nomeDiv).style.display = "block";
    }
}