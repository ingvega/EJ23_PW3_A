var lugares=32;
var filas= Math.ceil(lugares/5);

var fila='';
var cont=1;
//Armar todas las filas
for (let index = 0; index < filas; index++) {
    //Crear el div de la fila (un div vacío)
    fila=document.createElement("div");
    fila.className='fila';
    
    //fila+='<div class="fila">';
    //arma cada fila
    let espacio;
    for (let e = 1; e <= 5; e++) {
        espacio=document.createElement("div");
        espacio.className='espacio';
        espacio.innerText='E'+cont;
        espacio.addEventListener("click",clickEspacio);
        cont++;
        fila.append(espacio);
    }
    document.getElementById("laboratorio").append(fila);
} 


function clickEspacio(e){
    if(e.target.style.backgroundColor=='red'){
        e.target.style.backgroundColor='white';
    }else{
        e.target.style.backgroundColor='red';
    }
}