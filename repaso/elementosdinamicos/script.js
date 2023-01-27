var lugares=32;
var filas= Math.ceil(lugares/5);

var fila='';
var cont=1;
//Armar todas las filas
for (let index = 0; index < filas; index++) {
    fila+='<div class="fila">';
    //arma cada fila
    for (let e = 1; e <= 5; e++) {
        fila+=`<div class="espacio">E${cont}</div>`;
        cont++;
     //fila+=`<div class="espacio">E` + cont + `</div>`;    
    }
    fila+="</div>";
} 
document.getElementById("laboratorio").innerHTML=fila;